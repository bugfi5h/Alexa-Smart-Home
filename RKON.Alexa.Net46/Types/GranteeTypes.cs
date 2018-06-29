using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RKon.Alexa.NET46.Types
{
    /// <summary>
    /// Grantee Types
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GranteeTypes
    {
        /// <summary>
        /// Currently, the only supported child type for grantee
        /// </summary>
        BearerToken
    }
}
