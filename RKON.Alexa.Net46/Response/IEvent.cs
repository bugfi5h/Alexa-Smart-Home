using RKon.Alexa.NET46.Payloads;

namespace RKon.Alexa.NET46.Response
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
