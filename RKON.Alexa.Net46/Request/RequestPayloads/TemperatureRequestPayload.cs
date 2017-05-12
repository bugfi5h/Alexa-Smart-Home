using RKon.Alexa.NET46.Types;
using Newtonsoft.Json;

namespace RKon.Alexa.NET46.Request.RequestPayloads
{
    /// <summary>
    /// Payload for a SetTargetTemperatureRequest
    /// </summary>
    public class SetTemperatureRequestPayload : RequestPayloadWithAppliance
    {
        /// <summary>
        /// Target temperature in Grad Celsius.
        /// </summary>
        [JsonProperty("targetTemperature")]
        public TargetTemperature TargetTemperature { get; set; }
    }
}
