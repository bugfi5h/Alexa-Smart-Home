using Newtonsoft.Json;
using RKon.Alexa.NET46.JsonObjects;

namespace RKon.Alexa.NET46.Payloads
{
    /// <summary>
    /// Payload for AdjustTargetTemperature Requests
    /// </summary>
    public class AdjustTargetTemperatureRequestPayload : Payload
    {
        /// <summary>
        /// Indicates the temperature adjustment value to a single setpoint. Positive and negative temperature values indicate a directive to increase or decrease the target setpoint, respectively.
        /// </summary>
        [JsonProperty("targetSetpointDelta")]
        public Setpoint TargetSetpointDelta { get; set; }
    }
}
