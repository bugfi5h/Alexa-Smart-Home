using Newtonsoft.Json;

namespace RKon.Alexa.NET.JsonObjects
{
    /// <summary>
    /// Describes the actions an endpoint is capable of performing and the properties that can be retrieved and report change notifications.
    /// </summary>
    public class AlexaInterface : Capability
    {
        /// <summary>
        ///  	Indicates the type of capability, which determines what fields the capability has.
        /// </summary>
        [JsonProperty("type")]
        [JsonRequired]
        public string Type { get; set; }
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
        [JsonProperty("properties")]
        public Properties Properties { get; set; }
        /// <summary>
        /// Indicates whether the properties listed for this endpoint generate Change.Report events.
        /// </summary>
        [JsonProperty("proactivelyReported", NullValueHandling = NullValueHandling.Ignore)]
        public bool ProactivelyReported { get; set; }
        /// <summary>
        /// Indicates whether the properties listed for this endpoint can be retrieved for state reporting.
        /// </summary>
        [JsonProperty("retrievable",NullValueHandling =NullValueHandling.Ignore)]
        public bool Retrieveable { get; set; }
    }
}
