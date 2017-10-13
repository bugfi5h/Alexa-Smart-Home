using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace RKon.Alexa.NET.Response
{
    /// <summary>
    /// Converts a SmartHomeResponse 
    /// </summary>
    public class SmartHomeResponseConverter : JsonConverter
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
            return objectType == typeof(SmartHomeResponse);
        }

        /// <summary>
        /// Reads Json in a Objekt und creates a SmartHomeResponse
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            string name = jObject["event"]?["header"]?["name"]?.Value<string>();
            SmartHomeResponse e = new SmartHomeResponse();
            if (!String.IsNullOrEmpty(name))
            {
                if (name == Types.HeaderNames.V3.ERROR_RESPONSE)
                {
                    e.Event = new ErrorResponseEvent();
                }
                else
                {
                    e.Event = new Event();
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
        /// Not Implemented
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
