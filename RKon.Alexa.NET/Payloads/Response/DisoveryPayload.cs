using Newtonsoft.Json;
using RKon.Alexa.NET.JsonObjects;
using System.Collections.Generic;

namespace RKon.Alexa.NET.Payloads
{
    /// <summary>
    /// Discoverypayload for response event
    /// </summary>
    public class DiscoveryPayload : Payload
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
        public DiscoveryPayload()
        {
            Endpoints = new List<ResponseEndpoint>();
        }
    }
}
