using RKon.Alexa.NET46.Types;
using Newtonsoft.Json;

namespace RKon.Alexa.NET46.Request.RequestPayloads
{
    /// <summary>
    /// Payload für einen DecrementTemperature- oder IncrementTemperatureRequest
    /// </summary>
    public class In_DecrementTemperatureRequestPayload : RequestPayloadWithAppliance
    {
        /// <summary>
        /// The temperature decrease/increase to apply to the device
        /// </summary>
        [JsonProperty("deltaTemperature")]
        public DeltaTemperature DeltaTemperature { get; set; }

    }
}
