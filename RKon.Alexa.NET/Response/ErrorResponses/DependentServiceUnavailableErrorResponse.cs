using RKon.Alexa.NET.Request;

namespace RKon.Alexa.NET.Response.ErrorResponses
{
    /// <summary>
    /// Error response, if a dependency is unavailable.
    /// </summary>
    public class DependentServiceUnavailableErrorResponse : ErrorResponse
    {
        /// <summary>
        /// Constructor.      
        /// Throws a  UnvalidDiscoveryResponseException, if this error response is for a  DiscoverApplianceRequest
        /// </summary>
        /// <param name="reqHeader">Requestheader</param>
        /// <param name="serviceName">Name of the service, that is unavailable</param>
        public DependentServiceUnavailableErrorResponse(RequestHeader reqHeader,string serviceName)
        {
            throwExceptionOnDiscoveryRequest(reqHeader.Name);
            Header = setHeader(reqHeader, RKon.Alexa.NET.Types.HeaderNames.V2.DEPENDENT_SERVICE_UNAVAILABLE_ERROR);
            Payload = new DependentServiceUnavailablePayload(serviceName);
        }
    }
}
