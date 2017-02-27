using Newtonsoft.Json;

namespace RKon.Alexa.NET.Request
{
    /// <summary>
    /// Payload für TurnOn und TurnOfRequests
    /// </summary>
    public class TurnOnOffRequestPayload : DiscoveryRequestPayload
    {
        /// <summary>
        /// Das Gerät für das die Aktion bestimmt ist
        /// </summary>
        [JsonProperty("appliance")]
        public RequestAppliance Appliance { get; set; }
    }
}
