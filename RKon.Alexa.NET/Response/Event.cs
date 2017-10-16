
using System;
using Newtonsoft.Json;
using RKon.Alexa.NET.Types;
using RKon.Alexa.NET.JsonObjects;
using RKon.Alexa.NET.Payloads;
using RKon.Alexa.NET.Payloads.Response;
using RKon.Alexa.NET.Request;

namespace RKon.Alexa.NET.Response
{
    /// <summary>
    /// Exception,if the Header Name is not known
    /// </summary>
    public class UnknownHeaderException : Exception
    {
        /// <summary>
        /// Exception,if the RequestHeader Name is not known
        /// </summary>
        /// <param name="HeaderName"> Name of the RequestHeader</param>
        public UnknownHeaderException(string HeaderName) : base(HeaderName + " is not defined") { }
    }

    /// <summary>
    /// Response of Directives
    /// </summary>
    [JsonConverter(typeof(EventConverter))]
    public class Event : IEvent
    {
        /// <summary>
        /// Eventheader
        /// </summary>
        [JsonProperty("header")]
        [JsonRequired]
        public EventHeader Header { get; set; }
        /// <summary>
        /// Eventpayload
        /// </summary>
        [JsonProperty("payload")]
        [JsonRequired]
        public Payload Payload { get; set; }
        /// <summary>
        /// Endpoint
        /// </summary>
        [JsonProperty("endpoint", NullValueHandling = NullValueHandling.Ignore)]
        public Endpoint Endpoint { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="requestHeader">Header of the Directice</param>
        public Event(DirectiveHeader requestHeader)
        {
            if(requestHeader.PayloadVersion != "3")
            {
                throw new ArgumentOutOfRangeException(nameof(Type), $"Not supported Payload Version: {requestHeader.PayloadVersion}. Only Version 3 is supported");
            }
            Header = new EventHeader(requestHeader);
            Payload = _GetPayloadForEvent(requestHeader.Namespace);
            
        }
        /// <summary>
        /// Standard Constructor
        /// </summary>
        public Event()
        {
        }

        /// <summary>
        /// Creates a Event For a ChangeReport. 
        /// </summary>
        /// <param name="usePayload">Determines if a empty Payload is initialized or a ChangeReportPayload</param>
        /// <returns></returns>
        public static Event CreateChangeReportEvent(bool usePayload)
        {
            Event _event = new Event();
            _event.Header = EventHeader.CreateChangeReportHeader();
            if (usePayload)
            {
                _event.Payload = new ChangeReportPayload();
            }else
            {
                _event.Payload = new Payload();
            }
            return _event;
        }

        /// <summary>
        /// Creates a Event For a DefferedResponse. 
        /// </summary>
        /// <returns></returns>
        public static Event CreateDefferedResponse()
        {
            Event _event = new Event();
            _event.Header = EventHeader.CreateDefferedResponseHeader();
            _event.Payload = new DefferedResponsePayload();
            return _event;
        }

        internal Payload _GetPayloadForEvent(string _namespace)
        {
            switch (_namespace)
            {
                case Namespaces.ALEXA_DISCOVERY:
                    return new DisoveryPayload();
                case Namespaces.ALEXA_CAMERASTREAMCONTROLLER:
                    return new ResponseCameraStreamsPayload();
                case Namespaces.ALEXA_BRIGHTNESSCONTROLLER:
                case Namespaces.ALEXA_CHANNELCONTROLLER:
                case Namespaces.ALEXA_COLORCONTROLLER:
                case Namespaces.ALEXA_POWERCONTROLLER:
                case Namespaces.ALEXA_POWERLEVELCONTROLLER:
                case Namespaces.ALEXA_COLORTEMPERATURECONTROLLER:
                case Namespaces.ALEXA_INPUTCONTROLLER:
                case Namespaces.ALEXA_PLAYBACKCONTROLLER:
                case Namespaces.ALEXA_SPEAKER:
                case Namespaces.ALEXA_STEPSPEAKER:
                case Namespaces.ALEXA:
                    return new Payload();
                default:
                    throw new UnknownHeaderException(_namespace);
            }
        }
    }
}
