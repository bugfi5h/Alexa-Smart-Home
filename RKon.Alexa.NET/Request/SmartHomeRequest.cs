using Newtonsoft.Json;

namespace RKon.Alexa.NET.Request
{
    /// <summary>
    /// SmartHomeRequest Objekt an Hand von JSON Requests 
    /// </summary>
    [JsonConverter(typeof(RequestPayloads.SmartHomeRequestConverter))]
    public class SmartHomeRequest
    {
        /// <summary>
        /// Headerinformationen
        /// </summary>
        [JsonProperty("header")]
        public RequestHeader Header { get; set; }
        /// <summary>
        /// Payloadinformationen
        /// </summary>
        [JsonProperty("payload")]
        public RequestPayload Payload { get; set; }

        /// <summary>
        /// Gibt den Typ des Payloads zurück
        /// </summary>
        /// <returns></returns>
        public System.Type GetRequestPayloadType()
        {
            return Payload?.GetType();
        }
    }
}
