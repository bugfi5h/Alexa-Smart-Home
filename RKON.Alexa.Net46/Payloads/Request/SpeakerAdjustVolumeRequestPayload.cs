using Newtonsoft.Json;

namespace RKon.Alexa.NET46.Payloads
{
    /// <summary>
    /// A request to perform a relative volume adjustment. A positive value increases the value, a negative value reduces the volume.
    /// </summary>
    public class SpeakerAdjustVolumeRequestPayload : SetVolumeRequestPayload
    {
        /// <summary>
        /// A flag that indicates whether the value in the volume field was explicitly specified by the user. If false, the value was explicitly specified by the user. If true, the value is a default value.
        /// </summary>
        [JsonProperty("volumeDefault")]
        public bool VolumeDefault { get; set; }
    }
}
