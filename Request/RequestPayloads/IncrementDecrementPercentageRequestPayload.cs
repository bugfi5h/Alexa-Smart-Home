using Newtonsoft.Json;
using RKon.Alexa.NET.Types;

namespace RKon.Alexa.NET.Request.RequestPayloads
{
    /// <summary>
    /// Payload für einen DecrementPercentage- oder IncrementPercentageRequest
    /// </summary>
    public class IncrementDecrementPercentageRequestPayload: TurnOnOffRequestPayload
    {
        /// <summary>
        /// Menge um wie viel der Prozentwert des Geräts angepasst werden soll
        /// </summary>
        [JsonProperty("deltaPercentage")]
        public DeltaPercentage DeltaPercentage { get; set; }
    }
}
