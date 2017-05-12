using Newtonsoft.Json;


namespace RKon.Alexa.NET46.Types.PayloadObjects
{
    /// <summary>
    /// AchievedState für color changes.
    /// </summary>
    public class AchievedColorState
    {
        /// <summary>
        /// Colorresponse of the appliance. 
        /// </summary>
        [JsonProperty("color")]
        [JsonRequired]
        public Color Color { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public AchievedColorState()
        {
            Color = new Color();
        }

    }
}
