using Newtonsoft.Json;

namespace RKon.Alexa.NET46.Payloads
{
    /// <summary>
    /// Payload of a DefferedResponse
    /// </summary>
    public class DefferedResponsePayload : Payload
    {
        /// <summary>
        /// Optional. An integer that indicates an approximate time, in seconds, before the asynchronous response is sent.
        /// </summary>
        [JsonProperty("estimatedDeferralInSeconds", NullValueHandling =NullValueHandling.Ignore)]
        public int? EstimatedDeferralInSeconds { get; set; }
    }
}
