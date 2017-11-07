using Newtonsoft.Json;
using RKon.Alexa.NET46.Types;
using System;

namespace RKon.Alexa.NET46.JsonObjects
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
        public DateTime? ExpirationTime { get; set; }
        /// <summary>
        /// Indicates the timeout value for the stream.. Can be null
        /// </summary>
        [JsonProperty("idleTimeoutSeconds", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdleTimeoutSeconds { get; set; }

        /// <summary>
        /// StandardConstructor
        /// </summary>
        public ResponseCameraStream() : base()
        {
        }

        /// <summary>
        /// Initialises ResponseCameraStream
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="expirationTime"></param>
        /// <param name="protocol"></param>
        /// <param name="resolution"></param>
        /// <param name="authorizationType"></param>
        /// <param name="videoCodec"></param>
        /// <param name="audioCodec"></param>
        /// <param name="idle"></param>
        public ResponseCameraStream(string uri, CameraProtocols protocol, Resolution resolution, CameraAuthorizationTypes authorizationType, 
            VideoCodecs videoCodec, AudioCodecs audioCodec, int? idle = null, DateTime? expirationTime = null) 
            :base(protocol, resolution, authorizationType, videoCodec, audioCodec)
        {
            URI = uri;
            ExpirationTime = expirationTime;
            IdleTimeoutSeconds = idle;
        }
    }
}
