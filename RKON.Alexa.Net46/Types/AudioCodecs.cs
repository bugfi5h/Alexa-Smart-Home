using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RKon.Alexa.NET46.Types
{
    /// <summary>
    /// The audio code for the stream
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AudioCodecs
    {
        /// <summary>
        /// 
        /// </summary>
        G711,
        /// <summary>
        /// 
        /// </summary>
        AAC,
        /// <summary>
        /// 
        /// </summary>
        NONE
    }
}
