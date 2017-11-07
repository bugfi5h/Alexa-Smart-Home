using Newtonsoft.Json;
using RKon.Alexa.NET46.Types;

namespace RKon.Alexa.NET46.Payloads
{
    /// <summary>
    /// Payload for a SetColorTemperatureRequest
    /// </summary>
    public class SetColorTemperatureRequestPayload : Payload
    {
        /// <summary>
        /// An integer that indicates the requested color temperature in Kelvin degrees. Valid range is 1000 to 10000, inclusive
        /// </summary>
        [JsonProperty(PropertyNames.COLOR_TEMPERATURE_IN_KELVIN)]
        public int ColorTemperatureInKelvin { get; set; }
    }
}
