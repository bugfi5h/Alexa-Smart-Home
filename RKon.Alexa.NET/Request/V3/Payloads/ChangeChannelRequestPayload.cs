using Newtonsoft.Json;
using RKon.Alexa.NET.JsonObjects;

namespace RKon.Alexa.NET.Request.V3.Payloads
{
    /// <summary>
    /// Requestpayload for a channel change by specifying a channel number or call sign.
    /// </summary>
    public class ChangeChannelRequestPayload : RequestPayload
    {
        /// <summary>
        /// Describes a channel.
        /// </summary>
        [JsonProperty("channel")]
        public Channel Channel { get; set; }
        /// <summary>
        /// Provides additional information about the specified channel. Can be null
        /// </summary>
        [JsonProperty("channelMetaData")]
        public ChannelMetaData ChannelMetaData { get; set; }
    }
}
