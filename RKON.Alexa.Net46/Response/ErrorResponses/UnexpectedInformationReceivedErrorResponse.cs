﻿using RKon.Alexa.NET46.Request;

namespace RKon.Alexa.NET46.Response.ErrorResponses
{
    /// <summary>
    /// Error response, if a request message or the payload could not be handled by the skill adapter.
    /// </summary>
    public class UnexpectedInformationReceivedErrorResponse : ErrorResponse
    {
        /// <summary>
        /// Constructor
        /// Throws a  UnvalidDiscoveryResponseException, if this error response is for a  DiscoverApplianceRequest
        /// </summary>
        /// <param name="reqHeader">Requestheader</param>
        /// <param name="faultingParameter">Parameter that was faulting</param>
        public UnexpectedInformationReceivedErrorResponse(RequestHeader reqHeader, string faultingParameter)
        {
            throwExceptionOnDiscoveryRequest(reqHeader.Name);
            Header = setHeader(reqHeader, RKon.Alexa.NET46.Types.HeaderNames.UNEXCEPTED_INFORMATION_RECEIVED_ERROR);
            Payload = new UnexpectedInformationReceivedPayload(faultingParameter);
        }
    }
}
