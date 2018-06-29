using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RKon.Alexa.NET46.Types
{
    /// <summary>
    /// Represents the a cooking mode for a cooking appliance like a microwave oven. 
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CookingModes
    {
        /// <summary>
        /// Indicates a cooking appliance’s automated defrost mode.
        /// </summary>
        DEFROST,
        /// <summary>
        ///  	Indicates a cooking appliance is off.
        /// </summary>
        OFF,
        /// <summary>
        /// Indicates a cooking appliance’s preset mode or other automated cooking.
        /// </summary>
        PRESET,
        /// <summary>
        /// Indicates a cooking appliance’s automated reheating mode.
        /// </summary>
        REHEAT,
        /// <summary>
        /// Indicates a time and power level cooking setting.
        /// </summary>
        TIMECOOK
    }
}
