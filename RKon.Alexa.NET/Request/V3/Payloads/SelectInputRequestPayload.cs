using Newtonsoft.Json;
using RKon.Alexa.NET.Types;

namespace RKon.Alexa.NET.Request.V3.Payloads
{
    /// <summary>
    /// Requestpayload to change to the input or input device.
    /// </summary>
    public class SelectInputRequestPayload : RequestPayload
    {
        /// <summary>
        /// The identifier for the input device the customer requested
        /// </summary>
        [JsonProperty(PropertyNames.INPUT)]
        public string Input { get; set; }
    }
}
