using Newtonsoft.Json;


namespace RKon.Alexa.NET.Response.ErrorResponses
{
    /// <summary>
    /// Payload für RateLimitExceeded
    /// </summary>
    public class RateLimitExceededPayload : ResponsePayload
    {
        /// <summary>
        /// Maximale Anzahl von Requests, die ein Gerät akzeptiert
        /// </summary>
        [JsonRequired]
        [JsonProperty("rateLimit")]
        public string RateLimit { get; set; }

        /// <summary>
        /// Zeiteinheit für das RateLimit in Großbuchstaben. Z.B MINUTE, HOUR oder DAY 
        /// </summary>
        [JsonRequired]
        [JsonProperty("timeUnit")]
        public string TimeUnit { get; set; }
        /// <summary>
        /// Konstruktor. Setzt RateLimit und TimeUnit
        /// </summary>
        /// <param name="rateLimit"></param>
        /// <param name="timeUnit"></param>
        public RateLimitExceededPayload(string rateLimit, string timeUnit)
        {
            RateLimit = rateLimit;
            TimeUnit = timeUnit;
        }
    }
}
