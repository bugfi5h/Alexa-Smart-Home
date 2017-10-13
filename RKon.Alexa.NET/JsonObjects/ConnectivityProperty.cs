using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RKon.Alexa.NET.Types;

namespace RKon.Alexa.NET.JsonObjects
{
    /// <summary>
    /// Specifies the status of the communication path between the hub or cloud and the device. Supported values are: OK, UNREACHABLE
    /// </summary>
    public class ConnectivityProperty
    {
        /// <summary>
        /// Specifies the status of the communication path between the hub or cloud and the device. Supported values are: OK, UNREACHABLE
        /// </summary>
        [JsonProperty("value")]
        [JsonRequired]
        [JsonConverter(typeof(StringEnumConverter))]
        public ConnectivityModes Value { get; set; }
    }
}
