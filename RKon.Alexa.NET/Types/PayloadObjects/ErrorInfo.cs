using Newtonsoft.Json;

namespace RKon.Alexa.NET.Types
{
    /// <summary>
    /// Class for error informations
    /// </summary>
    public class ErrorInfo
    {
        /// <summary>
        /// Errorcode
        /// </summary>
        [JsonRequired]
        [JsonProperty("code")]
        public string Code { get; set; }
        /// <summary>
        /// Fehlerdescription
        /// </summary>
        [JsonRequired]
        [JsonProperty("description")]
        public string Description { get; set; }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="code">Errorcode</param>
        /// <param name="description">Error description</param>
        public ErrorInfo(string code, string description)
        {
            Code = code;
            Description = description;
        }

    
    }
}
