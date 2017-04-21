using RKon.Alexa.NET.Request;
namespace RKon.Alexa.NET.Response.ErrorResponses
{
    /// <summary>
    /// Fehlermeldung, wenn das Gerät sich in einem Modus befindet, in der es sich nicht mit der Smart Home Skill API kontrollieren lässt
    /// </summary>
    public class NotSupportedInCurrentModeErrorResponse : ErrorResponse
    {
        /// <summary>
        /// Constructor
        /// Throws a  UnvalidDiscoveryResponseException, if this error response is for a  DiscoverApplianceRequeson.
        /// CurrentDeviceMode has to be a valid mode. These can be found in RKon.Alexa.NET.Types.DeviceModes.Modes.
        /// If a unvalid entry is entered, it will set to OTHER.
        /// </summary>
        /// <param name="reqHeader">Requestheader</param>
        /// <param name="currentDeviceMode">Active mode of the device</param>
        public NotSupportedInCurrentModeErrorResponse(RequestHeader reqHeader, string currentDeviceMode)
        {
            throwExceptionOnDiscoveryRequest(reqHeader.Name);
            Header = setHeader(reqHeader, RKon.Alexa.NET.Types.HeaderNames.NOT_SUPPORTED_IN_CURRENT_MODE_ERROR);
            Payload = new NotSupportedInCurrentModePayload(currentDeviceMode);
        }
    }
}
