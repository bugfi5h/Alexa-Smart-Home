using Newtonsoft.Json;

namespace RKon.Alexa.NET46.Request.RequestPayloads
{
    /// <summary>
    /// These message types query a camera and return a stream URI. 
    /// </summary>
    public class RetrieveCameraStreamUriRequestPayload : RequestPayloadWithAppliance
    {
        /// <summary>
        /// Obfuscated customer identifier associated with an internal Amazon customer ID.
        /// You can store this identifier and use it when interacting with Amazon services which require a customer ID. 
        /// </summary>
        [JsonProperty("directedId")]
        public string DirectedId { get; set; }
    }
}
