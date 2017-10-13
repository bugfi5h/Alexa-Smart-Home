using Newtonsoft.Json;
using RKon.Alexa.NET.Payloads;
using RKon.Alexa.NET.Payloads.ErrorResponse;
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
        public EventHeader Header { get; set; }

        /// <summary>
        /// Error Payload
        /// </summary>
        public Payload Payload { get; set; }


        /// <summary>
        /// Initializes the header with the given CorrelationToken and Initializes the Payload as a ErrorPayload
        /// </summary>
        /// <param name="correlationToken"></param>
        /// /// <param name="errorType"></param>
        public ErrorResponseEvent(string correlationToken, ErrorTypes errorType)
        {
            Header = EventHeader.CreateErrorHeader(correlationToken);
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
