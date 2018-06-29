
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RKon.Alexa.NET46.Types
{
    /// <summary>
    /// Supported Types of Scopes
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ScopeTypes
    {
        /// <summary>
        /// Provides an OAuth bearer token for accessing a linked customer account or identifying an Alexa customer.
        /// </summary>
        BearerToken,
        /// <summary>
        /// Provides an OAuth bearer token for accessing a linked customer account and the physical location where the discovery request should be applied
        /// </summary>
        BearerTokenWithPartition
    }
}
