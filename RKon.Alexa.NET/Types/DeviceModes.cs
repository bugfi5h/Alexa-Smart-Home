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
        /// <summary>
        /// Indicates that the appliance is currently locked.
        /// </summary>
        LOCKED,
        /// <summary>
        /// Indicates that the appliances is currently unlocked.
        /// </summary>
        UNLOCKED,
        /// <summary>
        /// Indicates that the lock cannot complete its transition to “LOCKED” or “UNLOCKED” because the locking mechanism is jammed.
        /// </summary>
        JAMMED
    }

    /// <summary>
    /// List of all Powerstates
    /// </summary>
    public enum PowerStates
    {
        /// <summary>
        /// turned od
        /// </summary>
        ON,
        /// <summary>
        /// turned off
        /// </summary>
        OFF
    }

    /// <summary>
    /// List of all ErrorColorTemperature modes
    /// </summary>
    public enum ColorTemperatureModes
    {
        /// <summary>
        ///  	Automatic heat or cool selection based on the temperature reading and the setpoint
        /// </summary>
        AUTO,
        /// <summary>
        ///  Away Mode
        /// </summary>
        AWAY,
        /// <summary>
        /// Color Mode
        /// </summary>
        COLOR,
        /// <summary>
        /// Asleep mode
        /// </summary>
        ASLEEP,
        /// <summary>
        /// Not proisioned mode
        /// </summary>
        NOT_PROVISIONED,
        /// <summary>
        /// cooling mode
        /// </summary>
        COOL,
        /// <summary>
        /// heating mode
        /// </summary>
        HEAT,
        /// <summary>
        /// other mode
        /// </summary>
        OTHER
    }

}
