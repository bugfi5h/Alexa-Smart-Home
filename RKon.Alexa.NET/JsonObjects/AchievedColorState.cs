using Newtonsoft.Json;


namespace RKon.Alexa.NET.JsonObjects
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
