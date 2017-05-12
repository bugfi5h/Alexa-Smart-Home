using RKon.Alexa.NET46.Request;

namespace RKon.Alexa.NET46.Response.ErrorResponses
{
    /// <summary>
    /// error response if the target is unwilling to set the value
    /// </summary>
    public class UnwillingToSetValueErrorResponse : ErrorResponse
    {
        /// <summary>
        /// Constructor
        /// Throws a  UnvalidDiscoveryResponseException, if this error response is for a  DiscoverApplianceRequest
        /// </summary>
        /// <param name="reqHeader">Requestheader</param>
        /// <param name="errorInfoCode">Error code</param>
        /// <param name="errorInfoDescription">Error description</param>
        public UnwillingToSetValueErrorResponse(RequestHeader reqHeader, string errorInfoCode, string errorInfoDescription)
        {
            throwExceptionOnDiscoveryRequest(reqHeader.Name);
            Header = setHeader(reqHeader, RKon.Alexa.NET46.Types.HeaderNames.UNWILLING_TO_SET_VALUE_ERROR);
            Payload = new UnwillingToSetValuePayload(errorInfoCode, errorInfoDescription);
        }
    }
}
