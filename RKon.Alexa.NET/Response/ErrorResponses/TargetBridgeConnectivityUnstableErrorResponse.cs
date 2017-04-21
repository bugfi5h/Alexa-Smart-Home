using RKon.Alexa.NET.Request;


namespace RKon.Alexa.NET.Response.ErrorResponses
{
    /// <summary>
    /// Fehlermeldung wenn die Cloud Verbindung zu eine Hub oder einer Bridge, die das Gerät verbindet, nicht stabil ist
    /// </summary>
    public class TargetBridgeConnectivityUnstableErrorResponse : ErrorResponse
    {
        /// <summary>
        /// Konstruktor erstellt Header an Hand vom Requestheader und einen leeren Payload
        /// Schmeißt eine UnvalidDiscoveryResponseException, wenn diese Fehlerresponse auf ein DiscoverApplianceRequest antworten soll,
        /// da diese Requests nie eine ErrorResponse als Antwort bekommen.
        /// </summary>
        /// <param name="header">Requestheader</param>
        public TargetBridgeConnectivityUnstableErrorResponse(RequestHeader header)
        {
            throwExceptionOnDiscoveryRequest(header.Name);
            Header = setHeader(header, RKon.Alexa.NET.Types.HeaderNames.TARGET_BRIDGE_CONNECTIVITY_UNSTABLE_ERROR);
            Payload = new ResponsePayload();
        }
    }
}
