﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RKon.Alexa.NET.Types;

namespace RKon.Alexa.NET.Payloads.ErrorResponse
{
    /// <summary>
    /// Payload for a NOT_SUPPORTED_IN_CURRENT_MODE error
    /// </summary>
    public class NotSupportedInCurrentModeErrorPayload : ErrorPayload
    {
        /// <summary>
        /// indicates why the device cannot be set to a new value. Valid values are COLOR, ASLEEP, NOT_PROVISIONED, OTHER.
        /// </summary>
        [JsonProperty("currentDeviceMode ")]
        [JsonRequired]
        [JsonConverter(typeof(StringEnumConverter))]
        public ColorTemperatureModes CurrentDeviceMode { get; set; }
    }
}
