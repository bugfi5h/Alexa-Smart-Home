using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RKon.Alexa.NET.Types;

namespace RKon.Alexa.NET.JsonObjects.Scopes
{
    /// <summary>
    /// Contains the Tokentype and the accesstoken
    /// </summary>
    [JsonConverter(typeof(ScopeConverter))]
    public class Scope
    {
        /// <summary>
        /// The Type of the Scope
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ScopeTypes Type { get; set; }
        
        /// <summary>
        /// Standartconstructor
        /// </summary>
        public Scope()
        {
        }
    }
}
