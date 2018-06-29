using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RKon.Alexa.NET46.Types;

namespace RKon.Alexa.NET46.JsonObjects
{
    /// <summary>
    /// Contains the desired thermostat mode for the device. Supported values: “AUTO”, “COOL”, “ECO”, “HEAT” and “OFF”
    /// </summary>
    public class ThermoMode
    {
        /// <summary>
        /// Indicates the desired thermostat mode for the device. Supported values: “AUTO”, “COOL”, “ECO”, “HEAT” and “OFF”
        /// </summary>
        [JsonProperty("value")]
        public ThermostatModes Value { get; set; }

        /// <summary>
        ///  	String indicating a custom mode or friendly name specific to the endpoint or manufacturer. customName is required when value is set to CUSTOM, optional otherwise.
        /// </summary>
        [JsonProperty("customName", NullValueHandling=NullValueHandling.Ignore)]
        public string CustomName { get; set; }
    }
}
