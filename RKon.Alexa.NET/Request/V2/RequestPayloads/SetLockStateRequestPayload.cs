

using Newtonsoft.Json;
using RKon.Alexa.NET.Types;

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
        [JsonProperty(PropertyNames.LOCK_STATE)]
        public string LockState { get; private set; }
    }
}
