using EventSenderFuncApp.Infrastructure.AzureManagement;
using EventSenderFuncApp.Infrastructure.NotificationManagement;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EventSenderFuncApp.Shared.Constants;
using EventSenderFuncApp.Shared.Models.DataTransferObjects;
using EventSenderFuncApp.Shared.Helpers;
using EventSenderFuncApp.Infrastructure.Interfaces;

namespace EventSenderFuncApp.Commands.CustomerInformationManagement.Commands
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly AzureCosmosDbNoSQLClient _azNoSQLDbCustomerContainer;
        private readonly AzureCosmosDbNoSQLClient _azNoSQLDbAnalyticsContainer;
        private readonly ICustomerQuery _customerQuery;
        public CreateCustomerCommandHandler(IMediator mediator,
            ICustomerQuery customerQuery)
        {
            this._mediator = mediator;
            this._azNoSQLDbCustomerContainer = new AzureCosmosDbNoSQLClient(CosmosDbConst.ECommerceDatabase, CosmosDbConst.CustomerContainer);
            this._azNoSQLDbAnalyticsContainer = new AzureCosmosDbNoSQLClient(CosmosDbConst.ECommerceDatabase, CosmosDbConst.AnalyticsContainer);
            this._customerQuery = customerQuery;
        }

        /// <summary>
        /// Implementations:
        /// - Request property validations
        /// - Data mapping (setting up data for any operation)
        /// - Saving Data to cosmosDB
        /// - Sending Event to EventHandler class 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            //  Request property validations
            if (string.IsNullOrEmpty(request.FirstName) || string.IsNullOrEmpty(request.LastName))
                return false;

            if (!PropertyValidationHelper.ValidateEmail(request.Email))
                return false;

            if (!PropertyValidationHelper.ValidateDateTime(request.Birthday))
                return false;

            //Data mapping
            var customerDTO = new CustomerDTO(request);

            //Saving Data to cosmosDB
             var res1 = await this._azNoSQLDbCustomerContainer.UpsertItemToContainerAsync(customerDTO, customerDTO.Type);

            var totalCount = await this._customerQuery.GetPartitionKeyCount(customerDTO.Type);

            var analyticDTO = new AnalyticDTO(customerDTO.Type, totalCount++, "CustomerAnalytic");

             var res2 = await this._azNoSQLDbAnalyticsContainer.UpsertItemToContainerAsync(analyticDTO, analyticDTO.Type);

            //Sending Event to EventHandler class 
            await this._mediator.Publish(new EventNotification() { Message = $"Mediator EventNotification" });

            return res1 && res2;
        }
    }
}
