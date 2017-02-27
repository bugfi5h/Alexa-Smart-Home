using Newtonsoft.Json;

namespace RKon.Alexa.NET.Request
{
    /// <summary>
    /// Payload für einen DiscoverApplianceRequest
    /// </summary>
    public class DiscoveryRequestPayload : RequestPayload
    {
        /// <summary>
        /// Access Token, der der Kunden Geräte Cloud zugewiesen ist.
        /// </summary>
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
    }
}
