using RKon.Alexa.NET46.Request;


namespace RKon.Alexa.NET46.Response.ErrorResponses
{
    /// <summary>
    /// Error response if the cloud connection to a Hub or Bridge is not stable
    /// </summary>
    public class TargetBridgeConnectivityUnstableErrorResponse : ErrorResponse
    {
        /// <summary>
        /// Constructor
        /// Throws a  UnvalidDiscoveryResponseException, if this error response is for a  DiscoverApplianceRequest
        /// </summary>
        /// <param name="header">Requestheader</param>
        public TargetBridgeConnectivityUnstableErrorResponse(RequestHeader header)
        {
            throwExceptionOnDiscoveryRequest(header.Name);
            Header = setHeader(header, RKon.Alexa.NET46.Types.HeaderNames.TARGET_BRIDGE_CONNECTIVITY_UNSTABLE_ERROR);
            Payload = new ResponsePayload();
        }
    }
}
