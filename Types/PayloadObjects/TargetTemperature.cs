using Newtonsoft.Json;

namespace RKon.Alexa.NET.Types.PayloadObjects
{
    /// <summary>
    /// Klasse für Temperaturwert
    /// </summary>
    public class TargetTemperature
    {
        /// <summary>
        /// Wert
        /// </summary>
        [JsonRequired]
        [JsonProperty("value")]
        public double Value { get; set; }
    }
}
