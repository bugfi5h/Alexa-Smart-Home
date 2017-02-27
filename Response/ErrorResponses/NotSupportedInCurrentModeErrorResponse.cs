using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Response.Payloads.ErrorPayloads;
using System;
namespace RKon.Alexa.NET.Response.ErrorResponses
{
    /// <summary>
    /// Fehlermeldung, wenn das Gerät sich in einem Modus befindet, in der es sich nicht mit der Smart Home Skill API kontrollieren lässt
    /// </summary>
    public class NotSupportedInCurrentModeErrorResponse : ErrorResponse
    {
        /// <summary>
        /// Konstruktor. currentDeviceMode muss einen validen Modus übergeben bekommen. Diese findet man unter RKon.Alexa.NET.Types.DeviceModes.Modes.
        /// Falls eine ungültige Eingabe getätigt wird, wird CurrentDeviceMode auf OTHER gesetzt.
        /// Schmeißt eine UnvalidDiscoveryResponseException, wenn diese Fehlerresponse auf ein DiscoverApplianceRequest antworten soll,
        /// da diese Requests nie eine ErrorResponse als Antwort bekommen.
        /// </summary>
        /// <param name="reqHeader">Requestheader</param>
        /// <param name="currentDeviceMode">Aktiver Modus des Geräts</param>
        public NotSupportedInCurrentModeErrorResponse(RequestHeader reqHeader, string currentDeviceMode)
        {
            throwExceptionOnDiscoveryRequest(reqHeader.Name);
            Header = setHeader(reqHeader, RKon.Alexa.NET.Types.HeaderNames.NOT_SUPPORTED_IN_CURRENT_MODE_ERROR);
            Payload = new NotSupportedInCurrentModePayload(currentDeviceMode);
        }
    }
}
