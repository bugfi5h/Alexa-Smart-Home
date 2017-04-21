using RKon.Alexa.NET.Types;
using Newtonsoft.Json;

namespace RKon.Alexa.NET.Request.RequestPayloads
{
    /// <summary>
    /// Payload für ein SetTargetTemperatureRequest
    /// </summary>
    public class SetTemperatureRequestPayload : RequestPayloadWithAppliance
    {
        /// <summary>
        /// Zieltemperatur in Grad Celsius.
        /// </summary>
        [JsonProperty("targetTemperature")]
        public TargetTemperature TargetTemperature { get; set; }
    }
}
