using Newtonsoft.Json;
using RKon.Alexa.NET.JsonObjects;

namespace RKon.Alexa.NET.Request.V3.Payloads
{
    /// <summary>
    /// Payload for SetTargetTemperature requests.
    /// </summary>
    public class SetTargetTemperatureRequestPayload : RequestPayload
    {
        /// <summary>
        /// Indicates the target temperature to set on the device. Sent for single and triple mode thermostats.
        /// </summary>
        [JsonProperty("targetSetpoint", NullValueHandling =NullValueHandling.Ignore)]
        public Setpoint TargetSetpoint { get; set; }
        /// <summary>
        /// Indicates the lower temperature setpoint for the device. temperature. Sent for dual and triple setpoint temperature modes.
        /// </summary>
        [JsonProperty("lowerSetpoint", NullValueHandling = NullValueHandling.Ignore)]
        public Setpoint LowerSetpoint { get; set; }
        /// <summary>
        /// Indicates the upper temperature setpoint for the device. Sent for dual and triple setpoint temperature modes
        /// </summary>
        [JsonProperty("upperSetpoint", NullValueHandling = NullValueHandling.Ignore)]
        public Setpoint UpperSetpoint { get; set; }
    }
}
