using Newtonsoft.Json;


namespace RKon.Alexa.NET.Request.RequestPayloads
{
    /// <summary>
    /// Abstract base class for payloads with AccessToken and Appliance
    /// </summary>
    public abstract class RequestPayloadWithAppliance : RequestPayloadWithAccessToken
    {
        /// <summary>
        /// The appliance
        /// </summary>
        [JsonProperty("appliance")]
        public RequestAppliance Appliance { get; set; }
    }
}
