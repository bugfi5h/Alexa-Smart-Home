using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RKon.Alexa.NET46.Types;
using System.Collections.Generic;

namespace RKon.Alexa.NET46.JsonObjects
{
    /// <summary>
    /// Configuration Payload In addition to the standard discovery format, the Cooking discovery response should include a configuration object
    /// </summary>
    public class CookingConfiguration
    {
        /// <summary>
        /// Specifies the cooking modes supported for this appliance’s implementation of the Cooking interface. Cannot be empty or only contain OFF.
        /// </summary>
        [JsonProperty("supportedCookingModes")]
        [JsonRequired]
        public List<CookingModes> SupportedCookingModes { get; set; }

        /// <summary>
        /// True to indicates the appliance starts with an Alexa voice command, 
        /// otherwise false indicates the appliance is set to the specified cooking mode,
        /// but does not start until the customer presses the start button on the appliance. 
        /// </summary>
        [JsonProperty("supportsRemoteStart", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SupportsRemoteStart { get; set; }

        /// <summary>
        /// Basic Constructor
        /// </summary>
        public CookingConfiguration()
        {
            SupportedCookingModes = new List<CookingModes>();
        }
    }
}
