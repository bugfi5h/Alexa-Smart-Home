using Newtonsoft.Json;

namespace RKon.Alexa.NET46.Response
{
    /// <summary>
    /// Payload for a HealthCheckResponse
    /// </summary>
    public class HealthCheckResponsePayload : ResponsePayload
    {
        /// <summary>
        /// Description of the Healthstatus
        /// </summary>
        [JsonRequired]
        [JsonProperty("description")]
        public string Description { get; private set; }
        /// <summary>
        /// Boolean if the appliance is online
        /// </summary>
        [JsonRequired]
        [JsonProperty("isHealthy")]
        public bool IsHealthy { get; private set; }
        /// <summary>
        /// Constructor
        /// </summary>
        public HealthCheckResponsePayload()
        {
            Description = "The system is currenty not healthy";
            IsHealthy = false;
        }
        /// <summary>
        /// Sets description and isHealthy
        /// </summary>
        /// <param name="isHealthy">state of the appliance</param>
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
