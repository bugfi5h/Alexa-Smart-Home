using Newtonsoft.Json;

namespace RKon.Alexa.NET.JsonObjects
{
    /// <summary>
    /// Camera stream for an endpoint.
    /// </summary>
    public class CameraStream
    {
        /// <summary>
        /// Protocol for the stream such as RTSP
        /// </summary>
        [JsonProperty("protocol")]
        public string Protocol { get; set; }
        /// <summary>
        /// A resolution object that describes the the resolution of the stream. Contains width and height properties.
        /// </summary>
        [JsonProperty("resolution")]
        public Resolution Resolution { get; set; }
        /// <summary>
        /// Describes the authorization type. Possible values are “BASIC”, DIGEST”, or “NONE”
        /// </summary>
        [JsonProperty("authorizationType")]
        public string AuthorizationType { get; set; }
        /// <summary>
        /// The video codec for the stream. Possible values are “H264”, “MPEG2”, “MJPEG”, or “JPG”.
        /// </summary>
        [JsonProperty("videoCodec")]
        public string VideoCodec { get; set; }
        /// <summary>
        /// The audio code for the stream. Possible values are “G711”, “AAC”, or “NONE”.
        /// </summary>
        [JsonProperty("audioCodec")]
        public string AudioCodec { get; set; }
    }
}
