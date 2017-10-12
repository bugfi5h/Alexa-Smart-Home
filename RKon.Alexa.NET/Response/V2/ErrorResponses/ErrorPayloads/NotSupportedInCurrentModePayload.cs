using RKon.Alexa.NET.Types;
using Newtonsoft.Json;

namespace RKon.Alexa.NET.Response.ErrorResponses
{
    /// <summary>
    /// Payload for NotSupportedInCurrentMode
    /// </summary>
    public class NotSupportedInCurrentModePayload : ResponsePayload
    {
        /// <summary>
        /// Active DeviceMode
        /// </summary>
        [JsonProperty("currentDeviceMode")]
        [JsonRequired]
        public string CurrentDeviceMode { get; private set; }

        /// <summary>
        /// Constructor. Sets CurrentDeviceMode if possible to currenMode. Otherwise to OTHER
        /// </summary>
        /// <param name="currentMode"></param>
        public NotSupportedInCurrentModePayload(string currentMode){
            TrySetDeviceMode(currentMode);
        }
        /// <summary>
        /// Sets CurrentDeviceMode if possible to currenMode. Otherwise to OTHER
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
