using RKon.Alexa.NET.Types.PayloadObjects;
using Newtonsoft.Json;


namespace RKon.Alexa.NET.Response.Payloads.ErrorPayloads
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
        /// Konstruktor. Erstellt ErrorInfo Objekt aus Fehlercode und Fehlerbeschreibung
        /// </summary>
        /// <param name="code">Fehlercode</param>
        /// <param name="desc">Fehlerbeschreibung</param>
        public UnwillingToSetValuePayload(string code, string desc)
        {
            ErrorInfo = new ErrorInfo(code, desc);
        }
    }
}
