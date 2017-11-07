using Newtonsoft.Json;

namespace RKon.Alexa.NET46.Payloads
{
    /// <summary>
    /// Payload for AdjustPercentage Requests
    /// </summary>
    public class AdjustPercentageRequestPayload : Payload
    {
        /// <summary>
        /// The desired change in percentage. A positive or negative integer value used to increase or decrease the percentage. For example, a starting value of 100 and a percentage delta of -3 would result in a final value of 97.
        /// </summary>
        [JsonProperty("percentageDelta")]
        public int PercentageDelta { get; set; }
    }
}
