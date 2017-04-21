using Newtonsoft.Json;
using RKon.Alexa.NET.Types;
using System;


namespace RKon.Alexa.NET.Response
{
    /// <summary>
    /// Payload für GetTargetTemperatureResponse
    /// </summary>
    public class GetTargetTemperatureResponsePayload : ResponsePayload
    {
        /// <summary>
        /// Temperatur für Geräte im "Single-Setpoint" Modus in Celsius. Kann null sein
        /// </summary>
        [JsonProperty("targetTemperature",NullValueHandling =NullValueHandling.Ignore)]
        public TargetTemperature TargetTemperature { get; set; }
        /// <summary>
        ///  Kühltemperatur für Geräte im "Dual-Setpoint" Modus in Celsius. Kann null sein
        /// </summary>
        [JsonProperty("coolingTargetTemperature", NullValueHandling = NullValueHandling.Ignore)]
        public TargetTemperature CoolingTargetTemperature { get; set; }
        /// <summary>
        /// Heiztemperatur für Geräte im "Dual-Setpoint" Modus in Celsius. Kann null sein
        /// </summary>
        [JsonProperty("heatingTargetTemperature", NullValueHandling = NullValueHandling.Ignore)]
        public TargetTemperature HeatingTargetTemperature { get; set; }

        /// <summary>
        /// Temperaturmodus. Folgende Werte sind erlaubt: AUTO, COOL, HEAT, ECO, OFF, CUSTOM
        /// Aus der API: "CUSTOM: Indicates a custom mode that is specified by friendlyName"
        /// </summary>
        [JsonProperty("temperatureMode")]
        [JsonRequired]
        public GetTemperatureMode TemperatureMode { get; private set; }

        /// <summary>
        /// Zeigt, wann die letzte Zieltemperatur vom Gerät abgefragt wurde. Nicht notwendig
        /// </summary>
        [JsonProperty("applianceResponseTimestamp", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime ApplianceResponseTimestamp { get; set; }

        /// <summary>
        /// Konstruktor
        /// </summary>
        public GetTargetTemperatureResponsePayload()
        {
            TemperatureMode = new GetTemperatureMode();
        }
    }
}
