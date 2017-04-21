using RKon.Alexa.NET.Request;

namespace RKon.Alexa.NET.Response.ErrorResponses
{
    /// <summary>
    /// Error response, if the requestlimit of the device is exceeded
    /// </summary>
    public class RateLimitExceededErrorResponse : ErrorResponse
    {
        /// <summary>
        /// Constructor
        /// Throws a  UnvalidDiscoveryResponseException, if this error response is for a  DiscoverApplianceRequest
        /// </summary>
        /// <param name="reqHeader">Requestheader</param>
        /// <param name="rateLimit">Requestlimit</param>
        /// <param name="timeUnit">time unit of the requestlimit</param>
        public RateLimitExceededErrorResponse(RequestHeader reqHeader,string rateLimit, string timeUnit)
        {
            throwExceptionOnDiscoveryRequest(reqHeader.Name);
            Header = setHeader(reqHeader, RKon.Alexa.NET.Types.HeaderNames.RATE_LIMIT_EXCEEDED_ERROR);
            Payload = new RateLimitExceededPayload(rateLimit, timeUnit);
        }
    }
}
