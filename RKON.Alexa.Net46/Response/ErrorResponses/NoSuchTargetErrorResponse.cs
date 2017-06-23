﻿using RKon.Alexa.NET46.Request;

namespace RKon.Alexa.NET46.Response.ErrorResponses
{
    /// <summary>
    /// Error response, if the device ist not found
    /// </summary>
    public class NoSuchTargetErrorResponse : ErrorResponse
    {
        /// <summary>
        /// Constructor
        /// Throws a  UnvalidDiscoveryResponseException, if this error response is for a  DiscoverApplianceRequest
        /// </summary>
        /// <param name="header">Requestheader</param>
        public NoSuchTargetErrorResponse(RequestHeader header)
        {
            throwExceptionOnDiscoveryRequest(header.Name);
            Header = setHeader(header, RKon.Alexa.NET46.Types.HeaderNames.NO_SUCH_TARGET_ERROR);
            Payload = new ResponsePayload();
        }
    }
}