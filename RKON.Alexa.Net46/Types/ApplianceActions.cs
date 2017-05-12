using System.Collections.Generic;


namespace RKon.Alexa.NET46.Types
{
    /// <summary>
    /// Actions of a appliance
    /// </summary>
    public class ApplianceActions
    {
        /// <summary>
        /// String for the Decrement Percentage Action
        /// </summary>
        public const string DECREMENT_PERCENTAGE = "decrementPercentage";
        /// <summary>
        /// String for the Turn Off Action
        /// </summary>
        public const string TURN_OFF = "turnOff";
        /// <summary>
        /// String for the Turn On Action
        /// </summary>
        public const string TURN_ON = "turnOn";
        /// <summary>
        /// String for the Set Target Temperature Action
        /// </summary>
        public const string SET_TARGET_TEMPERATURE = "setTargetTemperature";
        /// <summary>
        /// String for the Set Percentage Action
        /// </summary>
        public const string SET_PERCENTAGE = "setPercentage";
        /// <summary>
        /// String for the Increment Target Temperature Action
        /// </summary>
        public const string INCREMENT_TARGET_TEMPERATURE = "incrementTargetTemperature";
        /// <summary>
        /// String for the Increment Percentage Action
        /// </summary>
        public const string INCREMENT_PERCENTAGE = "incrementPercentage";
        /// <summary>
        /// String for the Decrement Target Temperature Action
        /// </summary>
        public const string DECREMENT_TARGET_TEMPERATURE = "decrementTargetTemperature";

        /// <summary>
        /// List of all available actions
        /// </summary>
        public static readonly List<string> Actions = new List<string>()
        {
            DECREMENT_PERCENTAGE,
            TURN_OFF,
            TURN_ON,
            SET_TARGET_TEMPERATURE,
            SET_PERCENTAGE,
            INCREMENT_TARGET_TEMPERATURE,
            INCREMENT_PERCENTAGE,
            DECREMENT_TARGET_TEMPERATURE
        };
    }
}
