﻿using Newtonsoft.Json;


namespace RKon.Alexa.NET46.Types.PayloadObjects
{
    /// <summary>
    /// State of the appliance after the color change
    /// </summary>
    public class AchievedColorTemperatureState
    {
        /// <summary>
        /// Color value after commiting the request
        /// </summary>
        [JsonRequired]
        [JsonProperty("colorTemperature")]
        public ColorTemperature ColorTemperature { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public AchievedColorTemperatureState()
        {
            ColorTemperature = new ColorTemperature();
        }
    }
}