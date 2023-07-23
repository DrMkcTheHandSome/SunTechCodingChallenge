using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using EventSenderFuncApp.Commands.CustomerInformationManagement.Commands;
using MediatR;
using EventSenderFuncApp.Shared.ObjectResults;
using EventSenderFuncApp.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;

namespace EventSenderFuncApp.Presentation
{
    public class CustomerInformationAZFunc
    {
        private readonly IMediator _mediator;
        private readonly ICustomerQuery _customerInformationQuery;
        public CustomerInformationAZFunc(IMediator mediator,
            ICustomerQuery customerInformationQuery)
        {
            _mediator = mediator;
            _customerInformationQuery = customerInformationQuery;
        }

        [FunctionName("CreateCustomerInformation")]
        public async Task<ActionResult> CreateCustomerInformation(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "customerinformation")] CreateCustomerCommand customerInfoCommand)
        {
            try
            {
                var commandResult = await _mediator.Send(customerInfoCommand);

                if (!commandResult)
                {
                    return new BadRequestObjectResult("");
                }

                return new OkObjectResult("");
            }
            catch
            {
                return new InternalServerErrorObjectResult("");
            }
        }

        [FunctionName("GetCustomerAnalytic")]
        public async Task<ActionResult> GetCustomerInformationByLastName(
     [HttpTrigger(AuthorizationLevel.Function, "get", Route = "customerinformation/analytic")] HttpRequest req)
        {
            try
            {

                var items = await _customerInformationQuery.GetCustomerAnalytic();

                return new OkObjectResult(items);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("404"))
                    return new NotFoundObjectResult("");

                return new InternalServerErrorObjectResult("");
            }
        }
    }
}


