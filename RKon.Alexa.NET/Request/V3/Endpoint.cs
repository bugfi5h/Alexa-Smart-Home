using Newtonsoft.Json;
using RKon.Alexa.NET.JsonObjects;
using System.Collections.Generic;

namespace RKon.Alexa.NET.Request.V3
{
    /// <summary>
    /// Enpoint Element for directives
    /// </summary>
    public class Endpoint
    {
        /// <summary>
        /// The scope of the endpoint
        /// </summary>
        [JsonProperty("scope")]
        public Scope Scope { get; set; }

        /// <summary>
        /// The ID of the endpoint
        /// </summary>
        [JsonProperty("endpointId")]
        public string EndpointID { get; set; }

        /// <summary>
        /// Additional Informations
        /// </summary>
        [JsonProperty("cookie")]
        public Dictionary<string,string> Cookie { get; set; }

        /// <summary>
        /// Standardconstructor
        /// </summary>
        public Endpoint()
        {
            Cookie = new Dictionary<string, string>();
        }
    }
}
