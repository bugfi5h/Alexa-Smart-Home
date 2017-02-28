using RKon.Alexa.NET.Request;
using RKon.Alexa.NET.Types;
using Newtonsoft.Json;
using System.Linq;

namespace RKon.Alexa.NET.Response
{
    /// <summary>
    /// Klasse für den Header einer SmartHomeResponse
    /// </summary>
    public class ResponseHeader
    {
        /// <summary>
        /// MessageId
        /// </summary>
        [JsonProperty("messageId")]
        [JsonRequired()]
        public string MessageId { get; set; }
        /// <summary>
        /// Version des Payloads
        /// </summary>
        [JsonProperty("payloadVersion")]
        [JsonRequired()]
        public string PayloadVersion { get; set; }
        /// <summary>
        /// Namespace
        /// </summary>
        [JsonProperty("namespace")]
        [JsonRequired()]
        public string Namespace { get; set; }
        /// <summary>
        /// Aktionsname
        /// </summary>
        [JsonProperty("name")]
        [JsonRequired()]
        public string Name { get; set; }
        /// <summary>
        /// Erstellt an Hand eines Requestheaders den ResponseHeader
        /// </summary>
        /// <param name="reqHeader">Requestheaders</param>
        public ResponseHeader(RequestHeader reqHeader)
        {
            MessageId = System.Guid.NewGuid().ToString();
            PayloadVersion = reqHeader.PayloadVersion;
            Namespace = reqHeader.Namespace;
            if (HeaderNames.ResponseHeaderNames.Keys.Contains(reqHeader.Name))
            {
                Name = HeaderNames.ResponseHeaderNames[reqHeader.Name];
            }else
            {
                throw new UnknownRequestHeaderException(reqHeader.Name);
            }
        }

    }
}
