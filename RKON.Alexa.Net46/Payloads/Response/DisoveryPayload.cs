using Newtonsoft.Json;
using RKon.Alexa.NET46.JsonObjects;
using System.Collections.Generic;

namespace RKon.Alexa.NET46.Payloads.Response
{
    /// <summary>
    /// Discoverypayload for response event
    /// </summary>
    public class DisoveryPayload : Payload
    {
        /// <summary>
        /// Discovered Endpoints
        /// </summary>
        [JsonProperty("endpoints")]
        [JsonRequired]
        public List<ResponseEndpoint> Endpoints { get; set; }

        /// <summary>
        /// Standartconstructor
        /// </summary>
        public DisoveryPayload()
        {
            Endpoints = new List<ResponseEndpoint>();
        }
    }
}
