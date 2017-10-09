using Newtonsoft.Json;

namespace RKon.Alexa.NET.Types.PayloadObjects
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
        public string Type { get; set; }
        /// <summary>
        /// The access Token
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
