using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RKon.Alexa.NET.JsonObjects;

namespace RKon.Alexa.NET.Payloads
{
    /// <summary>
    /// Payload fo Deactivation and activation started Responses
    /// </summary>
    public class SceneStartedResponsePayload : Payload
    {
        /// <summary>
        /// Describes why this event occurred.
        /// </summary>
        [JsonProperty("cause")]
        [JsonRequired]
        [JsonConverter(typeof(StringEnumConverter))]
        public Cause Cause { get; set; }
        /// <summary>
        /// When the activation event occurred.
        /// </summary>
        [JsonProperty("timestamp")]
        [JsonRequired]
        public string Timestamp { get; set; }
    }
}
