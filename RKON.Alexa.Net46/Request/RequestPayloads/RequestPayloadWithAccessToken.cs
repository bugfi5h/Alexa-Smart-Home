using Newtonsoft.Json;


namespace RKon.Alexa.NET46.Request.RequestPayloads
{
    /// <summary>
    /// Abstract base class for payloads with accessToken
    /// </summary>
    public abstract class RequestPayloadWithAccessToken : RequestPayload
    {
        /// <summary>
        /// Access Token
        /// </summary>
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
    }
}
