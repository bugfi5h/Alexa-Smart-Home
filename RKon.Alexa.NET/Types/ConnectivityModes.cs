using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RKon.Alexa.NET.Types
{
    /// <summary>
    /// Specifies the status of the communication path between the hub or cloud and the device. 
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ConnectivityModes
    {
        /// <summary>
        /// Connection OK
        /// </summary>
        OK,
        /// <summary>
        /// Not reachable
        /// </summary>
        UNREACHABLE
    }
}
