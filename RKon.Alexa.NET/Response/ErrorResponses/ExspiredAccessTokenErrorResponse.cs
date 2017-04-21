using RKon.Alexa.NET.Request;

namespace RKon.Alexa.NET.Response.ErrorResponses
{
    /// <summary>
    /// Fehlermeldung wenn das übergebene Accesstoken abgelaufen ist.
    /// </summary>
    public class ExspiredAccessTokenErrorResponse : ErrorResponse
    {
        /// <summary>
        /// Konstruktor erstellt Header an Hand vom Requestheader und einen leeren Payload
        /// Schmeißt eine UnvalidDiscoveryResponseException, wenn diese Fehlerresponse auf ein DiscoverApplianceRequest antworten soll,
        /// da diese Requests nie eine ErrorResponse als Antwort bekommen.
        /// </summary>
        /// <param name="header">Requestheader</param>
        public ExspiredAccessTokenErrorResponse(RequestHeader header)
        {
            throwExceptionOnDiscoveryRequest(header.Name);
            Header = setHeader(header, RKon.Alexa.NET.Types.HeaderNames.EXSPIRED_ACCESS_TOKEN_ERROR);
            Payload = new ResponsePayload();
        }
    }
}
