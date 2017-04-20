using Newtonsoft.Json;

namespace RKon.Alexa.NET.Response
{
    /// <summary>
    /// Payload für eine HealthCheckResponse
    /// </summary>
    public class HealthCheckResponsePayload : ResponsePayload
    {
        [JsonRequired]
        [JsonProperty("description")]
        public string Description { get; private set; }
        [JsonRequired]
        [JsonProperty("isHealthy")]
        public bool IsHealthy { get; private set; }
        /// <summary>
        /// Konstruktor setzt IsHealthy auf false und Description auf The system is currenty not healthy
        /// </summary>
        public HealthCheckResponsePayload()
        {
            Description = "The system is currenty not healthy";
            IsHealthy = false;
        }
        /// <summary>
        /// Setzt die Beschreibung und IsHealthy an Hand des übergebenen Zustands
        /// </summary>
        /// <param name="isHealthy">Zustand des Geräts</param>
        public void SetHealthyStatus(bool isHealthy)
        {
            IsHealthy = isHealthy;
            if (!IsHealthy)
            {
                Description = "The system is currenty not healthy";
            }else
            {
                Description = "The system is currenty healthy";
            }
        }
    }
}
