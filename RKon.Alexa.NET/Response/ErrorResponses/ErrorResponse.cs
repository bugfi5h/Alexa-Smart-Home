using System;

using RKon.Alexa.NET.Request;
using Newtonsoft.Json;
using RKon.Alexa.NET.Types;

namespace RKon.Alexa.NET.Response.ErrorResponses
{
    /// <summary>
    /// Exception, if this error response is for a  DiscoverApplianceRequest
    /// </summary>
    public class UnvalidDiscoveryResponseException : Exception
    {
        /// <summary>
        ///  Constructor
        /// </summary>
        public UnvalidDiscoveryResponseException() : base("Discovery requests can not be answered by error responses") { }
    }

    /// <summary>
    /// Abstract base class for error responses of SmartHomeRequests.
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
        /// returns the Type of a Payloads
        /// </summary>
        /// <returns>System.Type of the Payloads</returns>
        public System.Type GetResponsePayloadType()
        {
            return Payload?.GetType();
        }

        /// <summary>
        /// Sets the Header with the request header and the errorname.
        /// </summary>
        /// <param name="reqHeader">RequestHeader</param>
        /// <param name="errorName">Name of the error</param>
        /// <returns></returns>
        protected ResponseHeader setHeader(RequestHeader reqHeader, string errorName)
        {
            ResponseHeader header = new ResponseHeader(reqHeader);
            header.Name = errorName;
            return header;
        }

        /// <summary>
        /// Throws a UnvalidDiscoveryResponseException, if a Errorresponse is used as a response for DiscoverApplianceRequests.
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
