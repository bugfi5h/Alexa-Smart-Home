using Newtonsoft.Json;

namespace RKon.Alexa.NET.Request.V3
{
    public class SmartHomeV3Request
    {
        [JsonProperty("directive")]
        public Directive Directive { get; set; }
    }
}
