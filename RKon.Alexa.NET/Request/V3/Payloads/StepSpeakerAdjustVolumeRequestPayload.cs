﻿using Newtonsoft.Json;

namespace RKon.Alexa.NET.Request.V3.Payloads
{
    /// <summary>
    /// A Requestpayload for a relative volume adjustment. The AdjustVolume directive is always relative to the current volume setting and can be positive to increase volume, or negative to reduce volume.
    /// </summary>
    public class StepSpeakerAdjustVolumeRequestPayload : RequestPayload
    {
        /// <summary>
        /// A number that indicates how much the volume should be incremented or decremented. Ranging from -100 to 100.
        /// </summary>
        [JsonProperty("volumeSteps")]
        public int VolumeSteps { get; set; }
    }
}
