using Newtonsoft.Json;


namespace RKon.Alexa.NET.Response.Payloads.ErrorPayloads
{
    /// <summary>
    /// Payload für UnexpectedInformationReceived
    /// </summary>
    public class UnexpectedInformationReceivedPayload : ResponsePayload
    {
        /// <summary>
        /// Parameter der gescheitert ist
        /// </summary>
        [JsonProperty("faultingParameter")]
        [JsonRequired]
        public string FaultingParameter { get; set; }
        /// <summary>
        /// Konstruktor. Setzt FaultingParameter
        /// </summary>
        /// <param name="faultingParameter"></param>
        public UnexpectedInformationReceivedPayload(string faultingParameter)
        {
            FaultingParameter = faultingParameter;
        }
    }
}
