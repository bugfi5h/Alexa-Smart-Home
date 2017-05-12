

using Newtonsoft.Json;

namespace RKon.Alexa.NET46.Request.RequestPayloads
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
