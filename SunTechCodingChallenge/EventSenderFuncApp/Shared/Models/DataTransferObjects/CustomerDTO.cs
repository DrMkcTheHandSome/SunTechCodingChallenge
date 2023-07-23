using EventSenderFuncApp.Commands.CustomerInformationManagement.Commands;
using EventSenderFuncApp.Shared.Helpers;
using EventSenderFuncApp.Shared.SeedData;
using Newtonsoft.Json;
using System;


namespace EventSenderFuncApp.Shared.Models.DataTransferObjects
{
    public class CustomerDTO
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
        public string Type { get; set; }

        public CustomerDTO(CreateCustomerCommand command)
        {
            Id = Guid.NewGuid().ToString();
            FirstName = command.FirstName;
            LastName = command.LastName;
            BirthdayInEpoch = DateTimeHelper.ConvertDateTimetoEpoch(DateTime.Parse(command.Birthday));
            Email = command.Email;
            Type = CustomerTypeSD.GetCustomerType();
        }
    }
}
