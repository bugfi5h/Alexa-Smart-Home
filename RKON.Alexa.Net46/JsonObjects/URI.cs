using Newtonsoft.Json;

namespace RKon.Alexa.NET46.JsonObjects
{
    /// <summary>
    /// Uri Jsonobject
    /// </summary>
    public class URI
    {
        /// <summary>
        /// String Value of the URL
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
