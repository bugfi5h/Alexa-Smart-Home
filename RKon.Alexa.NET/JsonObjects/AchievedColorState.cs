using Newtonsoft.Json;
using RKon.Alexa.NET.Types;

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
        [JsonProperty(PropertyNames.COLOR)]
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
