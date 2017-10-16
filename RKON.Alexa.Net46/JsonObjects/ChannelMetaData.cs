using Newtonsoft.Json;

namespace RKon.Alexa.NET46.JsonObjects
{
    /// <summary>
    /// Provides additional information about the specified channel. Can be null
    /// </summary>
    public class ChannelMetaData
    {
        /// <summary>
        /// Another value that identifies the channel such as “FOX”. Can be Null, but but channel.number, channelMetadata.name, channel.callSign,
        /// affiliateCallSign or uri must be specified.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// A URL to an image that describes the channel. Can be null
        /// </summary>
        [JsonProperty("image")]
        public string Image { get; set; }
    }
}
