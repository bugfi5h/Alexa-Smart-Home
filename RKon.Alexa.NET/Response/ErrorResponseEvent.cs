using Newtonsoft.Json;
using RKon.Alexa.NET.JsonObjects;
using RKon.Alexa.NET.Payloads;
using RKon.Alexa.NET.Types;

namespace RKon.Alexa.NET.Response
{
    /// <summary>
    /// Error Responses
    /// </summary>
    [JsonConverter(typeof(ErrorResponseEventConverter))]
    public class ErrorResponseEvent : IEvent
    {
        /// <summary>
        /// Error Header
        /// </summary>
        [JsonProperty("header")]
        public EventHeader Header { get; set; }

        /// <summary>
        /// Error Payload
        /// </summary>
        [JsonProperty("payload")]
        public Payload Payload { get; set; }

        /// <summary>
        /// Endpoint if needed
        /// </summary>
        [JsonProperty("endpoint",NullValueHandling=NullValueHandling.Ignore)]
        public Endpoint Endpoint { get; set; }


        /// <summary>
        /// Initializes the header with the given CorrelationToken and Initializes the Payload as a ErrorPayload
        /// If specialNamespace is != null its value will be placed in the header instead of the general ALEXA Namespace
        /// </summary>
        /// <param name="correlationToken"></param>
        /// <param name="errorType"></param>
        /// <param name="specialNamespace"></param>
        public ErrorResponseEvent(string correlationToken, ErrorTypes errorType, string specialNamespace = null)
        {
            Header = EventHeader.CreateErrorHeader(correlationToken, specialNamespace);
            Payload = _GetPayloadForErrorType(errorType);
        }

        internal Payload _GetPayloadForErrorType(ErrorTypes errorType)
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

        /// <summary>
        /// Standartconstructor
        /// </summary>
        public ErrorResponseEvent()
        {
        }
    }
}
