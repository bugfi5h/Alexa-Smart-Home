
using Newtonsoft.Json;
using RKon.Alexa.NET46.Types;

namespace RKon.Alexa.NET46.JsonObjects.Grantee
{
    /// <summary>
    ///  	A polymorphic type that provides identifying information for a customer in a linked account service or system.
    /// </summary>
    [JsonConverter(typeof(GranteeConverter))]
    public class Grantee
    {
        /// <summary>
        /// The Type of the Scope (Has to be changed in the future if it gets other types as Scope
        /// </summary>
        [JsonProperty("type")]
        public GranteeTypes Type { get; set; }
    }
}
