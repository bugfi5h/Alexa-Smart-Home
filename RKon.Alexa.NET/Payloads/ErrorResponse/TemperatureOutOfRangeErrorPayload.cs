using Newtonsoft.Json;
using RKon.Alexa.NET.JsonObjects;
namespace RKon.Alexa.NET.Payloads
{
    /// <summary>
    /// Payload for TemperatureOutOfRange Errors
    /// </summary>
    public class TemperatureOutOfRangeErrorPayload : ErrorPayload
    {
        /// <summary>
        /// Max and min value of the device
        /// </summary>
        [JsonProperty("validRange", NullValueHandling = NullValueHandling.Ignore)]
        public TemperatureValidRange ValidRange { get; set; }
    }
}
