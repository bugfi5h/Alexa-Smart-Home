
using Newtonsoft.Json;
using RKon.Alexa.NET46.Types;

namespace RKon.Alexa.NET46.Payloads
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
        public ErrorTypes Type { get; set; }

        /// <summary>
        /// String that provides more information about the error for logging purposes. This information is not shared with the customer.
        /// </summary>
        [JsonProperty("message")]
        [JsonRequired]
        public string Message { get; set; }
    }
}
