﻿using Newtonsoft.Json;
using RKon.Alexa.NET.JsonObjects;
using System.Collections.Generic;


namespace RKon.Alexa.NET.Request.V3.Payloads
{
    /// <summary>
    /// Payload for InitializeCameraRequests
    /// </summary>
    public class InitializeCameraRequestPayload : Payload
    {
        /// <summary>
        /// An array of cameraStream structures that provide information about the stream.
        /// </summary>
        [JsonProperty("cameraStreams")]
        public List<CameraStream> CameraStreams { get; set; }

        /// <summary>
        /// Basic constructor
        /// </summary>
        public InitializeCameraRequestPayload()
        {
            CameraStreams = new List<CameraStream>();
        }
    }
}
