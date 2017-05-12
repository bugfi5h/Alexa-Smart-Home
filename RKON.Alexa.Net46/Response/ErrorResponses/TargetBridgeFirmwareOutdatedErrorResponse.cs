using RKon.Alexa.NET46.Request;

namespace RKon.Alexa.NET46.Response.ErrorResponses
{
    /// <summary>
    /// Error response, if a firmware of a hub or bridge is outdated
    /// </summary>
    public class TargetBridgeFirmwareOutdatedErrorResponse : ErrorResponse
    {
        /// <summary>
        /// Constructor
        /// Throws a  UnvalidDiscoveryResponseException, if this error response is for a  DiscoverApplianceRequest
        /// </summary>
        /// <param name="header">Requestheader</param>
        /// <param name="minimumFirmwareVersion">Minimum Firmwareversion</param>
        /// <param name="currentFirmwareVersion">Current Firmwareversion</param>
        public TargetBridgeFirmwareOutdatedErrorResponse(RequestHeader header, string minimumFirmwareVersion, string currentFirmwareVersion)
        {
            throwExceptionOnDiscoveryRequest(header.Name);
            Header = setHeader(header, RKon.Alexa.NET46.Types.HeaderNames.TARGET_BRIDGE_FIRMWARE_OUTDATED_ERROR);
            Payload = new TargetFirmwareOutdatedPayload(minimumFirmwareVersion, currentFirmwareVersion);
        }
    }
}
