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
        private string Description { get; set; }
        [JsonRequired]
        [JsonProperty("isHealthy")]
        private bool IsHealthy { get; set; }
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
