using RKon.Alexa.NET.Types;
using Newtonsoft.Json;

namespace RKon.Alexa.NET.Response.Payloads.ErrorPayloads
{
    /// <summary>
    /// Payload für NotSupportedInCurrentMode
    /// </summary>
    public class NotSupportedInCurrentModePayload : ResponsePayload
    {
        /// <summary>
        /// Aktiver Gerätemodus
        /// </summary>
        [JsonProperty("currentDeviceMode")]
        [JsonRequired]
        public string CurrentDeviceMode { get; private set; }

        /// <summary>
        /// Konstruktor. Setzt CurrentDeviceMode wenn möglich auf currenMode. Ansonsten auf OTHER
        /// </summary>
        /// <param name="currentMode"></param>
        public NotSupportedInCurrentModePayload(string currentMode){
            TrySetDeviceMode(currentMode);
        }
        /// <summary>
        /// Setzt CurrentDeviceMode wenn möglich auf mode. Ansonsten auf OTHER
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public bool TrySetDeviceMode(string mode)
        {
            bool success = true;
            if (DeviceModes.Modes.Contains(mode))
            {
                CurrentDeviceMode = mode;
            }else
            {
                CurrentDeviceMode = DeviceModes.OTHER;
                success = false;
            }
            return success;
        }
    }
}
