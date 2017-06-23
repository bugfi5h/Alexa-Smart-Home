using RKon.Alexa.NET.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace RKon.Alexa.NET.Request.RequestPayloads
{
    /// <summary>
    /// JsonConverter for the creation of SmartHomeRequests
    /// </summary>
    public class SmartHomeRequestConverter : JsonConverter
    {
        /// <summary>
        /// 
        /// </summary>
        public override bool CanWrite => false;
        /// <summary>
        /// Returns, if the object can be converted
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(System.Type objectType)
        {
            return objectType == typeof(SmartHomeRequest);
        }
        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Reads Json in a Objekt und creates a SmartHomeRequest
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, JsonSerializer serializer)
        {
            SmartHomeRequest req = new SmartHomeRequest();
            req.Header = new RequestHeader();
            string headerName = null;
            string payloadVersion = null;
            // Load JObject from stream
            var jObject = JObject.Load(reader);
            headerName = jObject["header"]["name"].Value<string>();
            payloadVersion = jObject["header"]["payloadVersion"].Value<string>();
            if (!String.IsNullOrEmpty(headerName) && !String.IsNullOrEmpty(payloadVersion))
            {
                req.Payload = Create(headerName, payloadVersion);
            }else
            {
                throw new InvalidOperationException("Empty request type.");
            }
            serializer.Populate(jObject.CreateReader(), req);

            return req;
        }
        /// <summary>
        /// returns the payload for the specific requesttype
        /// </summary>
        /// <param name="requestType">Name of the Requests></param>
        /// <param name="payloadVersion">Version of the Payloads</param>
        /// <returns></returns>
        public RequestPayload Create(string requestType, string payloadVersion)
        {
            if(payloadVersion == "2")
            {
                switch (requestType)
                {
                    case HeaderNames.DISCOVERY_REQUEST:
                        return new DiscoveryRequestPayload();
                    case HeaderNames.TURN_OFF_REQUEST:
                    case HeaderNames.TURN_ON_REQUEST:
                        return new TurnOnOffRequestPayload();
                    case HeaderNames.HEALTH_CHECK_REQUEST:
                        return new HealthCheckRequestPayload();
                    case HeaderNames.DECREMENT_TARGET_TEMPERATURE_REQUEST:
                    case HeaderNames.INCREMENT_TARGET_TEMPERATURE_REQUEST:
                        return new In_DecrementTemperatureRequestPayload();
                    case HeaderNames.SET_TARGET_TEMPERATURE_REQUEST:
                        return new SetTemperatureRequestPayload();
                    case HeaderNames.DECREMENT_PERCENTAGE_REQUEST:
                    case HeaderNames.INCREMENT_PERCENTAGE_REQUEST:
                        return new In_DecrementPercentageRequestPayload();
                    case HeaderNames.SET_PERCENTAGE_REQUEST:
                        return new SetPercentageRequestPayload();
                    case HeaderNames.SET_COLOR_REQUEST:
                        return new SetColorRequestPayload();
                    case HeaderNames.SET_COLOR_TEMPERATURE_REQUEST:
                        return new ColorTemperatureRequestPayload();
                    case HeaderNames.INCREMENT_COLOR_TEMPERATURE_REQUEST:
                    case HeaderNames.DECREMENT_COLOR_TEMPERATURE_REQUEST:
                        return new In_DecrementColorTemperatureRequestPayload();
                    case HeaderNames.GET_TEMPERATURE_READING_REQUEST:
                    case HeaderNames.GET_TARGET_TEMPERATURE_REQUEST:
                        return new GetTemperatureRequestPayload();
                    case HeaderNames.GET_LOCK_STATE_REQUEST:
                        return new GetLockStateRequestPayload();
                    case HeaderNames.SET_LOCK_STATE_REQUEST:
                        return new SetLockStateRequestPayload();
                    case HeaderNames.RETRIEVE_CAMERA_STREAM_URI_REQUEST:
                        return new RetrieveCameraStreamUriRequestPayload();
                    default:
                        throw new ArgumentOutOfRangeException(nameof(Type), $"Unknown request type: {requestType}.");
                }
            }
            throw new ArgumentOutOfRangeException(nameof(Type), $"Unknown Payload Version: {payloadVersion}.");
        }
    }
}
