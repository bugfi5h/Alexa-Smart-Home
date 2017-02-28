using Newtonsoft.Json;
using System.Collections.Generic;

namespace RKon.Alexa.NET.Response
{
    /// <summary>
    /// Payload für eine DiscoverApplianceResponse
    /// </summary>
    public class DiscoverResponsePayload : ResponsePayload
    {
        /// <summary>
        /// Gefundene Geräte
        /// </summary>
        [JsonProperty("discoveredAppliances")]
        [JsonRequired]
        public List<ResponseAppliance> DiscoveredAppliances { get; set; }

        /// <summary>
        /// Konstruktor. Erstellt eine neue Liste gefundener Geräte
        /// </summary>
        public DiscoverResponsePayload()
        {
            DiscoveredAppliances = new List<ResponseAppliance>();
        }
    }
}
