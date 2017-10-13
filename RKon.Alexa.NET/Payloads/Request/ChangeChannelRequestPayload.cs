using Newtonsoft.Json;
using RKon.Alexa.NET.JsonObjects;
using RKon.Alexa.NET.Types;

namespace RKon.Alexa.NET.Payloads.Request
{
    /// <summary>
    /// Requestpayload for a channel change by specifying a channel number or call sign.
    /// </summary>
    public class ChangeChannelRequestPayload : Payload
    {
        /// <summary>
        /// Describes a channel.
        /// </summary>
        [JsonProperty(PropertyNames.CHANNEL)]
        public Channel Channel { get; set; }
        /// <summary>
        /// Provides additional information about the specified channel. Can be null
        /// </summary>
        [JsonProperty("channelMetaData")]
        public ChannelMetaData ChannelMetaData { get; set; }
    }
}
