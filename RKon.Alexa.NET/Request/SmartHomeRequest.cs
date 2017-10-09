using Newtonsoft.Json;

namespace RKon.Alexa.NET.Request
{
    /// <summary>
    /// SmartHomeRequest Class 
    /// </summary>
    [JsonConverter(typeof(SmartHomeRequestConverter))]
    public class SmartHomeRequest
    {
        /// <summary>
        /// Headerinformations
        /// </summary>
        [JsonProperty("header")]
        public RequestHeader Header { get; set; }
        /// <summary>
        /// Payloadinformations
        /// </summary>
        [JsonProperty("payload")]
        public RequestPayload Payload { get; set; }

        /// <summary>
        /// returns the type of the payload
        /// </summary>
        /// <returns>System.Type Payloadtype</returns>
        public System.Type GetRequestPayloadType()
        {
            return Payload?.GetType();
        }
    }
}
