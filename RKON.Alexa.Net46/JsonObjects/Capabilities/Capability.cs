﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RKon.Alexa.NET46.Types;

namespace RKon.Alexa.NET46.JsonObjects
{
    /// <summary>
    /// A capability is a polymorphic type. Currently, AlexaInterface is the only supported type of capability.
    /// </summary>
    public class Capability
    {
        /// <summary>
        ///  	Indicates the type of capability, which determines what fields the capability has.
        /// </summary>
        [JsonProperty("type")]
        [JsonRequired]
        [JsonConverter(typeof(StringEnumConverter))]
        public CapabilitiyTypes Type { get; set; }
    }
}
