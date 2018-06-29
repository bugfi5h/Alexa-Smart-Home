using Newtonsoft.Json;
using RKon.Alexa.NET46.Types;

namespace RKon.Alexa.NET46.JsonObjects
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
        public CameraProtocols Protocol { get; set; }
        /// <summary>
        /// A resolution object that describes the the resolution of the stream. Contains width and height properties.
        /// </summary>
        [JsonProperty("resolution")]
        public Resolution Resolution { get; set; }
        /// <summary>
        /// Describes the authorization type. Possible values are “BASIC”, DIGEST”, or “NONE”
        /// </summary>
        [JsonProperty("authorizationType")]
        public CameraAuthorizationTypes AuthorizationType { get; set; }
        /// <summary>
        /// The video codec for the stream. Possible values are “H264”, “MPEG2”, “MJPEG”, or “JPG”.
        /// </summary>
        [JsonProperty("videoCodec")]
        public VideoCodecs VideoCodec { get; set; }
        /// <summary>
        /// The audio code for the stream. Possible values are “G711”, “AAC”, or “NONE”.
        /// </summary>
        [JsonProperty("audioCodec")]
        public AudioCodecs AudioCodec { get; set; }

        /// <summary>
        /// Standartconstructor
        /// </summary>
        public CameraStream()
        {
        }

        /// <summary>
        /// Initilializes Camerastream
        /// </summary>
        /// <param name="protocol"></param>
        /// <param name="resolution"></param>
        /// <param name="authorizationType"></param>
        /// <param name="videoCodec"></param>
        /// <param name="audioCodec"></param>
        public CameraStream(CameraProtocols protocol, Resolution resolution, CameraAuthorizationTypes authorizationType, VideoCodecs videoCodec, AudioCodecs audioCodec)
        {
            Protocol = protocol;
            Resolution = resolution;
            AuthorizationType = authorizationType;
            VideoCodec = videoCodec;
            AudioCodec = audioCodec;
        }
    }
}
