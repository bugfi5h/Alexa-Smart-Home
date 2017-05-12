using Newtonsoft.Json;
using RKon.Alexa.NET46.Types;

namespace RKon.Alexa.NET46.Request.RequestPayloads
{
    /// <summary>
    ///  Payload for a SetPercentageRequests
    /// </summary>
    public class SetPercentageRequestPayload : RequestPayloadWithAppliance
    {
        /// <summary>
        /// The percent change to apply to the device
        /// </summary>
        [JsonProperty("percentageState")]
        public PercentageState PercentageState { get; set; }
    }
}
