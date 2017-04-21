using System.Collections.Generic;

namespace RKon.Alexa.NET.Types
{
    /// <summary>
    /// Class of Device modes
    /// </summary>
    public class DeviceModes
    {
        /// <summary>
        /// String for the AUTO Mode
        /// </summary>
        public const string AUTO = "AUTO";
        /// <summary>
        /// String for the HEAT Mode
        /// </summary>
        public const string HEAT = "HEAT";
        /// <summary>
        /// String for the COOL Mode
        /// </summary>
        public const string COOL = "COOL";
        /// <summary>
        /// String for the AWAY Mode
        /// </summary>
        public const string AWAY = "AWAY";
        /// <summary>
        /// String for the OTHER Mode
        /// </summary>
        public const string OTHER = "OTHER";

        /// <summary>
        /// String for the CUSTOM Mode
        /// </summary>
        public const string CUSTOM = "CUSTOM";

        /// <summary>
        /// String for the ECO Mode
        /// </summary>
        public const string ECO = "ECO";

        /// <summary>
        /// String for the OFF Mode
        /// </summary>
        public const string OFF = "OFF";

        /// <summary>
        /// String for LOCKED
        /// </summary>
        public const string LOCKED = "LOCKED";

        /// <summary>
        /// String for UNLOCKED
        /// </summary>
        public const string UNLOCKED = "UNLOCKED";


        /// <summary>
        /// List of all device modes
        /// </summary>
        public static readonly List<string> Modes = new List<string>()
        {
            AUTO,HEAT,COOL,AWAY,OTHER
        };
        /// <summary>
        /// List of all Temperature modes
        /// </summary>
        public static readonly List<string> TemperatureModes = new List<string>()
        {
            AUTO,HEAT,COOL
        };
        /// <summary>
        /// List of all GetTemperature modes
        /// </summary>
        public static readonly List<string> GetTemperatureModes = new List<string>()
        {
            AUTO,HEAT,COOL,OFF,CUSTOM,ECO
        };
        /// <summary>
        ///List of all Lockstates
        /// </summary>
        public static readonly List<string> LockModes = new List<string>()
        {
            LOCKED, UNLOCKED
        };

    }
}
