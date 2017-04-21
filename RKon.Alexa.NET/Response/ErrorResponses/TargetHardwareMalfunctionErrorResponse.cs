using RKon.Alexa.NET.Request;

namespace RKon.Alexa.NET.Response.ErrorResponses
{
    /// <summary>
    /// Fehlermeldung, wenn das Gerät eine Hardwarefehlfunktion hat.
    /// </summary>
    public class TargetHardwareMalfunctionErrorResponse : ErrorResponse
    {
        /// <summary>
        /// Konstruktor erstellt Header an Hand vom Requestheader und einen leeren Payload
        /// Schmeißt eine UnvalidDiscoveryResponseException, wenn diese Fehlerresponse auf ein DiscoverApplianceRequest antworten soll,
        /// da diese Requests nie eine ErrorResponse als Antwort bekommen.
        /// </summary>
        /// <param name="header">Requestheader</param>
        public TargetHardwareMalfunctionErrorResponse(RequestHeader header)
        {
            throwExceptionOnDiscoveryRequest(header.Name);
            Header = setHeader(header, RKon.Alexa.NET.Types.HeaderNames.TARGET_HARDWARE_MALFUNCTION_ERROR);
            Payload = new ResponsePayload();
        }
    }
}
