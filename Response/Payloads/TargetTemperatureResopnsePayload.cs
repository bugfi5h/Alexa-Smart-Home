
using RKon.Alexa.NET.Types.PayloadObjects;
using Newtonsoft.Json;


namespace RKon.Alexa.NET.Response.Payloads
{
    /// <summary>
    /// Payload für TargetTemperatureResponse
    /// </summary>
    public class TargetTemperatureResopnsePayload : ResponsePayload
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
        public TargetTemperatureResopnsePayload()
        {
            PreviousState = new PreviousState();
            TemperatureMode = new TemperatureMode();
            TargetTemperature = new TargetTemperature();
        }
    }
}
