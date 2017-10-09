using RKon.Alexa.NET.Request;

namespace RKon.Alexa.NET.Response.ErrorResponses
{
    /// <summary>
    /// Error response, if the device is connected to a hub or bridge, that is offline
    /// </summary>
    public class BridgeOfflineErrorResponse : ErrorResponse
    {
        /// <summary>
        /// Constructor creates a header and a empty payload
        /// Throws a  UnvalidDiscoveryResponseException, if this error response is for a  DiscoverApplianceRequest
        /// </summary>
        /// <param name="header">Requestheader</param>
        public BridgeOfflineErrorResponse(RequestHeader header)
        {
            throwExceptionOnDiscoveryRequest(header.Name);
            Header = setHeader(header, RKon.Alexa.NET.Types.HeaderNames.V2.BRIDGE_OFFLINE_ERROR);
            Payload = new ResponsePayload();
        }
    }
}
