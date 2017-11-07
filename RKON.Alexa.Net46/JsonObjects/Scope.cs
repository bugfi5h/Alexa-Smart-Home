using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RKon.Alexa.NET46.Types;

namespace RKon.Alexa.NET46.JsonObjects
{
    /// <summary>
    /// Contains the Tokentype and the accesstoken
    /// </summary>
    public class Scope
    {
        /// <summary>
        /// The Type of the Scope
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ScopeTypes Type { get; set; }
        /// <summary>
        /// The access Token
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }

        /// <summary>
        /// Standartconstructor
        /// </summary>
        public Scope()
        {

        }

        /// <summary>
        /// Initializes Scope
        /// </summary>
        /// <param name="type"></param>
        /// <param name="token"></param>
        public Scope(ScopeTypes type, string token)
        {
            Type = type;
            Token = token;
        }
    }
}
