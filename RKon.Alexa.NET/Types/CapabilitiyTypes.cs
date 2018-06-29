
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RKon.Alexa.NET.Types
{
    /// <summary>
    /// Types of Capability
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CapabilitiyTypes
    {
        /// <summary>
        /// Only supported Capability at the moment
        /// </summary>
        AlexaInterface
    }
}
