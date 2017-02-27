using System.Collections.Generic;

namespace RKon.Alexa.NET.Types
{
    /// <summary>
    /// Klasse für Gerätemodi
    /// </summary>
    public class DeviceModes
    {
        public const string AUTO = "AUTO";
        public const string HEAT = "HEAT";
        public const string COOL = "COOL";
        public const string AWAY = "AWAY";
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
