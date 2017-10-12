
using Newtonsoft.Json;
using RKon.Alexa.NET.JsonObjects;

namespace RKon.Alexa.NET.Response
{
    /// <summary>
    /// Payload for ColorTemperature Responses
    /// </summary>
    public class ColorTemperatureResponsePayload : ResponsePayload
    {
        /// <summary>
        /// Status of the appliance after the color change 
        /// </summary>
        [JsonProperty("achievedState")]
        [JsonRequired]
        public AchievedColorTemperatureState AchievedState { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ColorTemperatureResponsePayload()
        {
            AchievedState = new AchievedColorTemperatureState();
        }
    }
}
