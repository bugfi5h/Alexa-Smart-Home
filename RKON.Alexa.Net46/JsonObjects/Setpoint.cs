using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RKon.Alexa.NET46.Types;

namespace RKon.Alexa.NET46.JsonObjects
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
        [JsonConverter(typeof(StringEnumConverter))]
        public Scale Scale { get; set; }

        /// <summary>
        /// Standard constructor
        /// </summary>
        public Setpoint()
        {

        }

        /// <summary>
        /// Initializes Setpoint
        /// </summary>
        /// <param name="value"></param>
        /// <param name="scale"></param>
        public Setpoint(double value, Scale scale)
        {
            Value = value;
            Scale = scale;
        }
    }
}
