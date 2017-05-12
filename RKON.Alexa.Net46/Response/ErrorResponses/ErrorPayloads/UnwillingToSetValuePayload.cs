using RKon.Alexa.NET46.Types;
using Newtonsoft.Json;


namespace RKon.Alexa.NET46.Response.ErrorResponses
{
    /// <summary>
    /// Payload für UnwillingToSetValue
    /// </summary>
    public class UnwillingToSetValuePayload : ResponsePayload
    {
        /// <summary>
        /// Fehlerinformationen
        /// </summary>
        [JsonRequired]
        [JsonProperty("errorInfo")]
        public ErrorInfo ErrorInfo { get; set; }

        /// <summary>
        /// Construktor. Creates ErrorInfo Object out of the error code and error description
        /// </summary>
        /// <param name="code">ErrorCode</param>
        /// <param name="desc">Error description</param>
        public UnwillingToSetValuePayload(string code, string desc)
        {
            ErrorInfo = new ErrorInfo(code, desc);
        }
    }
}
