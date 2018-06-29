using Newtonsoft.Json;
using RKon.Alexa.NET46.Types;

namespace RKon.Alexa.NET46.JsonObjects
{
    /// <summary>
    /// Specifies the status of the communication path between the hub or cloud and the device. Supported values are: OK, UNREACHABLE
    /// </summary>
    public class ConnectivityPropertyValue
    {
        /// <summary>
        /// Specifies the status of the communication path between the hub or cloud and the device. Supported values are: OK, UNREACHABLE
        /// </summary>
        [JsonProperty("value")]
        [JsonRequired]
        public ConnectivityModes Value { get; set; }


        /// <summary>
        /// Standardconstructor
        /// </summary>
        public ConnectivityPropertyValue()
        {
        }

        /// <summary>
        /// Initializes ConnectivityPropertyValue
        /// </summary>
        /// <param name="mode"></param>
        public ConnectivityPropertyValue(ConnectivityModes mode)
        {
            Value = mode;
        }
    }
}
