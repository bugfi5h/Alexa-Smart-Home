using Newtonsoft.Json;
using RKon.Alexa.NET.Types;

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
        public string Scale { get;private set; }

        /// <summary>
        /// Sets valid Scale
        /// </summary>
        /// <param name="scale"></param>
        public void SetScale(Scale scale)
        {
            Scale = scale.ToString();
        }
    }
}
