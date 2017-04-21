
using RKon.Alexa.NET.Types;
using Newtonsoft.Json;


namespace RKon.Alexa.NET.Response
{
    /// <summary>
    /// Payload für TargetTemperatureResponse
    /// </summary>
    public class TargetTemperatureResponsePayload : ResponsePayload
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
        [JsonProperty("temperatureMode")]
        public TemperatureMode TemperatureMode { get; set; }
        /// <summary>
        /// Letzter Zustand
        /// </summary>
        [JsonRequired]
        [JsonProperty("previousState")]
        public PreviousState PreviousState { get; set; }

        /// <summary>
        /// Konstruktor. Initialisiert alle Properties.
        /// </summary>
        public TargetTemperatureResponsePayload()
        {
            PreviousState = new PreviousState();
            TemperatureMode = new TemperatureMode();
            TargetTemperature = new TargetTemperature();
        }
    }
}
