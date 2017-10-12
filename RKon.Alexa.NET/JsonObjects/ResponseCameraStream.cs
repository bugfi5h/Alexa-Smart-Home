using Newtonsoft.Json;

namespace RKon.Alexa.NET.JsonObjects
{
    /// <summary>
    /// CameraStream with extra informations
    /// </summary>
    public class ResponseCameraStream :CameraStream
    {
        /// <summary>
        /// The URI for the camera stream.
        /// </summary>
        [JsonProperty("uri")]
        [JsonRequired]
        public string URI { get; set; }
        /// <summary>
        /// A date in ISO 8601 format indicating the expiration time of the stream. Should be specified in UTC. Can be null
        /// </summary>
        [JsonProperty("expirationTime",NullValueHandling =NullValueHandling.Ignore)]
        public string ExpirationTime { get; set; }
        /// <summary>
        /// Indicates the timeout value for the stream.. Can be null
        /// </summary>
        [JsonProperty("idleTimeoutSeconds", NullValueHandling = NullValueHandling.Ignore)]
        public int IdleTimeoutSeconds { get; set; }
    }
}
