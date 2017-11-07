using Newtonsoft.Json;
using RKon.Alexa.NET46.JsonObjects;
using System.Collections.Generic;

namespace RKon.Alexa.NET46.Response
{
    /// <summary>
    /// Context Jsonobject
    /// </summary>
    public class Context
    {
        /// <summary>
        /// List of Properties
        /// </summary>
        [JsonProperty("properties")]
        public List<Property> Properties { get; set; }
        /// <summary>
        /// Basic contructor
        /// </summary>
        public Context()
        {
            Properties = new List<Property>();
        }
    }
}
