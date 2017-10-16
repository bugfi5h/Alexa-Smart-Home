using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RKon.Alexa.NET46.Types;

namespace RKon.Alexa.NET46.JsonObjects
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
    }
}
