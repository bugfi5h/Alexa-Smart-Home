using System;

using RKon.Alexa.NET.Request;
using Newtonsoft.Json;
using RKon.Alexa.NET.Types;

namespace RKon.Alexa.NET.Response.ErrorResponses
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

    /// <summary>
    /// Abstrakte Basisklasse für Fehlermeldungen auf SmartHomeRequests.
    /// </summary>
    public abstract class ErrorResponse : ISmartHomeResponse
    {
        /// <summary>
        /// Header
        /// </summary>
        [JsonRequired]
        [JsonProperty("header")]
        public ResponseHeader Header
        {
            get; set;
        }
        /// <summary>
        /// Payload
        /// </summary>
        [JsonRequired]
        [JsonProperty("payload")]
        public ResponsePayload Payload
        {
            get; set;
        }
        /// <summary>
        /// Liefert den Typ des Payloads zurück
        /// </summary>
        /// <returns>System.Type des Payloads</returns>
        public System.Type GetResponsePayloadType()
        {
            return Payload?.GetType();
        }

        /// <summary>
        /// Setzt den Header an Hand des RequestHeaders und dem Namen des Fehlers
        /// </summary>
        /// <param name="reqHeader">RequestHeaders</param>
        /// <param name="errorName">Name des Fehlers</param>
        /// <returns></returns>
        protected ResponseHeader setHeader(RequestHeader reqHeader, string errorName)
        {
            ResponseHeader header = new ResponseHeader(reqHeader);
            header.Name = errorName;
            return header;
        }

        /// <summary>
        /// Schmeißt eine UnvalidDiscoveryResponseException, wenn versucht wird eine ErrorResponse für ein DiscoverApplianceRequest zu verwenden.
        /// </summary>
        /// <param name="reqHeaderName"></param>
        protected void throwExceptionOnDiscoveryRequest(string reqHeaderName)
        {
            if (reqHeaderName == HeaderNames.DISCOVERY_REQUEST)
            {
                throw new UnvalidDiscoveryResponseException();
            }
        }
    }
}
