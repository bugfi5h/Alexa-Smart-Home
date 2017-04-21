using RKon.Alexa.NET.Request;

namespace RKon.Alexa.NET.Response.ErrorResponses
{
    /// <summary>
    /// Error response, if the firmware of the device is outdated
    /// </summary>
    public class TargetFirmwareOutdatedErrorResponse : ErrorResponse
    {
        /// <summary>
        /// Constructor
        /// Throws a  UnvalidDiscoveryResponseException, if this error response is for a  DiscoverApplianceRequest
        /// </summary>
        /// <param name="reqHeader">Requestheader</param>
        /// <param name="minimumFirmwareVersion">Minimum Firmwareversion</param>
        /// <param name="currentFirmwareVersion">Current Firmwareversion</param>
        public TargetFirmwareOutdatedErrorResponse(RequestHeader reqHeader,string minimumFirmwareVersion,string currentFirmwareVersion)
        {
            throwExceptionOnDiscoveryRequest(reqHeader.Name);
            Header = setHeader(reqHeader, RKon.Alexa.NET.Types.HeaderNames.TARGET_FIRMWARE_OUTDATED_ERROR);
            Payload = new TargetFirmwareOutdatedPayload(minimumFirmwareVersion, currentFirmwareVersion);
        }
    }
}
