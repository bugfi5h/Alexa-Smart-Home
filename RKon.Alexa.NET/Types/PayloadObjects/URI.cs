﻿using Newtonsoft.Json;

namespace RKon.Alexa.NET.Types.PayloadObjects
{
    public class URI
    {
        /// <summary>
        /// String Value of the URL
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
