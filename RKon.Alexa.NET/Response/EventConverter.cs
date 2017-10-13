using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RKon.Alexa.NET.Types;
using RKon.Alexa.NET.Payloads;
using RKon.Alexa.NET.Payloads.Response;

namespace RKon.Alexa.NET.Response
{
    /// <summary>
    /// Converts a Event 
    /// </summary>
    public class EventConverter : JsonConverter
    {
        /// <summary>
        /// 
        /// </summary>
        public override bool CanWrite => false;
        /// <summary>
        /// If it can be Converted into this type
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Event);
        }

        /// <summary>
        /// Reads Json in a Objekt und creates a Event
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            string _namespace = jObject["header"]?["namespace"]?.Value<string>();
            string name = jObject["header"]?["name"]?.Value<string>();
            Event e = new Event();
            if (!String.IsNullOrEmpty(_namespace) && !String.IsNullOrEmpty(name))
            {
                if(name == HeaderNames.V3.CHANGE_REPORT)
                {
                    if(jObject["payload"] != null && jObject["payload"].HasValues)
                    {
                        e.Payload = new ChangeReportPayload();
                    }
                    else
                    {
                        e.Payload = new Payload();
                    }
                }
                if (name == HeaderNames.V3.DEFFERED_RESPONSE)
                {
                    e.Payload = new DefferedResponsePayload();
                }
                else
                {
                    e.Payload = e._GetPayloadForEvent(_namespace);
                }
            }
            else
            {
                throw new InvalidOperationException("Empty request type.");
            }
            serializer.Populate(jObject.CreateReader(), e);

            return e;
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
    }
}
