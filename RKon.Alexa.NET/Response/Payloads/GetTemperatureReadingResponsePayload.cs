using Newtonsoft.Json;
using RKon.Alexa.NET.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RKon.Alexa.NET.Response
{
    /// <summary>
    /// Response Payload für GetTemperatureReading
    /// </summary>
    public class GetTemperatureReadingResponsePayload : ResponsePayload
    {
        /// <summary>
        /// Temperatur in Celsius
        /// </summary>
        [JsonProperty("temperatureReading")]
        [JsonRequired]
        public TargetTemperature TemperatureReading { get; set; }

        /// <summary>
        /// Gibt das Datum an wann die letzte Temperatur vom Gerät gelesen wurde. Nicht notwendig. 
        /// Aus der API Doku: "Valid values are a standard ISO 8601 format, in UTC with 1 second precision"
        /// </summary>
        [JsonProperty("applianceResponseTimestamp",NullValueHandling =NullValueHandling.Ignore)]
        public DateTime ApplianceResponseTimestamp { get; set; }

        /// <summary>
        /// Konstruktor
        /// </summary>
        public GetTemperatureReadingResponsePayload()
        {
            TemperatureReading = new TargetTemperature();
        }
    }
}
