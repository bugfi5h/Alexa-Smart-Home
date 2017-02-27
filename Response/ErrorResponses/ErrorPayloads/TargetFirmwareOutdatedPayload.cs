using Newtonsoft.Json;


namespace RKon.Alexa.NET.Response.Payloads.ErrorPayloads
{
    /// <summary>
    /// Payload für TargetFirmwareOutdated
    /// </summary>
    public class TargetFirmwareOutdatedPayload : ResponsePayload
    {
        /// <summary>
        /// Kleinste erlaubte Firmwareversion
        /// </summary>
        [JsonRequired]
        [JsonProperty("minimumFirmwareVersion")]
        public string MinimumFirmwareVersion { get; set; }
        /// <summary>
        /// Aktuelle Firmwareversion des Geräts
        /// </summary>
        [JsonRequired]
        [JsonProperty("currentFirmwareVersion")]
        public string CurrentFirmwareVersion { get; set; }
        /// <summary>
        /// Konstruktor. Setzt minimum und current Firmware
        /// </summary>
        /// <param name="minimum"></param>
        /// <param name="current"></param>
        public TargetFirmwareOutdatedPayload(string minimum, string current)
        {
            MinimumFirmwareVersion = minimum;
            CurrentFirmwareVersion = current;
        }
    }
}
