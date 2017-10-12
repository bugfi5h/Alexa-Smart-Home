using Newtonsoft.Json;
using RKon.Alexa.NET.JsonObjects;

namespace RKon.Alexa.NET.Response
{
    /// <summary>
    /// Payload for a SetColorResponse
    /// </summary>
    public class SetColorResponsePayload : ResponsePayload
    {
        /// <summary>
        /// Status of the appliance after a color change
        /// </summary>
        [JsonProperty("achievedState")]
        [JsonRequired]
        public AchievedColorState AchievedState { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public SetColorResponsePayload()
        {
            AchievedState = new AchievedColorState();
        }
    }
}
