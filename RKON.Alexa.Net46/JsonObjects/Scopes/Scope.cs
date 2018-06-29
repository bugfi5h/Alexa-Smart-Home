using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RKon.Alexa.NET46.Types;

namespace RKon.Alexa.NET46.JsonObjects.Scopes
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
        public ScopeTypes Type { get; set; }
        
        /// <summary>
        /// Standartconstructor
        /// </summary>
        public Scope()
        {
        }
    }
}
