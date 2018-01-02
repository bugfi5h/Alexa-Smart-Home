
using System;
using Newtonsoft.Json;
using RKon.Alexa.NET46.Types;
using RKon.Alexa.NET46.JsonObjects;
using RKon.Alexa.NET46.Payloads;
using RKon.Alexa.NET46.Request;

namespace RKon.Alexa.NET46.Response
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
    public class Event
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

        /// <summary>
        /// Creates a Event For a DefferedResponse. 
        /// </summary>
        /// <param name="correlationToken"></param>
        /// <param name="errorType"></param>
        /// <param name="hNamespace"></param>
        /// <returns></returns>
        public static Event CreateErrorEvent(string correlationToken, ErrorTypes errorType, string hNamespace)
        {
            Event _event = new Event();
            _event.Header = EventHeader.CreateErrorHeader(correlationToken, hNamespace);
            _event.Payload = _event._GetPayloadForErrorType(errorType);
            (_event.Payload as ErrorPayload).Type = errorType;
            return _event;
        }

        internal Payload _GetPayloadForEvent(string _namespace)
        {
            switch (_namespace)
            {
                case Namespaces.ALEXA_DISCOVERY:
                    return new DiscoveryPayload();
                case Namespaces.ALEXA_CAMERASTREAMCONTROLLER:
                    return new ResponseCameraStreamsPayload();
                case Namespaces.ALEXA_SCENECONTROLLER:
                    return new SceneStartedResponsePayload();
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
                case Namespaces.ALEXA_LOCKCONTROLLER:
                case Namespaces.ALEXA_THERMOSTATCONTROLLER:
                case Namespaces.ALEXA_TEMPERATURESENSOR:
                case Namespaces.ALEXA_PERCENTAGECONTROLLER:
                case Namespaces.ALEXA_AUTHORIZATION:
                    return new Payload();
                default:
                    throw new UnknownHeaderException(_namespace);
            }
        }

        internal ErrorPayload _GetPayloadForErrorType(ErrorTypes errorType)
        {
            switch (errorType)
            {
                case ErrorTypes.VALUE_OUT_OF_RANGE:
                    return new ValueOutRangeErrorPayload();
                case ErrorTypes.TEMPERATURE_VALUE_OUT_OF_RANGE:
                    return new TemperatureOutOfRangeErrorPayload();
                case ErrorTypes.NOT_SUPPORTED_IN_CURRENT_MODE:
                    return new NotSupportedInCurrentModeErrorPayload();
                case ErrorTypes.ENDPOINT_LOW_POWER:
                    return new EndpointLowPowerErrorPayload();
                case ErrorTypes.REQUESTED_SETPOINTS_TOO_CLOSE:
                    return new RequestedSetpointsTooCloseErrorPayload();
                default:
                    return new ErrorPayload();
            }
        }
    }
}
