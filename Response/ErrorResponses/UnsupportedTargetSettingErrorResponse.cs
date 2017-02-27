using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Response.Payloads;

namespace RKon.Alexa.NET.Response.ErrorResponses
{
    /// <summary>
    /// Fehlermeldung, wenn die angeforderte Einstellung für das Gerät und die Operation ungültig ist.
    /// </summary>
    public class UnsupportedTargetSettingErrorResponse : ErrorResponse
    {
        /// <summary>
        /// Konstruktor erstellt Header an Hand vom Requestheader und einen leeren Payload
        /// Schmeißt eine UnvalidDiscoveryResponseException, wenn diese Fehlerresponse auf ein DiscoverApplianceRequest antworten soll,
        /// da diese Requests nie eine ErrorResponse als Antwort bekommen.
        /// </summary>
        /// <param name="header">Requestheader</param>
        public UnsupportedTargetSettingErrorResponse(RequestHeader header)
        {
            throwExceptionOnDiscoveryRequest(header.Name);
            Header = setHeader(header, RKon.Alexa.NET.Types.HeaderNames.UNSUPPORTED_TARGET_SETTING_ERROR);
            Payload = new ResponsePayload();
        }
    }
}
