using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RKon.Alexa.NET.Request.RequestPayloads
{
    /// <summary>
    /// Abstrakte Basisklasse für Payloads mit AccessToken und Appliance
    /// </summary>
    public abstract class RequestPayloadWithAppliance : RequestPayloadWithAccessToken
    {
        /// <summary>
        /// Das Gerät für das die Aktion bestimmt ist
        /// </summary>
        [JsonProperty("appliance")]
        public RequestAppliance Appliance { get; set; }
    }
}
