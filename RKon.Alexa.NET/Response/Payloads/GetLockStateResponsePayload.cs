using Newtonsoft.Json;
using RKon.Alexa.NET.Types;
using System;

namespace RKon.Alexa.NET.Response
{
    /// <summary>
    /// Responsepayload for GetLockState
    /// </summary>
    public class GetLockStateResponsePayload : ResponsePayload
    {
        /// <summary>
        ///  	Indicates the locked state of the specified appliance. Valid values are LOCKED, UNLOCKED
        /// </summary>
        [JsonProperty("lockState")]
        [JsonRequired]
        public string LockState { get; private set; }

        /// <summary>
        ///  A time-stamp representing when the lockState above was last retrieved from the target appliance. Can be null.
        /// </summary>
        [JsonProperty("applianceResponseTimeStamp",NullValueHandling =NullValueHandling.Ignore)]
        public DateTime? ApplianceResponseTimeStamp { get; set; }

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
