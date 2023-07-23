using MediatR;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace EventSenderFuncApp.Commands.CustomerInformationManagement.Commands
{
    [DataContract]
    public class CreateCustomerCommand : IRequest<bool>
    {
        [JsonProperty(PropertyName = "firstName")]
        [DataMember]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        [DataMember]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "birthday")]
        [DataMember]
        public string Birthday { get; set; }

        [JsonProperty(PropertyName = "email")]
        [DataMember]
        public string Email { get; set; }
    }
}
