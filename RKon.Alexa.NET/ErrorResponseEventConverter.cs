using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RKon.Alexa.NET.Types;

namespace RKon.Alexa.NET.Response
{
    /// <summary>
    /// Converter for ErrorEvents
    /// </summary>
    public class ErrorResponseEventConverter : JsonConverter
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
            return objectType == typeof(ErrorResponseEvent);
        }

        /// <summary>
        /// Creates a ErrorResponseEvent
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            string type = jObject["payload"]?["type"]?.Value<string>();
            ErrorResponseEvent e = new ErrorResponseEvent();
            if (!String.IsNullOrEmpty(type))
            {
                ErrorTypes enumType;
                if(Enum.TryParse(type, out enumType))
                {
                    e.Payload = e._GetPayloadForErrorType(enumType);
                }else
                {
                    throw new InvalidOperationException("Can not parse ErrorType");
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