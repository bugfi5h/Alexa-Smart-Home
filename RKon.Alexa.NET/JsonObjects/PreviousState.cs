using Newtonsoft.Json;


namespace RKon.Alexa.NET.JsonObjects
{
    /// <summary>
    /// Class for the last Temperature status
    /// </summary>
    public class PreviousState
    {
        /// <summary>
        /// Target Temperature
        /// </summary>
        [JsonRequired]
        [JsonProperty("targetTemperature")]
        public TargetTemperature TargetTemperature { get; set; }
        /// <summary>
        /// Temperaturemode
        /// </summary>
        [JsonRequired]
        [JsonProperty("mode")]
        public TemperatureMode Mode { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        public PreviousState()
        {
            Mode = new TemperatureMode();
            TargetTemperature = new TargetTemperature();
        }
    }
}
