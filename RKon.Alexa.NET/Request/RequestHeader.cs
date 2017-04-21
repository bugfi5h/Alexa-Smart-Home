using Newtonsoft.Json;

namespace RKon.Alexa.NET.Request
{
    /// <summary>
    /// Header for a SmartHomeRequest
    /// </summary>
    public class RequestHeader
    {
        /// <summary>
        /// MessageId
        /// </summary>
        [JsonProperty("messageId")]
        public string MessageId { get; set; }
        /// <summary>
        /// PayloadVersion
        /// </summary>
        [JsonProperty("payloadVersion")]
        public string PayloadVersion { get; set; }
        /// <summary>
        /// Namespace
        /// </summary>
        [JsonProperty("namespace")]
        public string Namespace { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
