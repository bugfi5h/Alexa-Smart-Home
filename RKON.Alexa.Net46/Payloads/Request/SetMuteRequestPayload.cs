using Newtonsoft.Json;
namespace RKon.Alexa.NET46.Payloads
{
    /// <summary>
    /// A request to mute or unmute an endpoint.
    /// </summary>
    public class SetMuteRequestPayload : Payload
    {
        /// <summary>
        /// true to indicate the endpoint should be muted. False to indicate that the endpoint should be unmuted.
        /// </summary>
        [JsonProperty("mute")]
        public bool Mute { get; set; }
    }
}
