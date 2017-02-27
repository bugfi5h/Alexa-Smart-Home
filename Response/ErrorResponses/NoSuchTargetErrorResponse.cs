using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Response.Payloads;

namespace RKon.Alexa.NET.Response.ErrorResponses
{
    /// <summary>
    /// Fehlerresponse wenn das angegebene Gerät nicht gefunden wurde
    /// </summary>
    public class NoSuchTargetErrorResponse : ErrorResponse
    {
        /// <summary>
        /// Konstruktor erstellt Header an Hand vom Requestheader und einen leeren Payload
        /// Schmeißt eine UnvalidDiscoveryResponseException, wenn diese Fehlerresponse auf ein DiscoverApplianceRequest antworten soll,
        /// da diese Requests nie eine ErrorResponse als Antwort bekommen.
        /// </summary>
        /// <param name="header">Requestheader</param>
        public NoSuchTargetErrorResponse(RequestHeader header)
        {
            throwExceptionOnDiscoveryRequest(header.Name);
            Header = setHeader(header, RKon.Alexa.NET.Types.HeaderNames.NO_SUCH_TARGET_ERROR);
            Payload = new ResponsePayload();
        }
    }
}
