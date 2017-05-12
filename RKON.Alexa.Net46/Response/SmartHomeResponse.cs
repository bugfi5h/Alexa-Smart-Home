using RKon.Alexa.NET46.Types;
using Newtonsoft.Json;
using System;

namespace RKon.Alexa.NET46.Response
{
    /// <summary>
    /// Exception,if the RequestHeader Name is not known
    /// </summary>
    public class UnknownRequestHeaderException : Exception
    {
        /// <summary>
        /// Exception,if the RequestHeader Name is not known
        /// </summary>
        /// <param name="requestHeaderName"> Name of the RequestHeader</param>
        public UnknownRequestHeaderException(string requestHeaderName) : base(requestHeaderName + " is not defined") { }
    }
    /// <summary>
    /// Class for Smart Home Responses
    /// </summary>
    public class SmartHomeResponse : ISmartHomeResponse
    {
        /// <summary>
        /// Header
        /// </summary>
        [JsonRequired]
        [JsonProperty("header")]
        public ResponseHeader Header { get; set; }
        /// <summary>
        /// Payload
        /// </summary>
        [JsonRequired]
        [JsonProperty("payload")]
        public ResponsePayload Payload { get; set; }

        /// <summary>
        /// System.Type of the Payloads
        /// </summary>
        /// <returns>System.Type of the Payloads</returns>
        public System.Type GetResponsePayloadType()
        {
            return Payload?.GetType();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="requestHeader">Header of the SmartHomeRequests</param>
        public SmartHomeResponse(Request.RequestHeader requestHeader)
        {
            Header = new ResponseHeader(requestHeader);
            getPayload(requestHeader.Name, requestHeader.PayloadVersion);
            
        }

        private void getPayload(string name, string payloadVersion)
        {
            if(payloadVersion == "2")
            {
                switch (name)
                {
                    case HeaderNames.DISCOVERY_REQUEST:
                        Payload = new DiscoverResponsePayload();
                        break;
                    case HeaderNames.SET_TARGET_TEMPERATURE_REQUEST:
                    case HeaderNames.INCREMENT_TARGET_TEMPERATURE_REQUEST:
                    case HeaderNames.DECREMENT_TARGET_TEMPERATURE_REQUEST:
                        Payload = new TargetTemperatureResponsePayload();
                        break;
                    case HeaderNames.TURN_OFF_REQUEST:
                    case HeaderNames.TURN_ON_REQUEST:
                    case HeaderNames.SET_PERCENTAGE_REQUEST:
                    case HeaderNames.DECREMENT_PERCENTAGE_REQUEST:
                    case HeaderNames.INCREMENT_PERCENTAGE_REQUEST:
                        Payload = new ResponsePayload();
                        break;
                    case HeaderNames.HEALTH_CHECK_REQUEST:
                        Payload = new HealthCheckResponsePayload();
                        break;
                    case HeaderNames.SET_COLOR_REQUEST:
                        Payload = new SetColorResponsePayload();
                        break;
                    case HeaderNames.SET_COLOR_TEMPERATURE_REQUEST:
                    case HeaderNames.INCREMENT_COLOR_TEMPERATURE_REQUEST:
                    case HeaderNames.DECREMENT_COLOR_TEMPERATURE_REQUEST:
                        Payload = new ColorTemperatureResponsePayload();
                        break;
                    case HeaderNames.GET_TEMPERATURE_READING_REQUEST:
                        Payload = new GetTemperatureReadingResponsePayload();
                        break;
                    case HeaderNames.GET_TARGET_TEMPERATURE_REQUEST:
                        Payload = new GetTargetTemperatureResponsePayload();
                        break;
                    case HeaderNames.GET_LOCK_STATE_REQUEST:
                        Payload = new GetLockStateResponsePayload();
                        break;
                    case HeaderNames.SET_LOCK_STATE_REQUEST:
                        Payload = new SetLockStateResponsePayload();
                        break;
                    default: throw new UnknownRequestHeaderException(name);
                }
            }else
            {
                throw new ArgumentOutOfRangeException(nameof(Type), $"Unknown Payload Version: {payloadVersion}.");
            }
        }
    }
}
