namespace RKon.Alexa.NET.Types
{
    /// <summary>
    /// List of all ThermostatModes
    /// </summary>
    public enum ThermostatModes
    {
        /// <summary>
        ///  	Automatic heat or cool selection based on the temperature reading and the setpoint
        /// </summary>
        AUTO,
        /// <summary>
        /// cooling mode
        /// </summary>
        COOL,
        /// <summary>
        ///  	heating mode
        /// </summary>
        HEAT,
        /// <summary>
        /// economical mode
        /// </summary>
        ECO,
        /// <summary>
        /// heating/cooling is turned off, but the device may still have power
        /// </summary>
        OFF,
        /// <summary>
        ///  	A custom mode specified by an additional field customName
        /// </summary>
        CUSTOM
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
