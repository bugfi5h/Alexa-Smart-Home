using Newtonsoft.Json;
using RKon.Alexa.NET46.Request;
using RKon.Alexa.NET46.Types;
using System;

namespace RKon.Alexa.NET46.Response
{

    /// <summary>
    /// Exception, wenn versucht wird eine ErrorResponse für ein DiscoverApplianceRequest zu verwenden.
    /// </summary>
    public class UnvalidDiscoveryResponseException : Exception
    {
        /// <summary>
        /// Konstruktor mit Exceptionmeldung.
        /// </summary>
        public UnvalidDiscoveryResponseException() : base("Discovery requests can not be answered by error responses") { }
    }

    /// <summary>
    /// SmartHome Response
    /// </summary>
    public class SmartHomeResponse
    {
        /// <summary>
        /// Context of the event. Can be null
        /// </summary>
        [JsonProperty("context", NullValueHandling = NullValueHandling.Ignore)]
        public Context Context { get; set; }

        /// <summary>
        /// The Event that get send to Alexa
        /// </summary>
        [JsonProperty("event")]
        public Event Event { get; set; }
        
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
        public static SmartHomeResponse CreateChangeReportEvent(bool usePayload)
        {
            SmartHomeResponse sResponse = new SmartHomeResponse();
            sResponse.Event = Response.Event.CreateChangeReportEvent(usePayload);
            return sResponse;
        }

        /// <summary>
        /// Creates a ErrorResponse with given RequestHeader and the Error Type. If needed a special Namespace can be given.
        /// </summary>
        /// <param name="header"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static SmartHomeResponse CreateErrorResponse(DirectiveHeader header, ErrorTypes type)
        {
            if(header.Name == HeaderNames.DISCOVERY_REQUEST)
            {
                throw new UnvalidDiscoveryResponseException();
            }
            SmartHomeResponse sResponse = new SmartHomeResponse();
            sResponse.Event = RKon.Alexa.NET46.Response.Event.CreateErrorEvent(header.CorrelationToken, type, header.Namespace);
            return sResponse;
        }

        /// <summary>
        /// Creates a Deffered SmarthomeResponse
        /// </summary>
        /// <returns></returns>
        public static SmartHomeResponse CreateDefferedResponse()
        {
            SmartHomeResponse sResponse = new SmartHomeResponse();
            sResponse.Event = Response.Event.CreateDefferedResponse();
            return sResponse;
        }
    }
}
