using Newtonsoft.Json;
using RKon.Alexa.NET.JsonObjects;
using RKon.Alexa.NET.Request;
using System.Collections.Generic;

namespace RKon.Alexa.NET.Response.V3.Payloads
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
