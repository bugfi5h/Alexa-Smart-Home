using RKon.Alexa.NET.Response.Payloads;
using RKon.Alexa.NET.Types;
using Newtonsoft.Json;
using System;

namespace RKon.Alexa.NET.Response
{
    public class UnknownRequestHeaderException : Exception
    {
        public UnknownRequestHeaderException(string requestHeaderName) : base(requestHeaderName + " is not defined") { }
    }

    public class SmartHomeResponse : ISmartHomeResponse
    {
        [JsonRequired]
        [JsonProperty("header")]
        public ResponseHeader Header { get; set; }
        [JsonRequired]
        [JsonProperty("payload")]
        public ResponsePayload Payload { get; set; }

        public System.Type GetResponsePayloadType()
        {
            return Payload?.GetType();
        }

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
                        Payload = new TargetTemperatureResopnsePayload();
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
                    default: throw new UnknownRequestHeaderException(name);
                }
            }else
            {
                throw new ArgumentOutOfRangeException(nameof(Type), $"Unknown Payload Version: {payloadVersion}.");
            }
        }
    }
}
