using Newtonsoft.Json;
using RKon.Alexa.NET46.Types;

namespace RKon.Alexa.NET46.JsonObjects.Scopes
{
    /// <summary>
    /// Scope Type BearerToken
    /// </summary>
    public class BearerToken : Scope
    {
        /// <summary>
        /// The access Token
        /// </summary>
        [JsonProperty("token")]
        [JsonRequired]
        public string Token { get; set; }

        /// <summary>
        /// Basic Constructor
        /// </summary>
        public BearerToken()
        {
            Type = ScopeTypes.BearerToken;
        }
        /// <summary>
        /// Initializes Scope
        /// </summary>
        /// <param name="token"></param>
        public BearerToken(string token)
        {
            Type = ScopeTypes.BearerToken;
            Token = token;
        }
    }
}
