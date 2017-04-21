using Newtonsoft.Json;
using System.Collections.Generic;

namespace RKon.Alexa.NET.Request
{
    /// <summary>
    /// Appliance from a Request
    /// </summary>
    public class RequestAppliance
    {
        /// <summary>
        /// ApplianceID
        /// </summary>
        [JsonProperty("applianceID")]
        public string ApplianceId { get; set; }
        /// <summary>
        /// Additional Appliance details
        /// </summary>
        [JsonProperty("additionalApplianceDetails")]
        public Dictionary<string,object>AdditionalApplianceDetails { get; set; }

        /// <summary>
        /// Konstruktor. Initialises AdditionalApplianceDetails
        /// </summary>
        public RequestAppliance()
        {
            AdditionalApplianceDetails = new Dictionary<string, object>();
        }
    }
}
