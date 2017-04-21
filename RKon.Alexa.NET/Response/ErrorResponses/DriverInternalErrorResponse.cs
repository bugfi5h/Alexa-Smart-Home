using RKon.Alexa.NET.Request;

namespace RKon.Alexa.NET.Response.ErrorResponses
{
    /// <summary>
    /// Generic runtimeerror
    /// </summary>
    public class DriverInternalErrorResponse : ErrorResponse
    {
        /// <summary>
        /// Constructor
        /// Throws a  UnvalidDiscoveryResponseException, if this error response is for a  DiscoverApplianceRequest
        /// </summary>
        /// <param name="header">Requestheader</param>
        public DriverInternalErrorResponse(RequestHeader header)
        {
            throwExceptionOnDiscoveryRequest(header.Name);
            Header = setHeader(header, RKon.Alexa.NET.Types.HeaderNames.DRIVER_INTERNAL_ERROR);
            Payload = new ResponsePayload();
        }
    }
}
