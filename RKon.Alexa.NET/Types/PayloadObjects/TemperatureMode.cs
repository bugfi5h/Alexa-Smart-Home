using Newtonsoft.Json;


namespace RKon.Alexa.NET.Types
{
    /// <summary>
    /// Klasse für Temperatur Modus
    /// </summary>
    public class TemperatureMode
    {
        /// <summary>
        /// Wert
        /// </summary>
        [JsonRequired]
        [JsonProperty("value")]
        public string Value { get; private set; }
        /// <summary>
        /// Konsturktor setzt Wert auf AUTO
        /// </summary>
        public TemperatureMode()
        {
            Value = DeviceModes.AUTO;
        }

        /// <summary>
        /// Setzt den Wert auf mode wenn möglich. Gültige Eingaben finden Sie im Namespace RKon.Alexa.Net.Types.DeviceModes
        /// Bei Fehlschlag wird AUTO eingestellt
        /// </summary>
        /// <param name="mode">Einzustellender Modus</param>
        /// <returns>True bei Wertänderung</returns>
        public bool TrySetTemperatureMode(string mode)
        {
            bool success = true;
            if (DeviceModes.TemperatureModes.Contains(mode))
            {
                Value = mode;
            }
            else
            {
                Value = DeviceModes.AUTO;
                success = false;
            }
            return success;
        }
    }
}
