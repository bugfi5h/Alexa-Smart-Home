﻿using Newtonsoft.Json;

namespace RKon.Alexa.NET.Request.V3
{
    /// <summary>
    /// Directive send from Alexa
    /// </summary>
    public class SmartHomeRequest
    {
        /// <summary>
        /// Request messages called directives
        /// </summary>
        [JsonProperty("directive")]
        public Directive Directive { get; set; }

        /// <summary>
        /// System.Type of the Payloads
        /// </summary>
        /// <returns>System.Type of the Payloads</returns>
        public System.Type GetPayloadType()
        {
            return Directive?.Payload?.GetType();
        }
    }
}
