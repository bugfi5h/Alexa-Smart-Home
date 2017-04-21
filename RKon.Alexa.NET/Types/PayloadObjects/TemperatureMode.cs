using Newtonsoft.Json;


namespace RKon.Alexa.NET.Types
{
    /// <summary>
    ///Class for the Temperature Mode
    /// </summary>
    public class TemperatureMode
    {
        /// <summary>
        /// Value
        /// </summary>
        [JsonRequired]
        [JsonProperty("value")]
        public string Value { get; private set; }
        /// <summary>
        /// Constructor
        /// </summary>
        public TemperatureMode()
        {
            Value = DeviceModes.AUTO;
        }

        /// <summary>
        /// Sets the Value to mode if able. Valid modes can be found under Namespace RKon.Alexa.Net.Types.DeviceModes
        /// On error it will use AUTO
        /// </summary>
        /// <param name="mode">New Mode</param>
        /// <returns>True on success</returns>
        public bool TrySetTemperatureMode(string mode)
        {
            bool success = true;
            if (DeviceModes.TemperatureModes.Contains(mode.ToUpper()))
            {
                Value = mode;
            }
            else
            {
                Value = DeviceModes.AUTO;
                success = false;
            }
            return success;
        }
    }
}
