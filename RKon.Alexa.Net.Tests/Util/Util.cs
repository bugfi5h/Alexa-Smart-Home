using Newtonsoft.Json;
using RKon.Alexa.NET.Response;
using System;

namespace RKon.Alexa.Net.Tests.Util
{
    public class Util
    {
        public static void WriteJsonToConsole(string name, SmartHomeResponse response)
        {
            Console.WriteLine($"---{name}---{Environment.NewLine}{JsonConvert.SerializeObject(response, Formatting.Indented)}");
        }
    }
}
