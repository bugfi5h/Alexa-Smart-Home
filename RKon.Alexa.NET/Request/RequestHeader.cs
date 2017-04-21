using Newtonsoft.Json;

namespace RKon.Alexa.NET.Request
{
    /// <summary>
    /// Header für ein SmartHomeRequest
    /// </summary>
    public class RequestHeader
    {
        /// <summary>
        /// Nachrichtennummer
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
        /// Aktionsname
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
