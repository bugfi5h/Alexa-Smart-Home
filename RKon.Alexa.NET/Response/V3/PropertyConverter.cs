using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RKon.Alexa.NET.Types;
using RKon.Alexa.NET.JsonObjects;

namespace RKon.Alexa.NET.Response.V3
{
    /// <summary>
    /// Readconverter for Cotextproperties
    /// </summary>
    public class PropertyConverter : JsonConverter
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
        /// Reads Json in a Objekt und creates a SmartHomeRequest
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            string name = jObject["name"]?.Value<string>();
            Property prop = null;
            if (!String.IsNullOrEmpty(name))
            {
                prop.Value = CreateValue(name);
            }
            else
            {
                throw new InvalidOperationException("Empty request type.");
            }
            serializer.Populate(jObject.CreateReader(), prop);

            return prop;
        }
        /// <summary>
        /// Creates the needed PropertyValue for a Property.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private object CreateValue(string name)
        {
            switch (name)
            {
                case PropertyNames.TARGET_SETPOINT:
                case PropertyNames.LOWER_SETPOINT:
                case PropertyNames.UPPER_SETPOINT:
                case PropertyNames.TEMPERATURE:
                    return new Setpoint();
                case PropertyNames.MUTED:
                    return new Boolean();
                case PropertyNames.CHANNEL:
                    return new Channel();
                case PropertyNames.COLOR:
                    return new Color();
                case PropertyNames.LOCK_STATE:
                case PropertyNames.INPUT:
                case PropertyNames.POWER_STATE:
                case PropertyNames.THERMOSTATMODE:
                case PropertyNames.CONNECTIVITY:
                    return String.Empty;
                case PropertyNames.VOLUME:
                case PropertyNames.BRIGHTNESS:
                case PropertyNames.POWER_LEVEL:
                case PropertyNames.COLOR_TEMPERATURE_IN_KELVIN:
                case PropertyNames.PERCENTAGE:
                     return new Int32();
                default:
                    throw new ArgumentOutOfRangeException(nameof(Type), $"Unknown property name: {name}.");
            }
           
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
