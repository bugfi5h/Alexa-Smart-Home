
using Newtonsoft.Json;

namespace RKon.Alexa.NET46.JsonObjects.Scopes
{
    /// <summary>
    /// Provides an OAuth bearer token for accessing a linked customer account and the physical location where the discovery request should be applied
    /// </summary>
    public class BearerTokenWithPartition : Scope
    {
        /// <summary>
        /// The token for identifying and accessing a linked customer account.
        /// </summary>
        [JsonProperty("token")]
        [JsonRequired]
        public string Token { get; set; }
        /// <summary>
        /// The location target for the request such as a room name or number.
        /// </summary>
        [JsonProperty("partition")]
        [JsonRequired]
        public string Partition { get; set; }
        /// <summary>
        /// A unique identifier for the user who made the request. You should not rely on userId for identification of a customer. Use token instead.
        /// </summary>
        [JsonProperty("userId")]
        [JsonRequired]
        public string UserId { get; set; }

        /// <summary>
        /// Basic Constructor
        /// </summary>
        public BearerTokenWithPartition()
        {
            Type = Types.ScopeTypes.BearerTokenWithPartition;
        }

        /// <summary>
        /// Constructor with initialisation
        /// </summary>
        /// <param name="token"></param>
        /// <param name="partition"></param>
        /// <param name="userid"></param>
        public BearerTokenWithPartition(string token, string partition, string userid)
        {
            Type = Types.ScopeTypes.BearerTokenWithPartition;
            Token = token;
            Partition = partition;
            UserId = userid;
        }
    }
}
