using Newtonsoft.Json;
using System.Collections.Generic;

namespace RKon.Alexa.NET46.JsonObjects
{
    /// <summary>
    /// Indicates the properties of the interface which are supported by this endpoint in the format "name":"propertyName". If you do not specify a reportable property of the interface in this array, the default is to assume that proactivelyReported and retrievable for that property are false.
    /// </summary>
    public class Properties
    {
        /// <summary>
        /// Indicates the properties of the interface which are supported by this endpoint in the format "name":"propertyName". If you do not specify a reportable property of the interface in this array, the default is to assume that proactivelyReported and retrievable for that property are false.
        /// </summary>
        [JsonProperty("supported")]
        private List<Supported> Supported;

        /// <summary>
        /// Basicconstructor
        /// </summary>
        public Properties()
        {
            Supported = new List<Supported>();
        }
    }
}
