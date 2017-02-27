using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Response.Payloads.ErrorPayloads;

namespace RKon.Alexa.NET.Response.ErrorResponses
{
    /// <summary>
    /// Fehlermeldung, wenn die Firmware des Geräts veraltet ist
    /// </summary>
    public class TargetFirmwareOutdatedErrorResponse : ErrorResponse
    {
        /// <summary>
        /// Konstruktor erstellt Header an Hand vom Requestheader und einen Payload mit Minimum  und aktueller Firmwareversion
        /// Schmeißt eine UnvalidDiscoveryResponseException, wenn diese Fehlerresponse auf ein DiscoverApplianceRequest antworten soll,
        /// da diese Requests nie eine ErrorResponse als Antwort bekommen.
        /// </summary>
        /// <param name="reqHeader">Requestheader</param>
        /// <param name="minimumFirmwareVersion">Minimale Firmwareversion</param>
        /// <param name="currentFirmwareVersion">Aktuelle Firmwareversion</param>
        public TargetFirmwareOutdatedErrorResponse(RequestHeader reqHeader,string minimumFirmwareVersion,string currentFirmwareVersion)
        {
            throwExceptionOnDiscoveryRequest(reqHeader.Name);
            Header = setHeader(reqHeader, RKon.Alexa.NET.Types.HeaderNames.TARGET_FIRMWARE_OUTDATED_ERROR);
            Payload = new TargetFirmwareOutdatedPayload(minimumFirmwareVersion, currentFirmwareVersion);
        }
    }
}
