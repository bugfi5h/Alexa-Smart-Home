using Newtonsoft.Json;
using RKon.Alexa.NET.JsonObjects;

namespace RKon.Alexa.NET.Payloads
{
    /// <summary>
    /// Payload for ThemostadModeRequests
    /// </summary>
    public class SetThermostadModeRequestPayload : Payload
    {
        /// <summary>
        /// Used for properties that represent the mode of a thermostat.
        /// </summary>
        [JsonProperty("thermostatMode")]
        public ThermoMode ThermostatMode { get; set; }

        /// <summary>
        /// String indicating a custom mode or friendly name specific to the endpoint or manufacturer. Is required when value is set to CUSTOM, optional otherwise.
        /// </summary>
        [JsonProperty("customName", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomName { get; set; }
    }
}
