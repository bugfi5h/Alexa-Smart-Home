using Newtonsoft.Json;

namespace RKon.Alexa.NET.Request.V3.Payloads
{
    /// <summary>
    /// Payload for a SetColorTemperatureRequest
    /// </summary>
    public class SetColorTemperatureRequestPayload : RequestPayload
    {
        /// <summary>
        /// An integer that indicates the requested color temperature in Kelvin degrees. Valid range is 1000 to 10000, inclusive
        /// </summary>
        [JsonProperty("colorTemperatureInKelvin")]
        public int ColorTemperatureInKelvin { get; set; }
    }
}
