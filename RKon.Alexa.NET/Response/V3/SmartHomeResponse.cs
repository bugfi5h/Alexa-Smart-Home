using Newtonsoft.Json;

namespace RKon.Alexa.NET.Response.V3
{
    /// <summary>
    /// SmartHome Response
    /// </summary>
    public class SmartHomeResponse
    {
        /// <summary>
        /// The Event that get send to Alexa
        /// </summary>
        [JsonProperty("event")]
        public Event Event { get; set; }
        
        /// <summary>
        /// System.Type of the Payloads
        /// </summary>
        /// <returns>System.Type of the Payloads</returns>
        public System.Type GetResponsePayloadType()
        {
            return Event?.Payload?.GetType();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="requestHeader">Header of the SmartHomeRequests</param>
        public SmartHomeResponse(Request.V3.DirectiveHeader requestHeader)
        {
            Event = new Event(requestHeader);
        }

    }
}
