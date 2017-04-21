using RKon.Alexa.NET.Request;

namespace RKon.Alexa.NET.Response.ErrorResponses
{
    /// <summary>
    /// Error response, if a request wants to set a value that is out of range.
    /// </summary>
    public class ValueOutOfRangeErrorResponse : ErrorResponse
    {
        /// <summary>
        /// Constructor
        /// Throws a  UnvalidDiscoveryResponseException, if this error response is for a  DiscoverApplianceRequest
        /// </summary>
        /// <param name="reqHeader">Requestheader</param>
        /// <param name="minimumValue">Minimun supported value</param>
        /// <param name="maximumValue">Maximum supported value</param>
        public ValueOutOfRangeErrorResponse(RequestHeader reqHeader, double minimumValue, double maximumValue)
        {
            throwExceptionOnDiscoveryRequest(reqHeader.Name);
            Header = setHeader(reqHeader, RKon.Alexa.NET.Types.HeaderNames.VALUE_OUT_OF_RANGE_ERROR);
            Payload = new ValueOutOfRangePayload(minimumValue, maximumValue);
        }
    }
}
