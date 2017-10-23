
using Newtonsoft.Json;
using RKon.Alexa.NET.JsonObjects;

namespace RKon.Alexa.NET.Payloads
{
    /// <summary>
    /// Payload for Errors with REQUESTED_SETPOINTS_TOO_CLOSE type
    /// </summary>
    public class RequestedSetpointsTooCloseErrorPayload : ErrorPayload
    {
        /// <summary>
        /// Indicates the minimum allowable difference between setpoints
        /// </summary>
        [JsonProperty("minimumTemperatureDelta")]
        [JsonRequired]
        public Setpoint MinimumTemperatureDelta { get; set; }
    }
}
