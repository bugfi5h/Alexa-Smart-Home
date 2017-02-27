using RKon.Alexa.NET.Types.PayloadObjects;
using Newtonsoft.Json;

namespace RKon.Alexa.NET.Request.RequestPayloads
{
    /// <summary>
    /// Payload für einen DecrementTemperature- oder IncrementTemperatureRequest
    /// </summary>
    public class IncrementDecrementRequestPayload : TurnOnOffRequestPayload
    {
        /// <summary>
        /// Menge um wie viel die Temperatur angepasst werden soll
        /// </summary>
        [JsonProperty("deltaTemperature")]
        public DeltaTemperature DeltaTemperature { get; set; }

    }
}
