using Newtonsoft.Json;


namespace RKon.Alexa.NET46.Response.ErrorResponses
{
    /// <summary>
    /// Payload for UnexpectedInformationReceived
    /// </summary>
    public class UnexpectedInformationReceivedPayload : ResponsePayload
    {
        /// <summary>
        /// Parameter that failed
        /// </summary>
        [JsonProperty("faultingParameter")]
        [JsonRequired]
        public string FaultingParameter { get; set; }
        /// <summary>
        /// Constructor. Sets FaultingParameter
        /// </summary>
        /// <param name="faultingParameter"></param>
        public UnexpectedInformationReceivedPayload(string faultingParameter)
        {
            FaultingParameter = faultingParameter;
        }
    }
}
