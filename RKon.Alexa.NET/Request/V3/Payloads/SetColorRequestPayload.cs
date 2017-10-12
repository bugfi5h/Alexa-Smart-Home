﻿using Newtonsoft.Json;
using RKon.Alexa.NET.JsonObjects;
using RKon.Alexa.NET.Types;

namespace RKon.Alexa.NET.Request.V3.Payloads
{
    /// <summary>
    /// Payload for a SetColorRequest
    /// </summary>
    public class SetColorRequestPayload : RequestPayload
    {
        /// <summary>
        /// Describes the color to set for the light. Specified in the hue, saturation, brightness (HSB) color model.
        /// </summary>
        [JsonProperty(PropertyNames.COLOR)]
        public Color Color { get; set; }
    }
}
