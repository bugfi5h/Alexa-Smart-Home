
using Newtonsoft.Json;
using RKon.Alexa.NET.Types.PayloadObjects;

namespace RKon.Alexa.NET.Response
{
    /// <summary>
    /// Payload für ColorTemperature Responses
    /// </summary>
    public class ColorTemperatureResponsePayload : ResponsePayload
    {
        /// <summary>
        /// Status des Geräts nach der Farbtemperaturänderung 
        /// </summary>
        [JsonProperty("achievedState")]
        [JsonRequired]
        public AchievedColorTemperatureState AchievedState { get; set; }

        /// <summary>
        /// Konstruktor. Initialisiert alle Properties.
        /// </summary>
        public ColorTemperatureResponsePayload()
        {
            AchievedState = new AchievedColorTemperatureState();
        }
    }
}
