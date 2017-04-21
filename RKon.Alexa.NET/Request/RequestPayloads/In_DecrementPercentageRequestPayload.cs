﻿using Newtonsoft.Json;
using RKon.Alexa.NET.Types;

namespace RKon.Alexa.NET.Request.RequestPayloads
{
    /// <summary>
    /// Payload for a DecrementPercentage- or IncrementPercentageRequest
    /// </summary>
    public class In_DecrementPercentageRequestPayload: RequestPayloadWithAppliance
    {
        /// <summary>
        /// The percent decrease/increase to apply to the device
        /// </summary>
        [JsonProperty("deltaPercentage")]
        public DeltaPercentage DeltaPercentage { get; set; }
    }
}
