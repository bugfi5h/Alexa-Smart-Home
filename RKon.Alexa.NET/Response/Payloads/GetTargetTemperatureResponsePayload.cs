using Newtonsoft.Json;
using RKon.Alexa.NET.Types;
using System;


namespace RKon.Alexa.NET.Response
{
    /// <summary>
    /// Payload for a GetTargetTemperatureResponse
    /// </summary>
    public class GetTargetTemperatureResponsePayload : ResponsePayload
    {
        /// <summary>
        /// Temperature for a device in "Single-Setpoint" mode in celsius. Can be null
        /// </summary>
        [JsonProperty("targetTemperature",NullValueHandling =NullValueHandling.Ignore)]
        public TargetTemperature TargetTemperature { get; set; }
        /// <summary>
        ///  Cooling Temperature for a device in "Dual-Setpoint" mode in celsius. Can be null
        /// </summary>
        [JsonProperty("coolingTargetTemperature", NullValueHandling = NullValueHandling.Ignore)]
        public TargetTemperature CoolingTargetTemperature { get; set; }
        /// <summary>
        /// Heating temperature for a device in "Dual-Setpoint" mode in celsius. Can be null
        /// </summary>
        [JsonProperty("heatingTargetTemperature", NullValueHandling = NullValueHandling.Ignore)]
        public TargetTemperature HeatingTargetTemperature { get; set; }

        /// <summary>
        /// Temperaturemode. Allowed values: AUTO, COOL, HEAT, ECO, OFF, CUSTOM
        /// From the smart home API: "CUSTOM: Indicates a custom mode that is specified by friendlyName"
        /// </summary>
        [JsonProperty("temperatureMode")]
        [JsonRequired]
        public GetTemperatureMode TemperatureMode { get; private set; }

        /// <summary>
        /// the last time the temperatur was requestet. Can be null
        /// </summary>
        [JsonProperty("applianceResponseTimestamp", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime ApplianceResponseTimestamp { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public GetTargetTemperatureResponsePayload()
        {
            TemperatureMode = new GetTemperatureMode();
        }
    }
}
