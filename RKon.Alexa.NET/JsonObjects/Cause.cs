using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RKon.Alexa.NET.Types;

namespace RKon.Alexa.NET.JsonObjects
{
    /// <summary>
    /// The Cause of a change
    /// </summary>
    public class Cause
    {
        /// <summary>
        /// Specifies the cause of the change
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CauseTypes Type { get; set; }

        /// <summary>
        /// Standartconstructor
        /// </summary>
        public Cause()
        {
        }

        /// <summary>
        /// Initializes Cause
        /// </summary>
        /// <param name="type"></param>
        public Cause(CauseTypes type)
        {
            Type = type;
        }
    }
}
