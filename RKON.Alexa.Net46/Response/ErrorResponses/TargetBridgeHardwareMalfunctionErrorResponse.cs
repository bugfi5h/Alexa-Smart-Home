﻿using RKon.Alexa.NET46.Request;


namespace RKon.Alexa.NET46.Response.ErrorResponses
{
    /// <summary>
    /// Error response, if a hub or bridge has a hardware malfunction
    /// </summary>
    public class TargetBridgeHardwareMalfunctionErrorResponse : ErrorResponse
    {
        /// <summary>
        /// Constructor
        /// Throws a  UnvalidDiscoveryResponseException, if this error response is for a  DiscoverApplianceRequest
        /// </summary>
        /// <param name="header">Requestheader</param>
        public TargetBridgeHardwareMalfunctionErrorResponse(RequestHeader header)
        {
            throwExceptionOnDiscoveryRequest(header.Name);
            Header = setHeader(header, RKon.Alexa.NET46.Types.HeaderNames.TARGET_BRIDGE_HARDWARE_MALFUNCTION_ERROR);
            Payload = new ResponsePayload();
        }
    }
}
