using Newtonsoft.Json;
using RKon.Alexa.NET46.Types.PayloadObjects;

namespace RKon.Alexa.NET46.Response
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
