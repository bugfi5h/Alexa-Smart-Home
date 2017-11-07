using Newtonsoft.Json;
using RKon.Alexa.NET46.JsonObjects;

namespace RKon.Alexa.NET46.Payloads
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
    }
}
