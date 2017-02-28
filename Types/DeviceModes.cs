using System.Collections.Generic;

namespace RKon.Alexa.NET.Types
{
    /// <summary>
    /// Klasse für Gerätemodi
    /// </summary>
    public class DeviceModes
    {
        /// <summary>
        /// String für AUTO Mode
        /// </summary>
        public const string AUTO = "AUTO";
        /// <summary>
        /// String für HEAT Mode
        /// </summary>
        public const string HEAT = "HEAT";
        /// <summary>
        /// String für COOL Mode
        /// </summary>
        public const string COOL = "COOL";
        /// <summary>
        /// String für AWAY Mode
        /// </summary>
        public const string AWAY = "AWAY";
        /// <summary>
        /// String für OTHER Mode
        /// </summary>
        public const string OTHER = "OTHER";

        /// <summary>
        /// Liste aller Gerätemodi
        /// </summary>
        public static readonly List<string> Modes = new List<string>()
        {
            AUTO,HEAT,COOL,AWAY,OTHER
        };
        /// <summary>
        /// Liste aller Temperaturmodi
        /// </summary>
        public static readonly List<string> TemperatureModes = new List<string>()
        {
            AUTO,HEAT,COOL
        };

    }
}
