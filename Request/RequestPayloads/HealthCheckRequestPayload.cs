using Newtonsoft.Json;
namespace RKon.Alexa.NET.Request.RequestPayloads
{
    /// <summary>
    /// Payload für einen HealthCheckRequest
    /// </summary>
    public class HealthCheckRequestPayload : RequestPayload
    {
        /// <summary>
        /// Zeitstempel in Millisekunden seit dem 1.01.1970
        /// </summary>
        [JsonProperty("initiationTimestamp")]
        public long InitiationTimestamp { get; set; }
    }
}
