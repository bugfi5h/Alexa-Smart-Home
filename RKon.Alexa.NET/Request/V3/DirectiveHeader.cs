using Newtonsoft.Json;

namespace RKon.Alexa.NET.Request.V3
{
    /// <summary>
    /// RequestHeader
    /// </summary>
    public class DirectiveHeader : RequestHeader
    {
        /// <summary>
        /// A token that identifies a directive and one or more events associated with it. A correlation token is included in the following message types: 
        ///- A directive from Alexa to the skill.
        ///- An event in response to a directive.
        /// </summary>
        [JsonProperty("correlationToken")]
        public string CorrelationToken { get; set; }
    }
}
