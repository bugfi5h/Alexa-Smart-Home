using Newtonsoft.Json;


namespace RKon.Alexa.NET46.Response.ErrorResponses
{
    /// <summary>
    /// Payload for TargetFirmwareOutdated
    /// </summary>
    public class TargetFirmwareOutdatedPayload : ResponsePayload
    {
        /// <summary>
        /// Smallest allowed Firmwareversion
        /// </summary>
        [JsonRequired]
        [JsonProperty("minimumFirmwareVersion")]
        public string MinimumFirmwareVersion { get; set; }
        /// <summary>
        /// Actual Firmwareversion of the device
        /// </summary>
        [JsonRequired]
        [JsonProperty("currentFirmwareVersion")]
        public string CurrentFirmwareVersion { get; set; }
        /// <summary>
        /// Constructor. Sets min and current Firmware
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
