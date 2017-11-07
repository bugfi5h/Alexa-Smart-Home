using Newtonsoft.Json;
namespace RKon.Alexa.NET46.Payloads
{
    /// <summary>
    /// Payload for AdjustBrightnessRequests
    /// </summary>
    public class AdjustBrightnessRequestPayload : Payload
    {
        /// <summary>
        /// The desired change in brightness as percentage points. A positive or negative integer value used to increase or decrease the percentage. For example, a starting value of 97 with a brightness delta of 3 would result in a final value of 100.
        /// </summary>
        [JsonProperty("brightnessDelta")]
        public int BrightnessDelta { get; set; }
    }
}
