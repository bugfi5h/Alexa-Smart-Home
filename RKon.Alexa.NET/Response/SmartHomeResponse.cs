using RKon.Alexa.NET.Types;
using Newtonsoft.Json;
using System;

namespace RKon.Alexa.NET.Response
{
    /// <summary>
    /// Exception, wenn der RequestHeader Name nicht bekannt ist
    /// </summary>
    public class UnknownRequestHeaderException : Exception
    {
        /// <summary>
        /// Exception, wenn der RequestHeader Name nicht bekannt ist
        /// </summary>
        /// <param name="requestHeaderName"> Name des RequestHeader</param>
        public UnknownRequestHeaderException(string requestHeaderName) : base(requestHeaderName + " is not defined") { }
    }
    /// <summary>
    /// Klasse für Smart Home Responses
    /// </summary>
    public class SmartHomeResponse : ISmartHomeResponse
    {
        /// <summary>
        /// Header Inhalt
        /// </summary>
        [JsonRequired]
        [JsonProperty("header")]
        public ResponseHeader Header { get; set; }
        /// <summary>
        /// Payload Inhalt
        /// </summary>
        [JsonRequired]
        [JsonProperty("payload")]
        public ResponsePayload Payload { get; set; }

        /// <summary>
        /// Liefert den Typ des Payloads
        /// </summary>
        /// <returns>System.Type des Payloads</returns>
        public System.Type GetResponsePayloadType()
        {
            return Payload?.GetType();
        }

        /// <summary>
        /// Legt eine SmartHomeResponse mit passendem Header und Payload mit Hilfe des requestHeaders an.
        /// </summary>
        /// <param name="requestHeader">Header des SmartHomeRequests</param>
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
                    default: throw new UnknownRequestHeaderException(name);
                }
            }else
            {
                throw new ArgumentOutOfRangeException(nameof(Type), $"Unknown Payload Version: {payloadVersion}.");
            }
        }
    }
}
