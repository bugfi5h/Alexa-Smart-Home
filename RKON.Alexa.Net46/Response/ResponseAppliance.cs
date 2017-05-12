using Newtonsoft.Json;
using RKon.Alexa.NET46.Types;
using System.Collections.Generic;


namespace RKon.Alexa.NET46.Response
{
    /// <summary>
    /// Appliance for responses
    /// </summary>
    public class ResponseAppliance
    {
        /// <summary>
        /// GeräteID
        /// </summary>
        [JsonProperty("applianceId")]
        [JsonRequired]
        public string ApplianceID { get; set; }
        /// <summary>
        /// Maufacturer
        /// </summary>
        [JsonProperty("manufacturerName")]
        [JsonRequired]
        public string ManufacturerName { get; set; }
        /// <summary>
        /// Model
        /// </summary>
        [JsonProperty("modelName")]
        [JsonRequired]
        public string ModelName { get; set; }
        /// <summary>
        /// Version
        /// </summary>
        [JsonProperty("version")]
        [JsonRequired]
        public string Version { get; set; }
        /// <summary>
        /// Name of the appliance, that is used to identify the device
        /// </summary>
        [JsonProperty("friendlyName")]
        [JsonRequired]
        public string FriendlyName { get; set; }
        /// <summary>
        /// Description in 128 characters
        /// </summary>
        [JsonProperty("friendlyDescription")]
        [JsonRequired]
        public string FriendlyDescription { get; set; }
        /// <summary>
        /// boolean to represent if the appliance is reachable
        /// </summary>
        [JsonProperty("isReachable")]
        [JsonRequired]
        public bool IsReachable { get; set; }
        /// <summary>
        /// available actions of the appliance
        /// </summary>
        [JsonProperty("actions")]
        [JsonRequired]
        public List<string> Actions { get; set; }
        /// <summary>
        /// List of additional details. Can be empty
        /// </summary>
        [JsonProperty("additionalApplianceDetails")]
        public Dictionary<string,object> AdditionalApplianceDetails { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">DeviceId</param>
        /// <param name="manufacturerName">manufacturer</param>
        /// <param name="modelName">Model</param>
        /// <param name="version">Version</param>
        /// <param name="friendlyName">Name of the appliance, that is used to identify the device</param>
        /// <param name="friendlyDescription">Description in 128 characters</param>
        /// <param name="isReachable">boolean to represent if the appliance is reachable</param>
        public ResponseAppliance(string id, string manufacturerName, string modelName, string version, string friendlyName, string friendlyDescription, bool isReachable)
        {
            AdditionalApplianceDetails = new Dictionary<string, object>();
            ApplianceID = id;
            ManufacturerName = manufacturerName;
            ModelName = modelName;
            Version = version;
            FriendlyName = friendlyName;
            FriendlyDescription = friendlyDescription;
            IsReachable = isReachable;
            Actions = new List<string>();
        }

        /// <summary>
        /// Tries to add a action. Valid actions can be found in the namespace RKon.Alexa.NET46.Types.ApplianceActions
        /// </summary>
        /// <param name="action">Action to add</param>
        /// <returns>True, if a value was added</returns>
        public bool TryAddAction(string action)
        {
            if (ApplianceActions.Actions.Contains(action))
            {
                Actions.Add(action);
                return true;
            }
            return false;
        }
    }
}
