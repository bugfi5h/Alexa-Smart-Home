using RKon.Alexa.NET.Payloads;

namespace RKon.Alexa.NET.Response
{
    /// <summary>
    /// Interface for Events
    /// </summary>
    public interface IEvent
    {
        /// <summary>
        /// EventHeader
        /// </summary>
        EventHeader Header { get; set; }
        /// <summary>
        /// EventPayload
        /// </summary>
        Payload Payload { get; set; }
    }
}
