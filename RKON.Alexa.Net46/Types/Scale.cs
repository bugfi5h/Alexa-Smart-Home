using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RKon.Alexa.NET46.Types
{
    /// <summary>
    /// Indicates the temperature scale for the temperature value
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Scale
    {
        /// <summary>
        /// °C
        /// </summary>
        CELSIUS,
        /// <summary>
        /// °F
        /// </summary>
        FAHRENHEIT,
        /// <summary>
        /// °K
        /// </summary>
        KELVIN
    }
}
