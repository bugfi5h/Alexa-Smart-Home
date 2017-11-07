
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RKon.Alexa.NET.Types;

namespace RKon.Alexa.NET.Payloads
{
    /// <summary>
    /// Basispayload for Errorresponses
    /// </summary>
    public class ErrorPayload : Payload
    {
        /// <summary>
        /// One of the accepted type values that indicates the kind of error that has occurred. Alexa uses this attribute to respond to the customer appropriately.
        /// </summary>
        [JsonProperty("type")]
        [JsonRequired]
        [JsonConverter(typeof(StringEnumConverter))]
        public ErrorTypes Type { get; set; }

        /// <summary>
        /// String that provides more information about the error for logging purposes. This information is not shared with the customer.
        /// </summary>
        [JsonProperty("message")]
        [JsonRequired]
        public string Message { get; set; }
    }
}
