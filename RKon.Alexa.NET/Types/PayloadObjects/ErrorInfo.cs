using Newtonsoft.Json;

namespace RKon.Alexa.NET.Types
{
    /// <summary>
    /// Klasse für Fehlerinformationen
    /// </summary>
    public class ErrorInfo
    {
        /// <summary>
        /// Fehlercode
        /// </summary>
        [JsonRequired]
        [JsonProperty("code")]
        public string Code { get; set; }
        /// <summary>
        /// Fehlerbeschreibung
        /// </summary>
        [JsonRequired]
        [JsonProperty("description")]
        public string Description { get; set; }
        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="code">Fehlercode</param>
        /// <param name="description">Fehlerbeschreibung</param>
        public ErrorInfo(string code, string description)
        {
            Code = code;
            Description = description;
        }

    
    }
}
