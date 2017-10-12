using Newtonsoft.Json;

namespace RKon.Alexa.NET.Response.ErrorResponses
{
    /// <summary>
    /// Payload for DependentServiceUnavailable
    /// </summary>
    public class DependentServiceUnavailablePayload : ResponsePayload
    {
        /// <summary>
        /// Name of the dependent Service
        /// </summary>
        [JsonProperty("dependentServiceName")]
        [JsonRequired]
        public string DependentServiceName { get; set; }

        /// <summary>
        /// Construktor. Sets DependentServiceName
        /// </summary>
        /// <param name="serviceName"></param>
        public DependentServiceUnavailablePayload(string serviceName)
        {
            DependentServiceName = serviceName;
        }

    }
}
