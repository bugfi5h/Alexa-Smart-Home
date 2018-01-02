using Newtonsoft.Json;
using System.Collections.Generic;

namespace RKon.Alexa.NET46.JsonObjects
{
    /// <summary>
    /// Describes the actions an endpoint is capable of performing and the properties that can be retrieved and report change notifications.
    /// </summary>
    public class AlexaInterface : Capability
    {
        /// <summary>
        ///  	The qualified name of the interface that describes the actions for the device.
        /// </summary>
        [JsonProperty("interface")]
        [JsonRequired]
        public string Interface { get; set; }
        /// <summary>
        /// Indicates the interface version that this endpoint supports.
        /// </summary>
        [JsonProperty("version")]
        [JsonRequired]
        public string Version { get; set; }
        /// <summary>
        /// Indicates the properties of the interface which are supported by this endpoint in the format "name":"propertyName". If you do not specify a reportable property of the interface in this array, the default is to assume that proactivelyReported and retrievable for that property are false.
        /// </summary>
        [JsonProperty("properties", NullValueHandling =NullValueHandling.Ignore)]
        public Properties Properties { get; set; }
        /// <summary>
        /// An array of cameraStream structures that provide information about the stream.
        /// </summary>
        [JsonProperty("cameraStreamConfigurations", NullValueHandling = NullValueHandling.Ignore)]
        public List<CameraStreamConfigurations> CameraStreamConfiguration { get; set; }

        /// <summary>
        /// Standardconstructer. Sets Type to AlexaInterface
        /// </summary>
        public AlexaInterface()
        {
            Type = Types.CapabilitiyTypes.AlexaInterface;
        }

        /// <summary>
        /// Contructor to fill a AlexaInterface
        /// </summary>
        /// <param name="interfaceName"></param>
        /// <param name="version"></param>
        /// <param name="propertyNames"></param>
        /// <param name="proactivelyReported"></param>
        /// <param name="retrievable"></param>
        /// <param name="cameraStreamConfiguration"></param>
        public AlexaInterface(string interfaceName, string version, List<string> propertyNames, bool? proactivelyReported, bool? retrievable, List<CameraStreamConfigurations> cameraStreamConfiguration = null)
        {
            Type = Types.CapabilitiyTypes.AlexaInterface;
            Interface = interfaceName;
            Version = version;
            if(propertyNames != null && propertyNames.Count > 0)
            {
                Properties = new Properties();
                foreach (string propertyName in propertyNames)
                {
                    Properties.Supported.Add(new Supported(propertyName));
                }
                Properties.ProactivelyReported = proactivelyReported;
                Properties.Retrieveable = retrievable;
            }
            CameraStreamConfiguration = cameraStreamConfiguration;
        }
    }
}
