using System.Collections.Generic;

namespace RKon.Alexa.NET.Types
{
    /// <summary>
    /// List of all device modes
    /// </summary>
    public enum DeviceModes
    {
        AUTO, HEAT, COOL, AWAY, OTHER
    }
    /// <summary>
    /// List of all Temperature modes
    /// </summary>
    public enum TemperatureModes
    {
        AUTO, HEAT, COOL
    }
    /// <summary>
    /// List of all GetTemperature modes
    /// </summary>
    public enum GetTemperatureModes
    {
        AUTO, HEAT, COOL, OFF, CUSTOM, ECO
    }
    /// <summary>
    ///List of all Lockstates
    /// </summary>
    public enum LockModes
    {
        LOCKED, UNLOCKED
    }
}
