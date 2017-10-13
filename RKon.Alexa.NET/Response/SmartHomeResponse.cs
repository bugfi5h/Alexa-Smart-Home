using Newtonsoft.Json;
using RKon.Alexa.NET.Request;

namespace RKon.Alexa.NET.Response
{
    /// <summary>
    /// SmartHome Response
    /// </summary>
    [JsonConverter(typeof(SmartHomeResponseConverter))]
    public class SmartHomeResponse
    {
        /// <summary>
        /// The Event that get send to Alexa
        /// </summary>
        [JsonProperty("event")]
        public IEvent Event { get; set; }
        
        /// <summary>
        /// System.Type of the Payloads
        /// </summary>
        /// <returns>System.Type of the Payloads</returns>
        public System.Type GetPayloadType()
        {
            return Event?.Payload?.GetType();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="requestHeader">Header of the SmartHomeRequests</param>
        public SmartHomeResponse(DirectiveHeader requestHeader)
        {
            Event = new Event(requestHeader);
        }

        /// <summary>
        /// Basic Constructor
        /// </summary>
        public SmartHomeResponse()
        {
        }

        /// <summary>
        /// Creates a ChangeReportEvent.
        /// </summary>
        /// <returns></returns>
        public static SmartHomeResponse CreateChangeReportEvent()
        {
            SmartHomeResponse sResponse = new SmartHomeResponse();
            sResponse.Event = new Event();
            return sResponse;
        }

        /// <summary>
        /// Creates a ErrorResponse.
        /// </summary>
        /// <returns></returns>
        public static SmartHomeResponse CreateErrorResponse()
        {
            SmartHomeResponse sResponse = new SmartHomeResponse();
            sResponse.Event = new ErrorResponseEvent();
            return sResponse;
        }

    }
}
