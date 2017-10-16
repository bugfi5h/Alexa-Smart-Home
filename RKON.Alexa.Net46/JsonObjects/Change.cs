using Newtonsoft.Json;
using System.Collections.Generic;

namespace RKon.Alexa.NET46.JsonObjects
{
    /// <summary>
    /// Payloaobject of a Changereport
    /// </summary>
    public class Change
    {
        /// <summary>
        /// Specifies the cause of the change
        /// </summary>
        [JsonProperty("cause")]
        [JsonRequired]
        public Cause Cause { get; set; }

        /// <summary>
        /// Contains an array of property objects that caused the change report to be sent.
        /// </summary>
        [JsonProperty("properties")]
        [JsonRequired]
        public List<Property> Properties { get; set; }

        /// <summary>
        /// Initializes Properties List
        /// </summary>
        public Change()
        {
            Properties = new List<Property>();
        }
    }
}
