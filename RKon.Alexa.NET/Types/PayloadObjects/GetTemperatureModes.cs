using Newtonsoft.Json;



namespace RKon.Alexa.NET.Types
{
    /// <summary>
    /// Klasse für GetTemperature Modi
    /// </summary>
    public class GetTemperatureMode
    {
        /// <summary>
        /// Wert
        /// </summary>
        [JsonRequired]
        [JsonProperty("value")]
        public string Value { get; private set; }

        /// <summary>
        /// Muss existieren, wenn der TemperatureMode auf Custom gestellt wird.
        /// </summary>
        [JsonProperty("friendlyName", NullValueHandling = NullValueHandling.Ignore)]
        public string FriendlyName { get; private set; }

        /// <summary>
        /// Konsturktor setzt Wert auf AUTO
        /// </summary>
        public GetTemperatureMode()
        {
            Value = DeviceModes.AUTO;
        }

        /// <summary>
        /// Setzt den Wert auf mode wenn möglich. Gültige Eingaben finden Sie im Namespace RKon.Alexa.Net.Types.DeviceModes
        /// Bei Fehlschlag wird AUTO eingestellt. friendlyName kann Null sein, aussßer im Modus Custom
        /// /// </summary>
        /// <param name="mode">Einzustellender Modus</param>
        /// <param name="friendlyName">Beschreibung des Modus</param>
        /// <returns>True bei Wertänderung</returns>
        public bool TrySetTemperatureMode(string mode, string friendlyName)
        {
            bool success = true;
            if (DeviceModes.GetTemperatureModes.Contains(mode))
            {
                Value = mode;
                FriendlyName = friendlyName;
            }
            else
            {
                success = false;
            }
            if(!success || (Value == DeviceModes.CUSTOM && FriendlyName == null))
            {
                Value = DeviceModes.AUTO;
            }
            return success;
        }
    }
}
