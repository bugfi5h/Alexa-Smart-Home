using Newtonsoft.Json;
using RKon.Alexa.NET46.JsonObjects.Scopes;
using System.Collections.Generic;

namespace RKon.Alexa.NET46.JsonObjects
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
        [JsonProperty("cookie", NullValueHandling =NullValueHandling.Ignore)]
        public Dictionary<string,string> Cookie { get; set; }

        /// <summary>
        /// Standardconstructor
        /// </summary>
        public Endpoint()
        {
        }

        /// <summary>
        /// Initialises Endpoint with Values
        /// </summary>
        /// <param name="id"></param>
        /// <param name="scope"></param>
        /// <param name="cookies"></param>
        public Endpoint(string id, Scope scope, Dictionary<string, string> cookies = null)
        {
            Scope = scope;
            EndpointID = id;
            Cookie = cookies;
        }
    }
}
