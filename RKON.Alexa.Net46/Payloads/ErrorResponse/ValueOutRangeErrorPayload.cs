using Newtonsoft.Json;
using RKon.Alexa.NET46.JsonObjects;

namespace RKon.Alexa.NET46.Payloads
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
