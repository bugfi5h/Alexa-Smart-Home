using RKon.Alexa.NET.Types;
using Newtonsoft.Json;

namespace RKon.Alexa.NET.Request.RequestPayloads
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
