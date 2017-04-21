using Newtonsoft.Json;


namespace RKon.Alexa.NET.Types
{
    /// <summary>
    /// Klasse für letzten Temperaturstatus
    /// </summary>
    public class PreviousState
    {
        /// <summary>
        /// Zieltemperatur
        /// </summary>
        [JsonRequired]
        [JsonProperty("targetTemperature")]
        public TargetTemperature TargetTemperature { get; set; }
        /// <summary>
        /// Temperaturmodus
        /// </summary>
        [JsonRequired]
        [JsonProperty("mode")]
        public TemperatureMode Mode { get; set; }
        /// <summary>
        /// Konstruktor
        /// </summary>
        public PreviousState()
        {
            Mode = new TemperatureMode();
            TargetTemperature = new TargetTemperature();
        }
    }
}
