﻿using Newtonsoft.Json;

namespace RKon.Alexa.NET.JsonObjects
{
    /// <summary>
    /// Descripes a Property in Context Objects
    /// </summary>
    public class Property
    {
        /// <summary>
        /// Specifies the interface for the property
        /// </summary>
        [JsonProperty("namespace")]
        public string Namespace { get; set; }
        /// <summary>
        /// The property name being reported
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// The value for the property specified by name
        /// </summary>
        [JsonProperty("value")]
        public object Value { get; set; }//TODO
        /// <summary>
        /// The time at which the property value was provided in ISO 8601 format, and specified in UTC
        /// </summary>
        [JsonProperty("timeOfSample")]
        public string TimeOfSample { get; set; }
        /// <summary>
        /// Indicates the uncertainty of the reported property in milliseconds of elapsed time since the property value was retrieved. For example, if you obtain this value by polling a hardware device every 60 seconds, then the uncertainty in the time of the sampled value would be 60000 in milliseconds.
        /// </summary>
        [JsonProperty("uncertaintyInMilliseconds")]
        public string UncertaintyInMilliseconds { get; set; }
    }
}
