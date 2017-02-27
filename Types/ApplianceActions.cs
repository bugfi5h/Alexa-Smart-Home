using System.Collections.Generic;


namespace RKon.Alexa.NET.Types
{
    /// <summary>
    /// Actions für Geräte
    /// </summary>
    public class ApplianceActions
    {
        public const string DECREMENT_PERCENTAGE = "decrementPercentage";
        public const string TURN_OFF = "turnOff";
        public const string TURN_ON = "turnOn";
        public const string SET_TARGET_TEMPERATURE = "setTargetTemperature";
        public const string SET_PERCENTAGE = "setPercentage";
        public const string INCREMENT_TARGET_TEMPERATURE = "incrementTargetTemperature";
        public const string INCREMENT_PERCENTAGE = "incrementPercentage";
        public const string DECREMENT_TARGET_TEMPERATURE = "decrementTargetTemperature";

        /// <summary>
        /// Liste aller verfügbaren Aktionen
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
