using Newtonsoft.Json;
using RKon.Alexa.NET46.Types;

namespace RKon.Alexa.NET46.JsonObjects
{
    /// <summary>
    /// A capability is a polymorphic type. Currently, AlexaInterface is the only supported type of capability.
    /// </summary>
    [JsonConverter(typeof(Capabilities.CapabilityConverter))]
    public class Capability
    {
        /// <summary>
        ///  	Indicates the type of capability, which determines what fields the capability has.
        /// </summary>
        [JsonProperty("type")]
        [JsonRequired]
        public CapabilitiyTypes Type { get; set; }
    }
}
