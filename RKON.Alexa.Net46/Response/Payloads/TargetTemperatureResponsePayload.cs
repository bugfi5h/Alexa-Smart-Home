using RKon.Alexa.NET46.Types;
using Newtonsoft.Json;


namespace RKon.Alexa.NET46.Response
{
    /// <summary>
    /// Payload for a TargetTemperatureResponse
    /// </summary>
    public class TargetTemperatureResponsePayload : ResponsePayload
    {
        /// <summary>
        /// Target temperature to set
        /// </summary>
        [JsonRequired]
        [JsonProperty("targetTemperature")]
        public TargetTemperature TargetTemperature { get; set; }
        /// <summary>
        /// temperature mode
        /// </summary>
        [JsonRequired]
        [JsonProperty("temperatureMode")]
        public TemperatureMode TemperatureMode { get; set; }
        /// <summary>
        /// previous temperature mode
        /// </summary>
        [JsonRequired]
        [JsonProperty("previousState")]
        public PreviousState PreviousState { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public TargetTemperatureResponsePayload()
        {
            PreviousState = new PreviousState();
            TemperatureMode = new TemperatureMode();
            TargetTemperature = new TargetTemperature();
        }
    }
}
