using Newtonsoft.Json;
using RKon.Alexa.NET46.JsonObjects;
using RKon.Alexa.NET46.JsonObjects.Grantee;

namespace RKon.Alexa.NET46.Payloads
{
    /// <summary>
    /// The purpose of the AcceptGrant is to enable you to obtain credentials that identify and authenticate a customer to Alexa. You must implement this directive in order to send events to the Alexa event gateway. An AcceptGrant directive is sent by Alexa after a customer enables a smart home skill and goes through the account linking process or when an existing skill is upgraded to support asynchronous responses and/or proactive events.
    /// </summary>
    public class AcceptGrantRequestPayload :Payload
    {
        /// <summary>
        ///  	A polymorphic type that provides identifying information for a customer in Amazon Alexa systems.
        /// </summary>
        [JsonProperty("grant")]
        [JsonRequired]
        public Grant Grant { get; set; }

        /// <summary>
        /// A polymorphic type that provides identifying information for a customer in a linked account service or system.
        /// </summary>
        [JsonProperty("grantee")]
        [JsonRequired]
        public Grantee Grantee { get; set; }
    }
}
