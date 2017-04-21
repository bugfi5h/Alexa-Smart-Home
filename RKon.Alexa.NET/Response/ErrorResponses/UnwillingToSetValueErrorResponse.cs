using RKon.Alexa.NET.Request;

namespace RKon.Alexa.NET.Response.ErrorResponses
{
    /// <summary>
    /// Fehlermeldung, wenn das Gerät den übergebenen Wert nicht setzen will
    /// </summary>
    public class UnwillingToSetValueErrorResponse : ErrorResponse
    {
        /// <summary>
        /// Konstruktor erstellt Header an Hand vom Requestheader und einen Payload mit Fehlercode und Fehlerbeschreibung
        /// Schmeißt eine UnvalidDiscoveryResponseException, wenn diese Fehlerresponse auf ein DiscoverApplianceRequest antworten soll,
        /// da diese Requests nie eine ErrorResponse als Antwort bekommen.
        /// </summary>
        /// <param name="reqHeader">Requestheader</param>
        /// <param name="errorInfoCode">Fehlercode</param>
        /// <param name="errorInfoDescription">Fehlerbeschreibung</param>
        public UnwillingToSetValueErrorResponse(RequestHeader reqHeader, string errorInfoCode, string errorInfoDescription)
        {
            throwExceptionOnDiscoveryRequest(reqHeader.Name);
            Header = setHeader(reqHeader, RKon.Alexa.NET.Types.HeaderNames.UNWILLING_TO_SET_VALUE_ERROR);
            Payload = new UnwillingToSetValuePayload(errorInfoCode, errorInfoDescription);
        }
    }
}
