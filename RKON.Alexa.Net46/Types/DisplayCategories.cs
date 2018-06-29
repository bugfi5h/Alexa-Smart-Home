using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RKon.Alexa.NET46.Types
{
    /// <summary>
    /// Available DisplayCategories
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DisplayCategory
    {
        /// <summary>
        ///  	Describes a combination of devices set to a specific state, when the state change must occur in a specific order. 
        ///  	For example, a “watch Neflix” scene might require the: 1. TV to be powered on and 2. Input set to HDMI1.
        /// </summary>
        ACTIVITY_TRIGGER,
        /// <summary>
        ///  	Indicates media devices with video or photo capabilities.
        /// </summary>
        CAMERA,
        /// <summary>
        ///  	Indicates a door.
        /// </summary>
        DOOR,
        /// <summary>
        /// Indicates light sources or fixtures
        /// </summary>
        LIGHT,
        /// <summary>
        /// An endpoint that cannot be described in on of the other categories.
        /// </summary>
        OTHER,
        /// <summary>
        /// Describes a combination of devices set to a specific state, when the order of the state change is not important.
        /// For example a bedtime scene might include turning off lights and lowering the thermostat, but the order is unimportant.
        /// </summary>
        SCENE_TRIGGER,
        /// <summary>
        /// Indicates an endpoint that locks.
        /// </summary>
        SMARTLOCK,
        /// <summary>
        /// Indicates modules that are plugged into an existing electrical outlet. 	
        /// </summary>
        SMARTPLUG,
        /// <summary>
        /// Indicates the endpoint is a speaker or speaker system.
        /// </summary>
        SPEAKERS,
        /// <summary>
        ///  	Indicates in-wall switches wired to the electrical system.
        /// </summary>
        SWITCH,
        /// <summary>
        ///  	Indicates endpoints that report the temperature only.
        /// </summary>
        TEMPERATURE_SENSOR,
        /// <summary>
        ///  	Indicates endpoints that control temperature, stand-alone air conditioners, or heaters with direct temperature control.
        /// </summary>
        THERMOSTAT,
        /// <summary>
        /// Indicates the endpoint is a television.
        /// </summary>
        TV
    }
}
