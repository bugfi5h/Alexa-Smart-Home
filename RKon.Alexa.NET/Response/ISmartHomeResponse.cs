

namespace RKon.Alexa.NET.Response
{
    /// <summary>
    /// Interface zur Definition einer SmartHome Response
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
        /// Rückgabe des Payload Typs
        /// </summary>
        /// <returns>System.Type des Payloads</returns>
        System.Type GetResponsePayloadType();
    }
}
