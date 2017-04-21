using Newtonsoft.Json;
using RKon.Alexa.NET.Types;


namespace RKon.Alexa.NET.Response
{
    /// <summary>
    /// ResponsePayload for a SetLockStateRequest
    /// </summary>
    public class SetLockStateResponsePayload : ResponsePayload
    {
        /// <summary>
        ///  	Indicates the locked state of the specified appliance. Valid values are LOCKED, UNLOCKED
        /// </summary>
        [JsonProperty("lockState")]
        [JsonRequired]
        public string LockState { get; private set; }

        /// <summary>
        /// Tries to set Lock State. Valid Options can be found in de Home Skill API or under DeviceModes.
        /// 
        /// </summary>
        /// <param name="state">Lockstate</param>
        /// <returns>Returns true, if lockstate was set</returns>
        public bool TrySetLockState(string state)
        {
            bool success = false;
            if (DeviceModes.LockModes.Contains(state.ToUpper()))
            {
                LockState = state;
                success = true;
            }
            return success;
        }
    }
}
