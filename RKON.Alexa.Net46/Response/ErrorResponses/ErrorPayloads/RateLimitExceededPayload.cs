using Newtonsoft.Json;


namespace RKon.Alexa.NET46.Response.ErrorResponses
{
    /// <summary>
    /// Payload for RateLimitExceeded
    /// </summary>
    public class RateLimitExceededPayload : ResponsePayload
    {
        /// <summary>
        /// Max count of Requests, a device accepts
        /// </summary>
        [JsonRequired]
        [JsonProperty("rateLimit")]
        public string RateLimit { get; set; }

        /// <summary>
        /// An all-caps string that indicates the time unit for rateLimit such as MINUTE, HOUR or DAY. 
        /// </summary>
        [JsonRequired]
        [JsonProperty("timeUnit")]
        public string TimeUnit { get; set; }
        /// <summary>
        /// Constructor. Sets RateLimit and TimeUnit
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
