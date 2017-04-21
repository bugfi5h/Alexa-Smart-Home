using RKon.Alexa.NET.Request;

namespace RKon.Alexa.NET.Response.ErrorResponses
{
    /// <summary>
    /// Fehlermeldung, wenn das Requestlimit des Geräts überschritten ist
    /// </summary>
    public class RateLimitExceededErrorResponse : ErrorResponse
    {
        /// <summary>
        /// Konstruktor erstellt Header an Hand vom Requestheader und einen Payload mit Requestlimit und Zeiteinheit für das RequestLimit (HOUR,DAY oder MINUTE)
        /// Schmeißt eine UnvalidDiscoveryResponseException, wenn diese Fehlerresponse auf ein DiscoverApplianceRequest antworten soll,
        /// da diese Requests nie eine ErrorResponse als Antwort bekommen.
        /// </summary>
        /// <param name="reqHeader">Requestheader</param>
        /// <param name="rateLimit">Requestlimit</param>
        /// <param name="timeUnit">Zeiteinheit für das Requestlimit</param>
        public RateLimitExceededErrorResponse(RequestHeader reqHeader,string rateLimit, string timeUnit)
        {
            throwExceptionOnDiscoveryRequest(reqHeader.Name);
            Header = setHeader(reqHeader, RKon.Alexa.NET.Types.HeaderNames.RATE_LIMIT_EXCEEDED_ERROR);
            Payload = new RateLimitExceededPayload(rateLimit, timeUnit);
        }
    }
}
