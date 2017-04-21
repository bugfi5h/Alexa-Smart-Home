using RKon.Alexa.NET.Request;

namespace RKon.Alexa.NET.Response.ErrorResponses
{
    /// <summary>
    /// Fehlermeldung, wenn die Request Nachricht oder der Payload nicht vom Skilladapter verarbeitet werden konnte.
    /// </summary>
    public class UnexpectedInformationReceivedErrorResponse : ErrorResponse
    {
        /// <summary>
        /// Konstruktor erstellt Header an Hand vom Requestheader und einen Payload mit dem Parameter, der nicht verwertbar war
        /// Schmeißt eine UnvalidDiscoveryResponseException, wenn diese Fehlerresponse auf ein DiscoverApplianceRequest antworten soll,
        /// da diese Requests nie eine ErrorResponse als Antwort bekommen.
        /// </summary>
        /// <param name="reqHeader">Requestheader</param>
        /// <param name="faultingParameter">Parameter, der nicht verwertbar war</param>
        public UnexpectedInformationReceivedErrorResponse(RequestHeader reqHeader, string faultingParameter)
        {
            throwExceptionOnDiscoveryRequest(reqHeader.Name);
            Header = setHeader(reqHeader, RKon.Alexa.NET.Types.HeaderNames.UNEXCEPTED_INFORMATION_RECEIVED_ERROR);
            Payload = new UnexpectedInformationReceivedPayload(faultingParameter);
        }
    }
}
