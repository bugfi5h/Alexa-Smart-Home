using Newtonsoft.Json;

namespace RKon.Alexa.NET.JsonObjects
{
    /// <summary>
    /// An Element for setpoint directives
    /// </summary>
    public class Setpoint
    {
        /// <summary>
        /// Value of the setpoint
        /// </summary>
        [JsonProperty("value")]
        public double Value { get; set; }

        /// <summary>
        /// Can be CLESIUS, FAHRENHEIT or KELVIN
        /// </summary>
        [JsonProperty("scale")]
        public double Scale { get; set; }
    }
}
