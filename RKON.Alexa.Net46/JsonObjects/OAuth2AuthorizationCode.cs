using Newtonsoft.Json;
using RKon.Alexa.NET46.Types;

namespace RKon.Alexa.NET46.JsonObjects
{
    /// <summary>
    /// The only supported descendant for grant is type OAuth2.AuthorizationCode, which provides a code property that specifies an OAuth2 authorization code.
    /// </summary>
    public class OAuth2AuthorizationCode : Grant
    {
        /// <summary>
        /// Auth code
        /// </summary>
        [JsonProperty("code")]
        [JsonRequired]
        public string Code { get; set; }

        /// <summary>
        /// Basic constructor. Sets Type to Oauth_Auhorizationcode
        /// </summary>
        public OAuth2AuthorizationCode()
        {
            Type = GrantTypes.OAUTH_AUTHORIZATIONCODE;
        }
    }
}
