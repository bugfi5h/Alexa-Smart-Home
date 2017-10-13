using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RKon.Alexa.NET.Request;

namespace RKon.Alexa.NET.Response.V3.ErrorResponses
{
    /// <summary>
    /// Exception, wenn versucht wird eine ErrorResponse für ein DiscoverApplianceRequest zu verwenden.
    /// </summary>
    public class UnvalidDiscoveryResponseException : Exception
    {
        /// <summary>
        /// Konstruktor mit Exceptionmeldung.
        /// </summary>
        public UnvalidDiscoveryResponseException() : base("Discovery requests can not be answered by error responses") { }
    }

    public class ErrorResponseEvent
    {
        public EventHeader Header { get; set; }

        public Payload Payload { get; set; }

        public Type GetResponsePayloadType()
        {
            throw new NotImplementedException();
        }
    }
}
