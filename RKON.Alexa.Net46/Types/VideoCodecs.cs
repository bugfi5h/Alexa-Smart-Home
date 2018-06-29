using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RKon.Alexa.NET46.Types
{
    /// <summary>
    /// The video codec for the stream.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum VideoCodecs
    {
        /// <summary>
        /// 
        /// </summary>
        H264,
        /// <summary>
        /// 
        /// </summary>
        MPEG2,
        /// <summary>
        /// 
        /// </summary>
        MJPEG,
        /// <summary>
        /// 
        /// </summary>
        JPG
    }
}
