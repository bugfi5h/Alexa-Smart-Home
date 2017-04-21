using RKon.Alexa.NET.Request;

namespace RKon.Alexa.NET.Response.ErrorResponses
{
    /// <summary>
    /// Fehlermeldung wenn eine Dependency nicht erreichbar ist.
    /// </summary>
    public class DependentServiceUnavailableErrorResponse : ErrorResponse
    {
        /// <summary>
        /// Konstruktor. Erstellt an Hand des Requestheaders den Header und den Payload mit dem Namen des Services, der nicht erreichbar ist.      
        /// Schmeißt eine UnvalidDiscoveryResponseException, wenn diese Fehlerresponse auf ein DiscoverApplianceRequest antworten soll,
        /// da diese Requests nie eine ErrorResponse als Antwort bekommen.
        /// </summary>
        /// <param name="reqHeader">Requestheader</param>
        /// <param name="serviceName">Name des Services, der nicht erreichbar ist</param>
        public DependentServiceUnavailableErrorResponse(RequestHeader reqHeader,string serviceName)
        {
            throwExceptionOnDiscoveryRequest(reqHeader.Name);
            Header = setHeader(reqHeader, RKon.Alexa.NET.Types.HeaderNames.DEPENDENT_SERVICE_UNAVAILABLE_ERROR);
            Payload = new DependentServiceUnavailablePayload(serviceName);
        }
    }
}
