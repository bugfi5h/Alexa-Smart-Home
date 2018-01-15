
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RKon.Alexa.NET46.Types;
using System;

namespace RKon.Alexa.NET46.JsonObjects.Scopes
{
    /// <summary>
    /// Converts a Scope
    /// </summary>
    public class ScopeConverter : JsonConverter
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
            Scope scope = null;
            if (!String.IsNullOrEmpty(type))
            {
                ScopeTypes scopeType = (ScopeTypes)Enum.Parse(typeof(ScopeTypes), type);
                scope = CreateScope(scopeType);
                serializer.Populate(jObject.CreateReader(), scope);
            }
            else
            {
                throw new InvalidOperationException("Empty scope type.");
            }


            return scope;
        }

        private Scope CreateScope(ScopeTypes scopeType)
        {
            Scope s = null;
            switch (scopeType)
            {
                case ScopeTypes.BearerToken:
                    s = new Scopes.BearerToken();
                    break;
                case ScopeTypes.BearerTokenWithPartition:
                    s = new Scopes.BearerTokenWithPartition();
                    break;
                default:
                    throw new IndexOutOfRangeException("Unknown Scopetype");
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
