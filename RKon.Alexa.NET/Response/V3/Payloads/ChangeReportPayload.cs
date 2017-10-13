using Newtonsoft.Json;
using RKon.Alexa.NET.JsonObjects;
using RKon.Alexa.NET.Request;

namespace RKon.Alexa.NET.Response.V3.Payloads
{
    /// <summary>
    /// Payload of a Changereport if used. You must only report the value for a property in one place in an event, either the payload or the context, but not both.
    /// </summary>
    public class ChangeReportPayload : Payload
    {
        /// <summary>
        /// Specifies the cause of the change
        /// </summary>
        [JsonProperty("change")]
        [JsonRequired]
        public Change Change { get;  set; }
    }
}
