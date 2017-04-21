﻿using RKon.Alexa.NET.Request;

namespace RKon.Alexa.NET.Response.ErrorResponses
{
    /// <summary>
    /// Fehlermeldung, wenn das angesprochene Gerät nicht vom Skill Adapter unterstützt wird.
    /// </summary>
    public class UnsupportedTargetErrorResponse : ErrorResponse
    {
        /// <summary>
        /// Konstruktor erstellt Header an Hand vom Requestheader und einen leeren Payload
        /// Schmeißt eine UnvalidDiscoveryResponseException, wenn diese Fehlerresponse auf ein DiscoverApplianceRequest antworten soll,
        /// da diese Requests nie eine ErrorResponse als Antwort bekommen.
        /// </summary>
        /// <param name="header">Requestheader</param>
        public UnsupportedTargetErrorResponse(RequestHeader header)
        {
            throwExceptionOnDiscoveryRequest(header.Name);
            Header = setHeader(header, RKon.Alexa.NET.Types.HeaderNames.UNSUPPORTED_TARGET_ERROR);
            Payload = new ResponsePayload();
        }
    }
}