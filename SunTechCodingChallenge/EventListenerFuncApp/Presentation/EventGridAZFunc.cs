using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using System.Collections.Generic;
using Azure.Messaging.EventGrid;
using Azure;
using System.Text.Json;
using EventListenerFuncApp.Shared.ViewModels;

namespace EventListenerFuncApp.Presentation
{
    public class EventGridAZFunc
    {
        private readonly string _eventGridURL;
        private readonly string _eventGridAPIKey;

        public EventGridAZFunc()
        {
            _eventGridURL = System.Environment.GetEnvironmentVariable("EventGrid:URL");
            _eventGridAPIKey = System.Environment.GetEnvironmentVariable("EventGrid:APIKey");
        }

        [FunctionName("CreateAzureEventGrid")]
        public async Task CreateAzureEventGrid(
          [CosmosDBTrigger(
                databaseName: "ecommerce",
                containerName: "customers",
                Connection = "CosmosDbNoSQL:ConnectionString",
                LeaseContainerName = "leases",
                LeaseContainerPrefix = "EventGridAlert-"
            )]
            IReadOnlyList<CustomerViewModel> documents)
        {
                foreach (var document in documents)
                {

                    EventGridPublisherClient client = new EventGridPublisherClient(new Uri(_eventGridURL), new AzureKeyCredential(_eventGridAPIKey));

                    EventGridEvent egEvent =
                        new EventGridEvent(
                            "Customer Container Event",
                            "Example.EventType",
                            "1.0",
                            JsonSerializer.Serialize(document));

                    // Send event to Event Grid
                    await client.SendEventAsync(egEvent);
                }

        }
    }
}
