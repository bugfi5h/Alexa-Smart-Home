using RKon.Alexa.NET.Request;

namespace RKon.Alexa.NET.Response.ErrorResponses
{
    /// <summary>
    /// Error message if the target is not supported by the skill adapter.
    /// </summary>
    public class UnsupportedTargetErrorResponse : ErrorResponse
    {
        /// <summary>
        /// Constructor
        /// Throws a  UnvalidDiscoveryResponseException, if this error response is for a  DiscoverApplianceRequest
        /// </summary>
        /// <param name="header">Requestheader</param>
        public UnsupportedTargetErrorResponse(RequestHeader header)
        {
            throwExceptionOnDiscoveryRequest(header.Name);
            Header = setHeader(header, RKon.Alexa.NET.Types.HeaderNames.UNSUPPORTED_TARGET_ERROR);
            Payload = new ResponsePayload();
        }
    }
}
