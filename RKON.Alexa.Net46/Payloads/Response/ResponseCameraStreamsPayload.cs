using Newtonsoft.Json;
using RKon.Alexa.NET46.JsonObjects;
using System.Collections.Generic;

namespace RKon.Alexa.NET46.Payloads
{
    /// <summary>
    /// Responsepayload for Camerastream events
    /// </summary>
    public class ResponseCameraStreamsPayload : Payload
    {
        /// <summary>
        /// An array of cameraStream structures that provide information about the stream.
        /// </summary>
        [JsonProperty("cameraStreams")]
        [JsonRequired]
        public List<ResponseCameraStream> CameraStreams { get; set; }

        /// <summary>
        /// The URI to a static image from a previous feed of the camera specified in the request
        /// </summary>
        [JsonProperty("imageUri")]
        [JsonRequired]
        public string ImageURI { get; set; }

    }
}
