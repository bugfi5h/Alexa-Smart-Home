using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RKon.Alexa.NET.Request.RequestPayloads
{
    /// <summary>
    /// Abstrakte Basisklasse für Payloads mit AccessToken
    /// </summary>
    public abstract class RequestPayloadWithAccessToken : RequestPayload
    {
        /// <summary>
        /// Access Token, der der Kunden Geräte Cloud zugewiesen ist.
        /// </summary>
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
    }
}
