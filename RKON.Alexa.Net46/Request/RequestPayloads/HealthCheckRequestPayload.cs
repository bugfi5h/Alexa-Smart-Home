using Newtonsoft.Json;
namespace RKon.Alexa.NET46.Request.RequestPayloads
{
    /// <summary>
    /// Payload for a HealthCheckRequest
    /// </summary>
    public class HealthCheckRequestPayload : RequestPayload
    {
        /// <summary>
        /// Timestamp  in Milliseconds till the 1.01.1970
        /// </summary>
        [JsonProperty("initiationTimestamp")]
        public long InitiationTimestamp { get; set; }
    }
}
