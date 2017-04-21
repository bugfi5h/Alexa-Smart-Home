using Newtonsoft.Json;



namespace RKon.Alexa.NET.Types
{
    /// <summary>
    /// Class for GetTemperature Modes
    /// </summary>
    public class GetTemperatureMode
    {
        /// <summary>
        /// Value
        /// </summary>
        [JsonRequired]
        [JsonProperty("value")]
        public string Value { get; private set; }

        /// <summary>
        /// Can not be null if the temperature mode is set to CUSTOM
        /// </summary>
        [JsonProperty("friendlyName", NullValueHandling = NullValueHandling.Ignore)]
        public string FriendlyName { get; private set; }

        /// <summary>
        /// Konsturktor setzt Wert auf AUTO
        /// </summary>
        public GetTemperatureMode()
        {
            Value = DeviceModes.AUTO;
        }

        /// <summary>
        /// Sets mode if able. Valid values can be found in the Namespace RKon.Alexa.Net.Types.DeviceModes
        /// If its not successfull it will be set to AUTO. friendlyName can be Null if the mode is not Custom
        /// /// </summary>
        /// <param name="mode">Mode to use</param>
        /// <param name="friendlyName">Description of the Mode</param>
        /// <returns>True if value changes</returns>
        public bool TrySetTemperatureMode(string mode, string friendlyName)
        {
            bool success = true;
            if (DeviceModes.GetTemperatureModes.Contains(mode.ToUpper()))
            {
                Value = mode;
                FriendlyName = friendlyName;
            }
            else
            {
                success = false;
            }
            if(!success || (Value == DeviceModes.CUSTOM && FriendlyName == null))
            {
                Value = DeviceModes.AUTO;
            }
            return success;
        }
    }
}
