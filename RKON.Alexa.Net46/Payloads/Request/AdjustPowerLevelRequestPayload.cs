using Newtonsoft.Json;

namespace RKon.Alexa.NET46.Payloads
{
    /// <summary>
    /// Payload for AdjustPower
    /// </summary>
    public class AdjustPowerLevelRequestPayload : Payload
    {
        /// <summary>
        /// The desired change in power level as percentage points (-100 - 100). A positive or negative integer value used to increase or decrease the power level. For example, a starting value of 97 with a power level delta of 3 would increase the power level value to 100
        /// </summary>
        [JsonProperty("powerLevelDelta")]
        public int PowerLevelDelta { get; set; }
    }
}
