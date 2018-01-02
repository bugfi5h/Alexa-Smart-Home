using Newtonsoft.Json;
using RKon.Alexa.NET.Types;

namespace RKon.Alexa.NET.JsonObjects
{
    /// <summary>
    /// Currently, the only supported descendant is the BearerToken type. BearerToken contains a single attribute, token, which contains the customer access token received by Alexa from the account linking process and identifies the customer in your system.
    /// </summary>
    public class BearerToken : Grantee
    {
        /// <summary>
        /// The access Token
        /// </summary>
        [JsonProperty("token")]
        [JsonRequired]
        public string Token { get; set; }

        /// <summary>
        /// Basic construcotr. Sets Type to scopetype
        /// </summary>
        public BearerToken()
        {
            Type = ScopeTypes.BearerToken;
        }
    }
}
