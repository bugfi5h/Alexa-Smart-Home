using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RKon.Alexa.NET46.Types;

namespace RKon.Alexa.NET46.JsonObjects
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
            string name = jObject["name"]?.Value<string>();
            Property prop = new Property();
            if (!String.IsNullOrEmpty(name))
            {
                prop.Value = CreateValue(name);
            }
            else
            {
                throw new InvalidOperationException("Empty request type.");
            }
            serializer.Populate(jObject.CreateReader(), prop);

            System.Type type = null;
            if (prop.Name == PropertyNames.THERMOSTATMODE)
            {
                type = typeof(ThermostatModes);
            } else if (prop.Name == PropertyNames.POWER_STATE)
            {
                type = typeof(PowerStates);
            } else if (prop.Name == PropertyNames.LOCK_STATE)
            {
                type = typeof(LockModes);
            }

            if (type != null)
            {
                if (prop.Value is string)
                {
                    prop.Value = Enum.Parse(type, (string)prop.Value);
                }
            }

            if(prop.Value is long)
            {
                if((long)prop.Value  >= Int32.MinValue && (long)prop.Value <= Int32.MaxValue)
                {
                    int value = (int)(long)prop.Value;
                    prop.Value = new Int32();
                    prop.Value = value;
                }
            }

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
                case PropertyNames.CHANNEL:
                    return new Channel();
                case PropertyNames.COLOR:
                    return new Color();
                case PropertyNames.CONNECTIVITY:
                    return new ConnectivityPropertyValue();
                default:
                    return new object();
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
