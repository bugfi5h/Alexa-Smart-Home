using System.Collections.Generic;

namespace RKon.Alexa.NET.Types
{
    /// <summary>
    /// List of all ThermostatModes
    /// </summary>
    public enum ThermostatModes
    {
        AUTO, HEAT, COOL, OFF, ECO
    }
    /// <summary>
    ///List of all Lockstates
    /// </summary>
    public enum LockModes
    {
        LOCKED, UNLOCKED, JAMMED
    }

    /// <summary>
    /// List of all Powerstates
    /// </summary>
    public enum PowerStates
    {
        ON, OFF
    }

    /// <summary>
    /// List of all ErrorColorTemperature modes
    /// </summary>
    public enum ColorTemperatureModes
    {
        AUTO, AWAY, COLOR, ASLEEP, NOT_PROVISIONED, COOL, HEAT, OTHER
    }

}
