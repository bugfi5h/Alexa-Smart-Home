using Newtonsoft.Json;
using RKon.Alexa.NET.Types;
using System;


namespace RKon.Alexa.NET.Response
{
    /// <summary>
    /// Response Payload for GetTemperatureReading
    /// </summary>
    public class GetTemperatureReadingResponsePayload : ResponsePayload
    {
        /// <summary>
        /// Temperature in Celsius
        /// </summary>
        [JsonProperty("temperatureReading")]
        [JsonRequired]
        public TargetTemperature TemperatureReading { get; set; }

        /// <summary>
        /// The date when the last temperature has been requested. Can be null. 
        /// From the smart home API Doku: "Valid values are a standard ISO 8601 format, in UTC with 1 second precision"
        /// </summary>
        [JsonProperty("applianceResponseTimestamp",NullValueHandling =NullValueHandling.Ignore)]
        public DateTime ApplianceResponseTimestamp { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public GetTemperatureReadingResponsePayload()
        {
            TemperatureReading = new TargetTemperature();
        }
    }
}
