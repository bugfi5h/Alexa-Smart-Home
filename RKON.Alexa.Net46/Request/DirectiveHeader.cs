using Newtonsoft.Json;

namespace RKon.Alexa.NET46.Request
{
    /// <summary>
    /// RequestHeader
    /// </summary>
    public class DirectiveHeader
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
        /// <summary>
        /// A token that identifies a directive and one or more events associated with it. A correlation token is included in the following message types: 
        ///- A directive from Alexa to the skill.
        ///- An event in response to a directive.
        /// </summary>
        [JsonProperty("correlationToken", NullValueHandling = NullValueHandling.Ignore)]
        public string CorrelationToken { get; set; }
    }
}
