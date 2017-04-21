using Newtonsoft.Json;


namespace RKon.Alexa.NET.Types.PayloadObjects
{
    /// <summary>
    /// Zustand des Geräts nach Wechseln der Farbe durch double wert
    /// </summary>
    public class AchievedColorTemperatureState
    {
        /// <summary>
        /// Farbwert nach Schaltung
        /// </summary>
        [JsonRequired]
        [JsonProperty("colorTemperature")]
        public ColorTemperature colorTemperature { get; set; }

        /// <summary>
        /// Konstruktor
        /// </summary>
        public AchievedColorTemperatureState()
        {
            colorTemperature = new ColorTemperature();
        }
    }
}
