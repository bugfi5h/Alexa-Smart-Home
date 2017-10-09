using Newtonsoft.Json;
using RKon.Alexa.NET.Types.PayloadObjects;

namespace RKon.Alexa.NET.Request.V3.Payloads
{
    /// <summary>
    /// Payload for AdjustTargetTemperature Requests
    /// </summary>
    public class AdjustTargetTemperatureRequestPayload : RequestPayload
    {
        /// <summary>
        /// Indicates the temperature adjustment value to a single setpoint. Positive and negative temperature values indicate a directive to increase or decrease the target setpoint, respectively.
        /// </summary>
        [JsonProperty("targetSetpointDelta")]
        public Setpoint TargetSetpointDelta { get; set; }
    }
}
