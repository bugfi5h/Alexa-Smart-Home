using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RKon.Alexa.NET46.Types;
using System.Collections.Generic;

namespace RKon.Alexa.NET46.JsonObjects
{
    /// <summary>
    /// Endpoints for Discoveryresponse
    /// </summary>
    public class ResponseEndpoint 
    {
        /// <summary>
        /// A device identifier. The identifier must be unique across all devices owned by an end user within the domain for the skill. In addition, the identifier needs to be consistent across multiple discovery requests for the same device. The identifier cannot exceed 256 characters.
        /// </summary>
        [JsonProperty("endpointId")]
        [JsonRequired]
        public string EndpointID { get; set; }
        /// <summary>
        /// The name of the device manufacturer. This value cannot exceed 128 characters.
        /// </summary>
        [JsonProperty("manufacturerName")]
        [JsonRequired]
        public string ManufacturerName { get; set; }
        /// <summary>
        /// The name used by the customer to identify the device. This value cannot exceed 128 characters and should not contain special characters or punctuation.
        /// </summary>
        [JsonProperty("friendlyName")]
        [JsonRequired]
        public string FriendlyName { get; set; }
        /// <summary>
        /// A human-readable description of the device. This value cannot exceed 128 characters. The description should contain the manufacturer name or how the device is connected. For example, “Smart Lock by Sample Manufacturer” or “WiFi Thermostat connected via SmartHub”. This value cannot exceed 128 characters.
        /// </summary>
        [JsonProperty("description")]
        [JsonRequired]
        public string Description { get; set; }
        /// <summary>
        /// Indicates the group name where the device should display in the Alexa app. Current supported values are ‘LIGHT’, ‘SMARTPLUG’, ‘SWITCH’, ‘CAMERA’, ‘DOOR’, “TEMPERATURE_SENSOR”, ‘THERMOSTAT’, ‘SMARTLOCK’, ‘SCENE_TRIGGER’, ‘ACTIVITY_TRIGGER’, ‘OTHER’
        /// </summary>
        [JsonProperty("displayCategories")]
        [JsonRequired]
        public List<DisplayCategory> DisplayCategories { get; set; }
        /// <summary>
        /// String name/value pairs that provide additional information about a device for use by the skill. The contents of this property cannot exceed 5000 bytes. The API doesn’t use or understand this data.
        /// </summary>
        [JsonProperty("cookie")]
        [JsonRequired]
        public Dictionary<string, string> Cookies { get; set; }
        /// <summary>
        /// An array of capability objects that represents actions particular device supports and can respond to. A capability object can contain different fields depending on the type
        /// </summary>
        [JsonProperty("capabilities")]
        [JsonRequired]
        public List<Capability> Capability { get; set; }

        /// <summary>
        /// Standartconstructor
        /// </summary>
        public ResponseEndpoint()
        {
            Cookies = new Dictionary<string, string>();
            DisplayCategories = new List<DisplayCategory>();
            Capability = new List<Capability>();
        }

        /// <summary>
        /// Initialise ResponseEndpoint
        /// </summary>
        /// <param name="id"></param>
        /// <param name="manufacturer"></param>
        /// <param name="friendlyName"></param>
        /// <param name="description"></param>
        /// <param name="cookies"></param>
        /// <param name="displayCategories"></param>
        /// <param name="capabilities"></param>
        public ResponseEndpoint(string id, string manufacturer, string friendlyName, string description, Dictionary<string,string> cookies, 
            List<DisplayCategory> displayCategories, List<Capability> capabilities)
        {
            EndpointID = id;
            ManufacturerName = manufacturer;
            FriendlyName = friendlyName;
            Description = description;
            Cookies = cookies;
            DisplayCategories = displayCategories;
            Capability = capabilities;
        }
    }
}
