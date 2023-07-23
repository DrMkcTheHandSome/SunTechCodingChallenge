using Newtonsoft.Json;


namespace EventSenderFuncApp.Shared.Models.ViewModels
{
    public class AnalyticViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}
