
using Newtonsoft.Json;

namespace RKon.Alexa.NET46.JsonObjects
{
    /// <summary>
    /// Cahnnel for ChangeChannelRequests
    /// </summary>
    public class Channel
    {
        /// <summary>
        /// Standardconstructor
        /// </summary>
        public Channel()
        {
        }

        /// <summary>
        /// Initializes Channel
        /// </summary>
        /// <param name="number"></param>
        /// <param name="callSign"></param>
        /// <param name="affiliateCallSign"></param>
        /// <param name="uri"></param>
        public Channel(string number, string callSign, string affiliateCallSign, string uri = null)
        {
            this.Number = number;
            this.CallSign = callSign;
            this.AffiliateCallSign = affiliateCallSign;
            Uri = uri;
        }

        /// <summary>
        ///  A number that identifies the specified channel such as 5 or 12.1. Can be Null, but channel.number, channelMetadata.name, channel.callSign,
        /// affiliateCallSign or uri must be specified.
        /// </summary>
        [JsonProperty("number", NullValueHandling = NullValueHandling.Ignore)]
        public string Number { get; set; }
        /// <summary>
        /// Specifies a channel by call sign such as PBS. Can be Null, but channel.number, channelMetadata.name, channel.callSign,
        /// affiliateCallSign or uri must be specified.
        /// </summary>
        [JsonProperty("callSign", NullValueHandling = NullValueHandling.Ignore)]
        public string CallSign { get; set; }
        /// <summary>
        /// Specifies a channel by local affiliate call sign such as KCTS9. Can be Null, but channel.number, channelMetadata.name, channel.callSign,
        /// affiliateCallSign or uri must be specified.
        /// </summary>
        [JsonProperty("affiliateCallSign", NullValueHandling = NullValueHandling.Ignore)]
        public string AffiliateCallSign { get; set; }
        /// <summary>
        /// The URI of the channel such as “entity://provider/channel/12307”. Can be Null, but channel.number, channelMetadata.name, channel.callSign,
        /// affiliateCallSign or uri must be specified.
        /// </summary>
        [JsonProperty("uri", NullValueHandling = NullValueHandling.Ignore)]
        public string Uri { get; set; }
    }
}
