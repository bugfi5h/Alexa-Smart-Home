using Newtonsoft.Json;
using RKon.Alexa.NET.Types;

namespace RKon.Alexa.NET.Request.RequestPayloads
{
    /// <summary>
    ///  Payload für einen SetPercentageRequests
    /// </summary>
    public class SetPercentageRequestPayload : RequestPayloadWithAppliance
    {
        /// <summary>
        /// Prozentwert um den das Gerät angepasst werden soll
        /// </summary>
        [JsonProperty("percentageState")]
        public PercentageState PercentageState { get; set; }
    }
}
