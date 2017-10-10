using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RKon.Alexa.NET.JsonObjects
{
    /// <summary>
    /// Appliances
    /// </summary>
    public class ApplianceTypes
    {
        /// <summary>
        /// Indicates media devices with video or photo capabilities.
        /// </summary>
        public const string CAMERA = "CAMERA";
        /// <summary>
        /// Indicates light sources or fixtures.
        /// </summary>
        public const string LIGHT = "LIGHT";
        /// <summary>
        /// Indicates door locks.
        /// </summary>
        public const string SMARTLOCK = "SMARTLOCK";
        /// <summary>
        /// Indicates modules that are plugged into an existing electrical outlet.Can control a variety of devices.
        /// </summary>
        public const string SMARTPLUG = "SMARTPLUG";
        /// <summary>
        /// Indicates in-wall switches wired to the electrical system.Can control a variety of devices.
        /// </summary>
        public const string SWITCH = "SWITCH";
        /// <summary>
        /// Indicates thermostats that control temperature, stand-alone air conditioners, or heaters with direct temperature control.
        /// </summary>
        public const string THERMOSTAT = "THERMOSTAT"; 
        /// <summary>
        /// Describes a combination of devices set to a specific state, when the state change must occur in a specific order.For example, a "watch Neflix" scene might require the
        /// 1) TV to be powered on.
        /// 2) Input set to HDMI1.Applies to Scenes
        /// </summary>
        public const string ACTIVITY_TRIGGER = "ACTIVITY_TRIGGER";
        /// <summary>
        /// Describes a combination of devices set to a specific state, when the order of the state change is not important. For example a bedtime scene might include turning off lights and lowering the thermostat, but the order is unimportant.App
        /// </summary>
        public const string SCENE_TRIGGER = "SCENE_TRIGGER";

    }
}
