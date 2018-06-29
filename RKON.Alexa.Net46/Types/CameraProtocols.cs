
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RKon.Alexa.NET46.Types
{
    /// <summary>
    /// Valid camera protocols
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CameraProtocols
    {
        /// <summary>
        /// rtsp
        /// </summary>
        RTSP
    }
}
