using RKon.Alexa.NET.Request;

namespace RKon.Alexa.NET.Response.ErrorResponses
{
    /// <summary>
    /// Fehlerantwort, wenn ein Request einen Wert einstellen will, der sich nicht in der vom Gerät akzeptierten Wertspanne befindet.
    /// </summary>
    public class ValueOutOfRangeErrorResponse : ErrorResponse
    {
        /// <summary>
        /// Konstruktor. Setzt header an Hand des Requestheaders und Payload mit minimal und Maximalwert
        /// Schmeißt eine UnvalidDiscoveryResponseException, wenn diese Fehlerresponse auf ein DiscoverApplianceRequest antworten soll,
        /// da diese Requests nie eine ErrorResponse als Antwort bekommen.
        /// </summary>
        /// <param name="reqHeader">Requestheader</param>
        /// <param name="minimumValue">Minimalwert</param>
        /// <param name="maximumValue">Maximalwert</param>
        public ValueOutOfRangeErrorResponse(RequestHeader reqHeader, double minimumValue, double maximumValue)
        {
            throwExceptionOnDiscoveryRequest(reqHeader.Name);
            Header = setHeader(reqHeader, RKon.Alexa.NET.Types.HeaderNames.VALUE_OUT_OF_RANGE_ERROR);
            Payload = new ValueOutOfRangePayload(minimumValue, maximumValue);
        }
    }
}
