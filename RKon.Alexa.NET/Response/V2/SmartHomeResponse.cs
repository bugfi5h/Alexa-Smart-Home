using RKon.Alexa.NET.Types;
using Newtonsoft.Json;
using System;

namespace RKon.Alexa.NET.Response
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
                    case HeaderNames.V2.DISCOVERY_REQUEST:
                        Payload = new DiscoverResponsePayload();
                        break;
                    case HeaderNames.V2.SET_TARGET_TEMPERATURE_REQUEST:
                    case HeaderNames.V2.INCREMENT_TARGET_TEMPERATURE_REQUEST:
                    case HeaderNames.V2.DECREMENT_TARGET_TEMPERATURE_REQUEST:
                        Payload = new TargetTemperatureResponsePayload();
                        break;
                    case HeaderNames.V2.TURN_OFF_REQUEST:
                    case HeaderNames.V2.TURN_ON_REQUEST:
                    case HeaderNames.V2.SET_PERCENTAGE_REQUEST:
                    case HeaderNames.V2.DECREMENT_PERCENTAGE_REQUEST:
                    case HeaderNames.V2.INCREMENT_PERCENTAGE_REQUEST:
                        Payload = new ResponsePayload();
                        break;
                    case HeaderNames.V2.HEALTH_CHECK_REQUEST:
                        Payload = new HealthCheckResponsePayload();
                        break;
                    case HeaderNames.V2.SET_COLOR_REQUEST:
                        Payload = new SetColorResponsePayload();
                        break;
                    case HeaderNames.V2.SET_COLOR_TEMPERATURE_REQUEST:
                    case HeaderNames.V2.INCREMENT_COLOR_TEMPERATURE_REQUEST:
                    case HeaderNames.V2.DECREMENT_COLOR_TEMPERATURE_REQUEST:
                        Payload = new ColorTemperatureResponsePayload();
                        break;
                    case HeaderNames.V2.GET_TEMPERATURE_READING_REQUEST:
                        Payload = new GetTemperatureReadingResponsePayload();
                        break;
                    case HeaderNames.V2.GET_TARGET_TEMPERATURE_REQUEST:
                        Payload = new GetTargetTemperatureResponsePayload();
                        break;
                    case HeaderNames.V2.GET_LOCK_STATE_REQUEST:
                        Payload = new GetLockStateResponsePayload();
                        break;
                    case HeaderNames.V2.SET_LOCK_STATE_REQUEST:
                        Payload = new SetLockStateResponsePayload();
                        break;
                    case HeaderNames.V2.RETRIEVE_CAMERA_STREAM_URI_REQUEST:
                        Payload = new RetrieveCameraStreamUriResponsePayload();
                        break;
                    default: throw new UnknownRequestHeaderException(name);
                }
            }else
            {
                throw new ArgumentOutOfRangeException(nameof(Type), $"Unknown Payload Version: {payloadVersion}.");
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public SmartHomeResponse()
        {

        }
    }
}
