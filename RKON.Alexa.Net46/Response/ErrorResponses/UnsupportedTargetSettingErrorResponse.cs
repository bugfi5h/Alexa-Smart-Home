using RKon.Alexa.NET46.Request;

namespace RKon.Alexa.NET46.Response.ErrorResponses
{
    /// <summary>
    /// Error response, id the target setting is not suported by device or the operation.
    /// </summary>
    public class UnsupportedTargetSettingErrorResponse : ErrorResponse
    {
        /// <summary>
        /// Constructor
        /// Throws a  UnvalidDiscoveryResponseException, if this error response is for a  DiscoverApplianceRequest
        /// </summary>
        /// <param name="header">Requestheader</param>
        public UnsupportedTargetSettingErrorResponse(RequestHeader header)
        {
            throwExceptionOnDiscoveryRequest(header.Name);
            Header = setHeader(header, RKon.Alexa.NET46.Types.HeaderNames.UNSUPPORTED_TARGET_SETTING_ERROR);
            Payload = new ResponsePayload();
        }
    }
}
