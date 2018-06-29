using Newtonsoft.Json;
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
