using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;


namespace EventSenderFuncApp.Infrastructure.AzureManagement
{
    public class AzureCosmosDbNoSQLClient 
    {
        private readonly CosmosClient _cosmosClient;
        private readonly Database _database;
        private readonly Container _container;

        public AzureCosmosDbNoSQLClient(string database, string container)
        {
            _cosmosClient = new CosmosClient(
           connectionString: System.Environment.GetEnvironmentVariable("CosmosDbNoSQL:ConnectionString"));
            _database =  _cosmosClient.GetDatabase(database);
            _container =  _database.GetContainer(container);
        }

        public async Task<bool> UpsertItemToContainerAsync<TEntity>(TEntity entity, string partitionKey)
        {
            var newItem = await _container.UpsertItemAsync<dynamic>(item: entity, new PartitionKey(partitionKey));
            return newItem.StatusCode == HttpStatusCode.OK ||
                newItem.StatusCode == HttpStatusCode.Created ? true : false;
        }

        /// <summary>
        /// RequestCharge - should never be more than 1 RU for documents under 1K
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id"></param>
        /// <param name="partitionKey"></param>
        /// <returns></returns>
        public async Task<(TEntity Entity, double RequestCharge)> ReadItemByIdAsync<TEntity>(string id, string partitionKey)
        {
            ItemResponse<TEntity> item = await _container.ReadItemAsync<TEntity>(id, new PartitionKey(partitionKey));
         
            return (item, item.RequestCharge); 
        }

        public async Task<(TEntity TotalCount, double RequestCharge)> GetTotalRows<TEntity>(string query, string partitionKey)
        {
            var options = new QueryRequestOptions { PartitionKey = new PartitionKey(partitionKey) };

            FeedIterator<TEntity> iterator = _container.GetItemQueryIterator<TEntity>(query, requestOptions: options);

            var entities = new List<TEntity>();
            var requestCharge = 0d;
            while (iterator.HasMoreResults)
            {
                var page = await iterator.ReadNextAsync();
                requestCharge += page.RequestCharge;
                entities.AddRange(page);
            }

            return (entities[0], requestCharge);
        }

        public async Task<(List<TEntity> Entities, double RequestCharge)> Queryitems<TEntity>(string query, string partitionKey)
        {
             var options = new QueryRequestOptions { PartitionKey = new PartitionKey(partitionKey) };

            FeedIterator<TEntity> iterator = _container.GetItemQueryIterator<TEntity>(query, requestOptions: options);

            var entities = new List<TEntity>();
            var requestCharge = 0d;
            while (iterator.HasMoreResults)
            {
                var page = await iterator.ReadNextAsync();
                requestCharge += page.RequestCharge;
                entities.AddRange(page);
            }

            return (entities, requestCharge);
        }
    }
}
