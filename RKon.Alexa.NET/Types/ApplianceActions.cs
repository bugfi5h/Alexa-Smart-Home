using System.Collections.Generic;


namespace RKon.Alexa.NET.Types
{
    /// <summary>
    /// Actions für Geräte
    /// </summary>
    public class ApplianceActions
    {
        /// <summary>
        /// String für die Decrement Percentage Gerätefunktion
        /// </summary>
        public const string DECREMENT_PERCENTAGE = "decrementPercentage";
        /// <summary>
        /// String für die Turn Off Gerätefunktion
        /// </summary>
        public const string TURN_OFF = "turnOff";
        /// <summary>
        /// String für die Turn On Gerätefunktion
        /// </summary>
        public const string TURN_ON = "turnOn";
        /// <summary>
        /// String für die Set Target Temperature Gerätefunktion
        /// </summary>
        public const string SET_TARGET_TEMPERATURE = "setTargetTemperature";
        /// <summary>
        /// String für die Set Percentage Gerätefunktion
        /// </summary>
        public const string SET_PERCENTAGE = "setPercentage";
        /// <summary>
        /// String für die Increment Target Temperature Gerätefunktion
        /// </summary>
        public const string INCREMENT_TARGET_TEMPERATURE = "incrementTargetTemperature";
        /// <summary>
        /// String für die Increment Percentage Gerätefunktion
        /// </summary>
        public const string INCREMENT_PERCENTAGE = "incrementPercentage";
        /// <summary>
        /// String für die Decrement Target Temperature Gerätefunktion
        /// </summary>
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
