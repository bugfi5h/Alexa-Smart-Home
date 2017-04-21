using Newtonsoft.Json;
using RKon.Alexa.NET.Types.PayloadObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RKon.Alexa.NET.Response
{
    /// <summary>
    /// Payload für ein SetColorResponse
    /// </summary>
    public class SetColorResponsePayload : ResponsePayload
    {
        /// <summary>
        /// Status des Geräts nach der Farbänderung
        /// </summary>
        [JsonProperty("achievedState")]
        [JsonRequired]
        public AchievedColorState AchievedState { get; set; }

        /// <summary>
        /// Konstruktor. Initialisiert alle Properties.
        /// </summary>
        public SetColorResponsePayload()
        {
            AchievedState = new AchievedColorState();
        }
    }
}
