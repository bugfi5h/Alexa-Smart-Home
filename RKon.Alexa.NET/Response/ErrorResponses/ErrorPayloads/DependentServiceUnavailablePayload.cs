using Newtonsoft.Json;

namespace RKon.Alexa.NET.Response.ErrorResponses
{
    /// <summary>
    /// Payload für DependentServiceUnavailable
    /// </summary>
    public class DependentServiceUnavailablePayload : ResponsePayload
    {
        /// <summary>
        /// Name des angeforderten Service
        /// </summary>
        [JsonProperty("dependentServiceName")]
        [JsonRequired]
        public string DependentServiceName { get; set; }

        /// <summary>
        /// Konstruktor. Setzt DependentServiceName
        /// </summary>
        /// <param name="serviceName"></param>
        public DependentServiceUnavailablePayload(string serviceName)
        {
            DependentServiceName = serviceName;
        }

    }
}
