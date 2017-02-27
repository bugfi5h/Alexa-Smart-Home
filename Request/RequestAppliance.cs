using Newtonsoft.Json;
using System.Collections.Generic;

namespace RKon.Alexa.NET.Request
{
    /// <summary>
    /// Gerät aus einem Request
    /// </summary>
    public class RequestAppliance
    {
        /// <summary>
        /// GeräteId
        /// </summary>
        [JsonProperty("applianceID")]
        public string ApplianceId { get; set; }
        /// <summary>
        /// Zusätzliche Appliance Informationen
        /// </summary>
        [JsonProperty("additionalApplianceDetails")]
        public Dictionary<string,object>AdditionalApplianceDetails { get; set; }

        /// <summary>
        /// Konstruktor. Initialisiert AdditionalApplianceDetails
        /// </summary>
        public RequestAppliance()
        {
            AdditionalApplianceDetails = new Dictionary<string, object>();
        }
    }
}
