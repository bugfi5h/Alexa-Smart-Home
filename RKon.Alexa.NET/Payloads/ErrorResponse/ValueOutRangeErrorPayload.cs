using Newtonsoft.Json;
using RKon.Alexa.NET.JsonObjects;

namespace RKon.Alexa.NET.Payloads
{
    /// <summary>
    /// Payload for ValueOutRange Errors
    /// </summary>
    public class ValueOutRangeErrorPayload : ErrorPayload
    {
        /// <summary>
        /// Max and min value of the device
        /// </summary>
        [JsonProperty("validRange",NullValueHandling=NullValueHandling.Ignore)]
        public ValidRange ValidRange { get; set; }
    }
}
