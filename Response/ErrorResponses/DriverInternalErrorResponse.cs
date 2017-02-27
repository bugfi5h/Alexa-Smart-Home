using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Response.Payloads;

namespace RKon.Alexa.NET.Response.ErrorResponses
{
    /// <summary>
    /// Generische Laufzeitfehlermeldung
    /// </summary>
    public class DriverInternalErrorResponse : ErrorResponse
    {
        /// <summary>
        /// Konstruktor erstellt Header an Hand vom Requestheader und einen leeren Payload
        /// Schmeißt eine UnvalidDiscoveryResponseException, wenn diese Fehlerresponse auf ein DiscoverApplianceRequest antworten soll,
        /// da diese Requests nie eine ErrorResponse als Antwort bekommen.
        /// </summary>
        /// <param name="header">Requestheader</param>
        public DriverInternalErrorResponse(RequestHeader header)
        {
            throwExceptionOnDiscoveryRequest(header.Name);
            Header = setHeader(header, RKon.Alexa.NET.Types.HeaderNames.DRIVER_INTERNAL_ERROR);
            Payload = new ResponsePayload();
        }
    }
}
