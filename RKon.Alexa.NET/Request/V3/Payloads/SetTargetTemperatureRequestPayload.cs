using Newtonsoft.Json;
using RKon.Alexa.NET.JsonObjects;
using RKon.Alexa.NET.Types;

namespace RKon.Alexa.NET.Request.V3.Payloads
{
    /// <summary>
    /// Payload for SetTargetTemperature requests.
    /// </summary>
    public class SetTargetTemperatureRequestPayload : Payload
    {
        /// <summary>
        /// Indicates the target temperature to set on the device. Sent for single and triple mode thermostats.
        /// </summary>
        [JsonProperty(PropertyNames.TARGET_SETPOINT, NullValueHandling =NullValueHandling.Ignore)]
        public Setpoint TargetSetpoint { get; set; }
        /// <summary>
        /// Indicates the lower temperature setpoint for the device. temperature. Sent for dual and triple setpoint temperature modes.
        /// </summary>
        [JsonProperty(PropertyNames.LOWER_SETPOINT, NullValueHandling = NullValueHandling.Ignore)]
        public Setpoint LowerSetpoint { get; set; }
        /// <summary>
        /// Indicates the upper temperature setpoint for the device. Sent for dual and triple setpoint temperature modes
        /// </summary>
        [JsonProperty(PropertyNames.UPPER_SETPOINT, NullValueHandling = NullValueHandling.Ignore)]
        public Setpoint UpperSetpoint { get; set; }
    }
}
