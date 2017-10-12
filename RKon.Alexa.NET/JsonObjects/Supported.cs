﻿using Newtonsoft.Json;


namespace RKon.Alexa.NET.JsonObjects
{
    /// <summary>
    /// Supported interfaces 
    /// </summary>
    public class Supported
    {
        /// <summary>
        /// Name of the Property
        /// </summary>
        [JsonProperty("name")]
        [JsonRequired]
        public string Name { get; set; }
    }
}
