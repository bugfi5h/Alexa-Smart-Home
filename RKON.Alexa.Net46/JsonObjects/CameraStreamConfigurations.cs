using Newtonsoft.Json;
using System.Collections.Generic;

namespace RKon.Alexa.NET46.JsonObjects
{
    /// <summary>
    /// Why are they doing this...
    /// </summary>
    public class CameraStreamConfigurations
    {
        /// <summary>
        /// Protocols for the stream such as RTSP
        /// </summary>
        [JsonProperty("protocols")]
        [JsonRequired]
        public List <string> Protocols { get; set; }
        /// <summary>
        /// An array of resolution objects, which describe the resolutions of the stream. Each resolution contains a width and height property.
        /// </summary>
        [JsonProperty("resolutions")]
        [JsonRequired]
        public List<Resolution> Resolutions { get; set; }
        /// <summary>
        /// Describes the authorization type. Possible values are “BASIC”, “DIGEST” or “NONE”
        /// </summary>
        [JsonProperty("authorizationTypes")]
        [JsonRequired]
        public List<string> AuthorizationTypes { get; set; }
        /// <summary>
        /// The video codec for the stream. Possible values are “H264”, “MPEG2”, “MJPEG”, or “JPG”.
        /// </summary>
        [JsonProperty("videoCodecs")]
        [JsonRequired]
        public List<string> VideoCodecs { get; set; }
        /// <summary>
        /// The audio code for the stream. Possible values are “G711”, “AAC”, or “NONE
        /// </summary>
        [JsonProperty("audioCodecs")]
        [JsonRequired]
        public List<string> AudioCodecs { get; set; }

        /// <summary>
        /// Standardconstructor
        /// </summary>
        public CameraStreamConfigurations()
        {
            Protocols = new List<string>();
            Resolutions = new List<Resolution>();
            AuthorizationTypes = new List<string>();
            VideoCodecs = new List<string>();
            AudioCodecs = new List<string>();
        }
    }
}
