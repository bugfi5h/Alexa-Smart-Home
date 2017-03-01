using RKon.Alexa.NET.Types;
using Newtonsoft.Json;

namespace RKon.Alexa.NET.Request.RequestPayloads
{
    /// <summary>
    /// Payload für einen DecrementTemperature- oder IncrementTemperatureRequest
    /// </summary>
    public class In_DecrementTemperatureRequestPayload : RequestPayloadWithAppliance
    {
        /// <summary>
        /// Menge um wie viel die Temperatur angepasst werden soll
        /// </summary>
        [JsonProperty("deltaTemperature")]
        public DeltaTemperature DeltaTemperature { get; set; }

    }
}
