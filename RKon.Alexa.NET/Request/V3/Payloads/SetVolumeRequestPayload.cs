using Newtonsoft.Json;
using RKon.Alexa.NET.Types;

namespace RKon.Alexa.NET.Request.V3.Payloads
{
    /// <summary>
    /// Requestpayload to set volume to the specified value, which is the absolute volume level scaled from 0 to 100.
    /// </summary>
    public class SetVolumeRequestPayload :RequestPayload
    {
        /// <summary>
        /// An integer that indicates the requested volume, scaled from 0, the minimum volume, to 100, which is the maximum volume.
        /// </summary>
        [JsonProperty(PropertyNames.VOLUME)]
        public int Volume { get; set; }
    }
}
