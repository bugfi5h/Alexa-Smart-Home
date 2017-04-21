

using Newtonsoft.Json;

namespace RKon.Alexa.NET.Request.RequestPayloads
{
    /// <summary>
    /// Payload for SetLockStateRequest
    /// </summary>
    public class SetLockStateRequestPayload : RequestPayloadWithAppliance
    {
        /// <summary>
        /// LockState
        /// </summary>
        [JsonProperty("lockState")]
        public string LockState { get; private set; }
    }
}
