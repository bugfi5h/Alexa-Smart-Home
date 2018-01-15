using Newtonsoft.Json;

namespace RKon.Alexa.NET46.JsonObjects
{
    /// <summary>
    ///  	A polymorphic type that provides identifying information for a customer in Amazon Alexa systems.
    /// </summary>
    public class Grant
    {
        /// <summary>
        /// Provides the type of grant specified, which determines the other fields for this object.
        /// </summary>
        [JsonProperty("type")]
        [JsonRequired]
        public string Type { get; set; }
    }
}
