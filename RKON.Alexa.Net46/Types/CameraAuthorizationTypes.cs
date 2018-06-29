using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RKon.Alexa.NET46.Types
{
    /// <summary>
    /// Describes the authorization type. 
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CameraAuthorizationTypes
    {
        /// <summary>
        /// 
        /// </summary>
        BASIC,
        /// <summary>
        /// 
        /// </summary>
        DIGEST,
        /// <summary>
        /// 
        /// </summary>
        NONE,
        /// <summary>
        /// Needed? Is in the official sample messages
        /// </summary>
        BEARER
    }
}
