using Newtonsoft.Json;


namespace RKon.Alexa.NET.Types.PayloadObjects
{
    /// <summary>
    /// AchievedState für Farbänderungen. Sollte es nicht möglich sein, die Werte auszulesen können die Werte aus dem Request genommen werden.
    /// </summary>
    public class AchievedColorState
    {
        /// <summary>
        /// Farbantwort nach setzen der Farbänderung. 
        /// </summary>
        [JsonProperty("color")]
        [JsonRequired]
        public Color Color { get; set; }

        /// <summary>
        /// Konstruktor
        /// </summary>
        public AchievedColorState()
        {
            Color = new Color();
        }

    }
}
