using RKon.Alexa.NET.Types.PayloadObjects;
using Newtonsoft.Json;

namespace RKon.Alexa.NET.Request.RequestPayloads
{
    /// <summary>
    /// Payload für ein SetTargetTemperatureRequest
    /// </summary>
    public class SetTemperatureRequestPayload : TurnOnOffRequestPayload
    {
        /// <summary>
        /// Zieltemperatur in Grad Celsius.
        /// </summary>
        [JsonProperty("targetTemperature")]
        public TargetTemperature TargetTemperature { get; set; }
    }
}
