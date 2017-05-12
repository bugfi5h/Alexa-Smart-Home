

namespace RKon.Alexa.NET46.Response
{
    /// <summary>
    /// Interface for a definition of a SmartHome Response
    /// </summary>
    public interface ISmartHomeResponse
    {
        /// <summary>
        /// Header
        /// </summary>
        ResponseHeader Header { get; set; }
        /// <summary>
        /// Payload
        /// </summary>
        ResponsePayload Payload { get; set; }
        /// <summary>
        /// Return the Payload Type
        /// </summary>
        /// <returns>System.Type of the Payloads</returns>
        System.Type GetResponsePayloadType();
    }
}
