using RKon.Alexa.NET46.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using RKon.Alexa.NET46.Payloads;

namespace RKon.Alexa.NET46.Request
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
                throw new InvalidOperationException("(SmartHomeRequestConverter)Empty Headername. Object: " + jObject.ToString());
            }
            serializer.Populate(jObject.CreateReader(), req);

            return req;
        }

        private Payload CreateV3Payload(string requestType, string namespaceType)
        {
            switch (requestType)
            {
                case HeaderNames.ACCEPT_GRANT:
                    return new AcceptGrantRequestPayload();
                case HeaderNames.DISCOVERY_REQUEST:
                    return new RequestPayloadWithScope();
                case HeaderNames.SET_POWER_LEVEL:
                    return new PowerLevelRequestPayload();
                case HeaderNames.ADJUST_POWER_LEVEL:
                    return new AdjustPowerLevelRequestPayload();
                case HeaderNames.SETTARGETTEMPERATURE:
                    return new SetTargetTemperatureRequestPayload();
                case HeaderNames.ADJUSTTARGETTEMPERATURE:
                    return new AdjustTargetTemperatureRequestPayload();
                case HeaderNames.SET_PERCENTAGE:
                    return new SetPercentageRequestPayload();
                case HeaderNames.ADJUST_PERCENTAGE:
                    return new AdjustPercentageRequestPayload();
                case HeaderNames.SET_BRIGHTNESS:
                    return new SetBrightnessRequestPayload();
                case HeaderNames.ADJUST_BRIGHTNESS:
                    return new AdjustBrightnessRequestPayload();
                case HeaderNames.SET_COLOR:
                    return new SetColorRequestPayload();
                case HeaderNames.SET_COLORTEMPERATURE:
                    return new SetColorTemperatureRequestPayload();
                case HeaderNames.INIT_CAMERA_STREAMS:
                    return new InitializeCameraRequestPayload();
                case HeaderNames.CHANGE_CHANNEL:
                    return new ChangeChannelRequestPayload();
                case HeaderNames.SKIP_CHANNELS:
                    return new SkipChannelRequestPayload();
                case HeaderNames.SELECT_INPUT:
                    return new SelectInputRequestPayload();
                case HeaderNames.SET_MUTE:
                    return new SetMuteRequestPayload();
                case HeaderNames.SET_VOLUME:
                    return new SetVolumeRequestPayload();
                case HeaderNames.SET_THERMOSTATMODE:
                    return new SetThermostadModeRequestPayload();
                case HeaderNames.FAST_FORWARD:
                case HeaderNames.NEXT:
                case HeaderNames.PAUSE:
                case HeaderNames.PLAY:
                case HeaderNames.PREVIOUS:
                case HeaderNames.REWIND:
                case HeaderNames.START_OVER:
                case HeaderNames.STOP:
                case HeaderNames.TURN_ON_REQUEST:
                case HeaderNames.TURN_OFF_REQUEST:
                case HeaderNames.REPORT_STATE:
                case HeaderNames.LOCK:
                case HeaderNames.UNLOCK:
                case HeaderNames.INCREASE_COLORTEMPERATURE:
                case HeaderNames.DECREASE_COLORTEMPERATURE:
                case HeaderNames.ACTIVATE:
                case HeaderNames.DEACTIVATE:
                    return new Payload();
                case HeaderNames.ADJUST_VOLUME:
                    if (namespaceType == Namespaces.ALEXA_STEPSPEAKER)
                        return new StepSpeakerAdjustVolumeRequestPayload();
                    else if (namespaceType == Namespaces.ALEXA_SPEAKER)
                        return new SpeakerAdjustVolumeRequestPayload();
                    else
                        throw new JsonSerializationException("Namespace not valid for AdjustVolume Requestname.");
                default:
                    throw new ArgumentOutOfRangeException(nameof(Type), $"Unknown Header name: {requestType}.");
            }
        }
    }
}
