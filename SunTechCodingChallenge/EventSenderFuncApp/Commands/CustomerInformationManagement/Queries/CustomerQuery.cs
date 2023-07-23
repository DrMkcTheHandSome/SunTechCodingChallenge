using EventSenderFuncApp.Infrastructure.AzureManagement;
using EventSenderFuncApp.Infrastructure.Interfaces;
using EventSenderFuncApp.Shared.Constants;
using EventSenderFuncApp.Shared.Models.ViewModels;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventSenderFuncApp.Commands.CustomerInformationManagement.Queries
{
    public class CustomerQuery : ICustomerQuery
    {
        private readonly AzureCosmosDbNoSQLClient _azNoSQLDbCustomerContainer;
        private readonly AzureCosmosDbNoSQLClient _azNoSQLDbAnalyticsContainer;
        public CustomerQuery(ILogger<CustomerQuery> logger)
        {
            this._azNoSQLDbCustomerContainer = new AzureCosmosDbNoSQLClient(CosmosDbConst.ECommerceDatabase, CosmosDbConst.CustomerContainer);
            this._azNoSQLDbAnalyticsContainer = new AzureCosmosDbNoSQLClient(CosmosDbConst.ECommerceDatabase, CosmosDbConst.AnalyticsContainer);
        }

        public async Task<int> GetPartitionKeyCount(string partitionKey)
        {
            string sql = string.Format(@"SELECT VALUE COUNT(1) FROM c");

            var result = await this._azNoSQLDbCustomerContainer.GetTotalRows<int>(sql, partitionKey);

            return result.TotalCount;
        }

        public async Task<List<AnalyticViewModel>> GetCustomerAnalytic()
        {
            string sql = string.Format(@"SELECT * FROM c");

            var result = await this._azNoSQLDbAnalyticsContainer.Queryitems<AnalyticViewModel>(sql, "CustomerAnalytic");

            return result.Entities;
        }
    }
}
