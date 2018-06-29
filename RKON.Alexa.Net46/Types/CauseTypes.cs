using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RKon.Alexa.NET46.Types
{
    /// <summary>
    /// The cause attribute is used to describe the cause of a property value change when you send a ChangeReport event. It is a polymorphic type with the following descendant types:
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CauseTypes
    {
        /// <summary>
        ///  	Indicates that the event was caused by a customer interaction with an application. For example, a customer switches on a light, or locks a door using the Alexa app or an app provided by a device vendor.
        /// </summary>
        APP_INTERACTION,
        /// <summary>
        /// Indicates that the event was caused by a physical interaction with an endpoint. For example manually switching on a light or manually locking a door lock
        /// </summary>
        PHYSICAL_INTERACTION,
        /// <summary>
        /// Indicates that the event was caused by the periodic poll of an appliance, which found a change in value. For example, you might poll a temperature sensor every hour, and send the updated temperature to Alexa.
        /// </summary>
        PERIODIC_POLL,
        /// <summary>
        /// Indicates that the event was caused by the application of a device rule. For example, a customer configures a rule to switch on a light if a motion sensor detects motion. In this case, Alexa receives an event from the motion sensor, and another event from the light to indicate that its state change was caused by the rule.
        /// </summary>
        RULE_TRIGGER,
        /// <summary>
        /// Indicates that the event was caused by a voice interaction with Alexa. For example a user speaking to their Echo device.
        /// </summary>
        VOICE_INTERACTION
    }
}
