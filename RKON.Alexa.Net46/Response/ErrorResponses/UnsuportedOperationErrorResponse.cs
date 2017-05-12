using RKon.Alexa.NET46.Request;

namespace RKon.Alexa.NET46.Response.ErrorResponses
{
    /// <summary>
    /// Error response if the wanted operation is not supported.
    /// </summary>
    public class UnsuportedOperationErrorResponse : ErrorResponse
    {
        /// <summary>
        /// Constructor
        /// Throws a  UnvalidDiscoveryResponseException, if this error response is for a  DiscoverApplianceRequest
        /// </summary>
        /// <param name="header">Requestheader</param>
        public UnsuportedOperationErrorResponse(RequestHeader header)
        {
            throwExceptionOnDiscoveryRequest(header.Name);
            Header = setHeader(header, RKon.Alexa.NET46.Types.HeaderNames.UNSUPPORTED_OPERATION_ERROR);
            Payload = new ResponsePayload();
        }
    }
}
