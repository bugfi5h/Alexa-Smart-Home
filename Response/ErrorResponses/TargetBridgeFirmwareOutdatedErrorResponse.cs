using RKon.Alexa.NET.Request;

namespace RKon.Alexa.NET.Response.ErrorResponses
{
    /// <summary>
    /// Fehlermeldung, wenn die Firmware des Hubs oder der Bridge, die das Geräts verbindet, veraltet ist
    /// </summary>
    public class TargetBridgeFirmwareOutdatedErrorResponse : ErrorResponse
    {
        /// <summary>
        /// Konstruktor erstellt Header an Hand vom Requestheader und einen Payload mit Minimum  und aktueller Firmwareversion
        /// Schmeißt eine UnvalidDiscoveryResponseException, wenn diese Fehlerresponse auf ein DiscoverApplianceRequest antworten soll,
        /// da diese Requests nie eine ErrorResponse als Antwort bekommen.
        /// </summary>
        /// <param name="header">Requestheader</param>
        /// <param name="minimumFirmwareVersion">Minimale Firmwareversion</param>
        /// <param name="currentFirmwareVersion">Aktuelle Firmwareversion</param>
        public TargetBridgeFirmwareOutdatedErrorResponse(RequestHeader header, string minimumFirmwareVersion, string currentFirmwareVersion)
        {
            throwExceptionOnDiscoveryRequest(header.Name);
            Header = setHeader(header, RKon.Alexa.NET.Types.HeaderNames.TARGET_BRIDGE_FIRMWARE_OUTDATED_ERROR);
            Payload = new TargetFirmwareOutdatedPayload(minimumFirmwareVersion, currentFirmwareVersion);
        }
    }
}
