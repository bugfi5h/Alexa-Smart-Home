using Newtonsoft.Json;

namespace RKon.Alexa.NET46.Payloads
{
    /// <summary>
    /// Requestpayload for an incremental channel adjustment in discrete steps using a positive number for a step up, or negative number for a step down.
    /// </summary>
    public class SkipChannelRequestPayload : Payload
    {
        /// <summary>
        /// An integer value that indicates the channels to increment. A negative number indicates steps down, a positive number a steps up.
        /// </summary>
        [JsonProperty("channelCount")]
        public int ChannelCount { get; set; }
    }
}
