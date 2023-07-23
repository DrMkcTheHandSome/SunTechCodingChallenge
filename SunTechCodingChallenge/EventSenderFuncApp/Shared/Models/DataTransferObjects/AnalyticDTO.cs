

using Newtonsoft.Json;

namespace EventSenderFuncApp.Shared.Models.DataTransferObjects
{
    public class AnalyticDTO
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        public AnalyticDTO(string id, int count, string type)
        {
            Id = id;
            Count = count;
            Type = type;
        }
    }
}
