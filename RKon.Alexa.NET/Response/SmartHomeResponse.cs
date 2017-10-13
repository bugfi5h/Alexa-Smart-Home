﻿using Newtonsoft.Json;
using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Types;
using System;

namespace RKon.Alexa.NET.Response
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
        /// Creates a ErrorResponse with given RequestHeader and the Error Type
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
            sResponse.Event = new ErrorResponseEvent(header.CorrelationToken, type);
            return sResponse;
        }

    }
}
