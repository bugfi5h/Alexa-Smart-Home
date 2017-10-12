using RKon.Alexa.NET.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using RKon.Alexa.NET.Request.RequestPayloads;
using RKon.Alexa.NET.Request.V3;
using RKon.Alexa.NET.Request.V3.Payloads;

namespace RKon.Alexa.NET.Request
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
            var jObject = JObject.Load(reader);
            string headerName = jObject["header"]?["name"]?.Value<string>();
            string payloadVersion = jObject["header"]?["payloadVersion"]?.Value<string>();
            string headerNamespace = jObject["header"]?["namespace"]?.Value<string>();
            object req = null;
            if (!String.IsNullOrEmpty(headerName) && !String.IsNullOrEmpty(payloadVersion) && !String.IsNullOrEmpty(headerNamespace))
            {
                if(payloadVersion == "2")
                {
                    req = new SmartHomeRequest();
                    (req as SmartHomeRequest).Payload = CreateV2Payload(headerName);
                }else if(payloadVersion == "3")
                {
                    req = new Directive();
                    (req as Directive).Payload = CreateV3Payload(headerName, headerNamespace);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(Type), $"Unknown Payload Version: {payloadVersion}.");
                }
            }
            else
            {
                throw new InvalidOperationException("Empty request type.");
            }
            serializer.Populate(jObject.CreateReader(), req);

            return req;
        }

        private Payload CreateV3Payload(string requestType, string namespaceType)
        {
            switch (requestType)
            {
                case HeaderNames.V3.DISCOVERY_REQUEST:
                    return new RequestPayloadWithScope();
                case HeaderNames.V3.SET_POWER_LEVEL:
                    return new PowerLeverRequestPayload();
                case HeaderNames.V3.ADJUST_POWER_LEVEL:
                    return new AdjustPowerLeverRequestPayload();
                case HeaderNames.V3.SETTARGETTEMPERATURE:
                    return new SetTargetTemperatureRequestPayload();
                case HeaderNames.V3.ADJUSTTARGETTEMPERATURE:
                    return new AdjustTargetTemperatureRequestPayload();
                case HeaderNames.V3.SET_PERCENTAGE:
                    return new V3.Payloads.SetPercentageRequestPayload();
                case HeaderNames.V3.ADJUST_PERCENTAGE:
                    return new AdjustPercentageRequestPayload();
                case HeaderNames.V3.SET_BRIGHTNESS:
                    return new SetBrightnessRequestPayload();
                case HeaderNames.V3.ADJUST_BRIGHTNESS:
                    return new AdjustBrightnessRequestPayload();
                case HeaderNames.V3.SET_COLOR:
                    return new V3.Payloads.SetColorRequestPayload();
                case HeaderNames.V3.SET_COLORTEMPERATURE:
                    return new SetColorTemperatureRequestPayload();
                case HeaderNames.V3.INIT_CAMERA_STREAMS:
                    return new InitializeCameraRequestPayload();
                case HeaderNames.V3.CHANGE_CHANNEL:
                    return new ChangeChannelRequestPayload();
                case HeaderNames.V3.SKIP_CHANNELS:
                    return new SkipChannelRequestPayload();
                case HeaderNames.V3.SELECT_INPUT:
                    return new SelectInputRequestPayload();
                case HeaderNames.V3.SET_MUTE:
                    return new SetMuteRequestPayload();
                case HeaderNames.V3.SET_VOLUME:
                    return new SetVolumeRequestPayload();
                case HeaderNames.V3.FAST_FORWARD:
                case HeaderNames.V3.NEXT:
                case HeaderNames.V3.PAUSE:
                case HeaderNames.V3.PLAY:
                case HeaderNames.V3.PREVIOUS:
                case HeaderNames.V3.REWIND:
                case HeaderNames.V3.START_OVER:
                case HeaderNames.V3.STOP:
                case HeaderNames.V3.TURN_ON_REQUEST:
                case HeaderNames.V3.TURN_OFF_REQUEST:
                case HeaderNames.V3.REPORT_STATE:
                case HeaderNames.V3.LOCK:
                case HeaderNames.V3.UNLOCK:
                case HeaderNames.V3.INCREASE_COLORTEMPERATURE:
                case HeaderNames.V3.DECREASE_COLORTEMPERATURE:
                    return new Payload();
                case HeaderNames.V3.ADJUST_VOLUME:
                    if (namespaceType == Namespaces.ALEXA_STEPSPEAKER)
                        return new StepSpeakerAdjustVolumeRequestPayload();
                    else if (namespaceType == Namespaces.ALEXA_SPEAKER)
                        return new SpeakerAdjustVolumeRequestPayload();
                    else
                        throw new JsonSerializationException("Namespace not valid for AdjustVolume Requestname.");
                default:
                    throw new ArgumentOutOfRangeException(nameof(Type), $"Unknown request type: {requestType}.");
            }
        }

        /// <summary>
        /// returns the payload for the specific requesttype
        /// </summary>
        /// <param name="requestType">Name of the Requests></param>
        /// <returns></returns>
        public Payload CreateV2Payload(string requestType)
        {
            switch (requestType)
            {
                case HeaderNames.V2.DISCOVERY_REQUEST:
                    return new DiscoveryRequestPayload();
                case HeaderNames.V2.TURN_OFF_REQUEST:
                case HeaderNames.V2.TURN_ON_REQUEST:
                    return new TurnOnOffRequestPayload();
                case HeaderNames.V2.HEALTH_CHECK_REQUEST:
                    return new HealthCheckRequestPayload();
                case HeaderNames.V2.DECREMENT_TARGET_TEMPERATURE_REQUEST:
                case HeaderNames.V2.INCREMENT_TARGET_TEMPERATURE_REQUEST:
                    return new In_DecrementTemperatureRequestPayload();
                case HeaderNames.V2.SET_TARGET_TEMPERATURE_REQUEST:
                    return new SetTemperatureRequestPayload();
                case HeaderNames.V2.DECREMENT_PERCENTAGE_REQUEST:
                case HeaderNames.V2.INCREMENT_PERCENTAGE_REQUEST:
                    return new In_DecrementPercentageRequestPayload();
                case HeaderNames.V2.SET_PERCENTAGE_REQUEST:
                    return new RequestPayloads.SetPercentageRequestPayload();
                case HeaderNames.V2.SET_COLOR_REQUEST:
                    return new RequestPayloads.SetColorRequestPayload();
                case HeaderNames.V2.SET_COLOR_TEMPERATURE_REQUEST:
                    return new ColorTemperatureRequestPayload();
                case HeaderNames.V2.INCREMENT_COLOR_TEMPERATURE_REQUEST:
                case HeaderNames.V2.DECREMENT_COLOR_TEMPERATURE_REQUEST:
                    return new In_DecrementColorTemperatureRequestPayload();
                case HeaderNames.V2.GET_TEMPERATURE_READING_REQUEST:
                case HeaderNames.V2.GET_TARGET_TEMPERATURE_REQUEST:
                    return new GetTemperatureRequestPayload();
                case HeaderNames.V2.GET_LOCK_STATE_REQUEST:
                    return new GetLockStateRequestPayload();
                case HeaderNames.V2.SET_LOCK_STATE_REQUEST:
                    return new SetLockStateRequestPayload();
                case HeaderNames.V2.RETRIEVE_CAMERA_STREAM_URI_REQUEST:
                    return new RetrieveCameraStreamUriRequestPayload();
                default:
                    throw new ArgumentOutOfRangeException(nameof(Type), $"Unknown request type: {requestType}.");
            }
        }
    }
}
