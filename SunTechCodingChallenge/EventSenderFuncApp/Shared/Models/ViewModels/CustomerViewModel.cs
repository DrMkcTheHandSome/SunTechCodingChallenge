using Newtonsoft.Json;


namespace EventSenderFuncApp.Shared.Models.ViewModels
{
    public class CustomerViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "birthdayInEpoch")]
        public long BirthdayInEpoch { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string CustomerType { get; set; }
    }
}
