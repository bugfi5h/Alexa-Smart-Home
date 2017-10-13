using RKon.Alexa.NET.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using RKon.Alexa.NET.Payloads;
using RKon.Alexa.NET.Payloads.Request;

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
                if(payloadVersion == "3")
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
                    return new SetPercentageRequestPayload();
                case HeaderNames.V3.ADJUST_PERCENTAGE:
                    return new AdjustPercentageRequestPayload();
                case HeaderNames.V3.SET_BRIGHTNESS:
                    return new SetBrightnessRequestPayload();
                case HeaderNames.V3.ADJUST_BRIGHTNESS:
                    return new AdjustBrightnessRequestPayload();
                case HeaderNames.V3.SET_COLOR:
                    return new SetColorRequestPayload();
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
    }
}
