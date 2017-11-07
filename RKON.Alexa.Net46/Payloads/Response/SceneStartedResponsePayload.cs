using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RKon.Alexa.NET46.JsonObjects;
using System;

namespace RKon.Alexa.NET46.Payloads
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
        public Cause Cause { get; set; }
        /// <summary>
        /// When the activation event occurred.
        /// </summary>
        [JsonProperty("timestamp")]
        [JsonRequired]
        public DateTime Timestamp { get; set; }
    }
}
