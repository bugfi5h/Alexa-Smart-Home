using RKon.Alexa.NET46.Request;

namespace RKon.Alexa.NET46.Response.ErrorResponses
{
    /// <summary>
    /// Error response, if the access token is invalid
    /// </summary>
    public class InvalidAccessTokenErrorResponse : ErrorResponse
    {
        /// <summary>
        /// Constructor
        /// Throws a  UnvalidDiscoveryResponseException, if this error response is for a  DiscoverApplianceRequest
        /// </summary>
        /// <param name="header">Requestheader</param>
        public InvalidAccessTokenErrorResponse(RequestHeader header)
        {
            throwExceptionOnDiscoveryRequest(header.Name);
            Header = setHeader(header, RKon.Alexa.NET46.Types.HeaderNames.INVALID_ACCESS_TOKEN_ERROR);
            Payload = new ResponsePayload();
        }
    }
}
