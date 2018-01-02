﻿
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RKon.Alexa.NET.Types;

namespace RKon.Alexa.NET.JsonObjects
{
    /// <summary>
    ///  	A polymorphic type that provides identifying information for a customer in a linked account service or system.
    /// </summary>
    public class Grantee
    {
        /// <summary>
        /// The Type of the Scope (Has to be changed in the future if it gets other types as Scope
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ScopeTypes Type { get; set; }
    }
}