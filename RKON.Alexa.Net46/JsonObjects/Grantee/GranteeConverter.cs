using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RKon.Alexa.NET46.Types;
using System;

namespace RKon.Alexa.NET46.JsonObjects.Grantee
{
    /// <summary>
    /// Grantee Converter
    /// </summary>
    public class GranteeConverter : JsonConverter
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
                Grantee grantee = null;
                if (!String.IsNullOrEmpty(type))
                {
                    GranteeTypes granteeType = (GranteeTypes)Enum.Parse(typeof(GranteeTypes), type);
                    grantee = CreateGrantee(granteeType);
                    serializer.Populate(jObject.CreateReader(), grantee);
                }
                else
                {
                    throw new InvalidOperationException("Empty grantee type.");
                }


                return grantee;
            }

            private Grantee CreateGrantee(GranteeTypes granteeType)
            {
                Grantee s = null;
                switch (granteeType)
                {
                    case GranteeTypes.BearerToken:
                        s = new BearerToken();
                        break;
                    default:
                        throw new IndexOutOfRangeException("Unknown granteeType");
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
