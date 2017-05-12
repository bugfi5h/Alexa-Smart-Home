using Newtonsoft.Json;
using System.Collections.Generic;

namespace RKon.Alexa.NET46.Response
{
    /// <summary>
    /// Payload for a DiscoverApplianceResponse
    /// </summary>
    public class DiscoverResponsePayload : ResponsePayload
    {
        /// <summary>
        /// List of discovered appliances
        /// </summary>
        [JsonProperty("discoveredAppliances")]
        [JsonRequired]
        public List<ResponseAppliance> DiscoveredAppliances { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public DiscoverResponsePayload()
        {
            DiscoveredAppliances = new List<ResponseAppliance>();
        }
    }
}
