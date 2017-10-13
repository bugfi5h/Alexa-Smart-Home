using System;
using Newtonsoft.Json;
using RKon.Alexa.NET.Payloads;

namespace RKon.Alexa.NET.Response
{
    /// <summary>
    /// Error Responses
    /// </summary>
    public class ErrorResponseEvent : IEvent
    {
        public EventHeader Header { get; set; }

        public Payload Payload { get; set; }
    }
}
