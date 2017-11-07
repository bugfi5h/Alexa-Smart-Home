using Newtonsoft.Json;
using RKon.Alexa.NET46.Types;

namespace RKon.Alexa.NET46.Payloads
{
    /// <summary>
    /// Requestpayload to set volume to the specified value, which is the absolute volume level scaled from 0 to 100.
    /// </summary>
    public class SetVolumeRequestPayload :Payload
    {
        /// <summary>
        /// An integer that indicates the requested volume, scaled from 0, the minimum volume, to 100, which is the maximum volume.
        /// </summary>
        [JsonProperty(PropertyNames.VOLUME)]
        public int Volume { get; set; }
    }
}
