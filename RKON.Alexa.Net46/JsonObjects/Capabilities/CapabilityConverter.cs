using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RKon.Alexa.NET46.Types;
using System;

namespace RKon.Alexa.NET46.JsonObjects.Capabilities
{
    /// <summary>
    /// Capability Converter
    /// </summary>
    public class CapabilityConverter : JsonConverter
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
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Property);
        }
        /// <summary>
        /// Reads Json in a Objekt und creates a Property
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            string type = jObject["type"]?.Value<string>();
            Capability cab = null;
            if (!String.IsNullOrEmpty(type))
            {
                CapabilitiyTypes cabType = (CapabilitiyTypes)Enum.Parse(typeof(CapabilitiyTypes), type);
                cab = CreateCapability(cabType);
                serializer.Populate(jObject.CreateReader(), cab);
            }
            else
            {
                throw new InvalidOperationException("Empty grantee type.");
            }


            return cab;
        }

        private Capability CreateCapability(CapabilitiyTypes cabType)
        {
            Capability s = null;
            switch (cabType)
            {
                case CapabilitiyTypes.AlexaInterface:
                    s = new AlexaInterface();
                    break;
                default:
                    throw new IndexOutOfRangeException("Unknown CapabilitiyTypes");
            }
            return s;
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
