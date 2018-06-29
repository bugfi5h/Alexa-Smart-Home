

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RKon.Alexa.NET46.Types
{
    /// <summary>
    /// Possible error types
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ErrorTypes
    {
        /// <summary>
        /// Indicates the target bridge endpoint is currently unreachable or offline.
        /// For example, the bridge might be turned off, 
        /// disconnected from the customer's local area network, or connectivity between the bridge and the device cloud might have been lost.
        /// </summary>
        BRIDGE_UNREACHABLE,
        /// <summary>
        /// 	Indicates the target endpoint cannot respond because it is performing another action, which may or may not have originated from a request to Alexa.
        /// </summary>
        ENDPOINT_BUSY,
        /// <summary>
        /// Indicates the directive could not be completed because the target endpoint has low batteries.
        /// </summary>
        ENDPOINT_LOW_POWER,
        /// <summary>
        /// Indicates the target endpoint is currently unreachable or offline. 
        /// For example, the endpoint might be turned off, 
        /// disconnected from the customer's local area network, or connectivity between the endpoint and 
        /// bridge or the endpoint and the device cloud might have been lost.
        /// </summary>
        ENDPOINT_UNREACHABLE,
        /// <summary>
        /// Indicates that the authorization credential provided by Alexa has expired. For example, the OAuth2 access token for that customer has expired.
        /// </summary>
        EXPIRED_AUTHORIZATION_CREDENTIAL,
        /// <summary>
        /// Indicates a directive could not be handled because the firmware for a bridge or an endpoint is out of date.
        /// </summary>
        FIRMWARE_OUT_OF_DATE,
        /// <summary>
        /// Indicates a directive could not be handled because a bridge or an endpoint has experienced a hardware malfunction.
        /// </summary>
        HARDWARE_MALFUNCTION,
        /// <summary>
        /// Indicates an error that cannot be accurately described as one of the other error types occurred while you were handling the directive.
        /// For example, a generic runtime exception occurred while handling a directive. 
        /// Ideally, you will never send this error event, but instead send a more specific error type. 
        /// </summary>
        INTERNAL_ERROR,
        /// <summary>
        /// Indicates that the authorization credential provided by Alexa is invalid. For example, the OAuth2 access token is not valid for the customer's device cloud account. 
        /// </summary>
        INVALID_AUTHORIZATION_CREDENTIAL,
        /// <summary>
        /// Indicates a directive is not valid for this skill or is malformed.
        /// </summary>
        INVALID_DIRECTIVE,
        /// <summary>
        /// Indicates a directive contains an invalid value for the target endpoint.
        /// For example, use to indicate a request with an invalid heating mode, channel value or program value.
        /// </summary>
        INVALID_VALUE,
        /// <summary>
        /// Indicates the target endpoint does not exist or no longer exists.
        /// </summary>
        NO_SUCH_ENDPOINT,
        /// <summary>
        /// Indicates the target endpoint cannot be set to the specified value because of its current mode of operation.
        /// </summary>
        NOT_SUPPORTED_IN_CURRENT_MODE,
        /// <summary>
        /// Indicates the maximum rate at which an endpoint or bridge can process directives has been exceeded.
        /// </summary>
        RATE_LIMIT_EXCEEDED,
        /// <summary>
        /// Indicates a directive that contains a value that outside the numeric temperature range accepted for the target thermostat.
        /// For more thermostat-specific errors, see the error section of the Alexa.ThermostatController interface. 
        /// Note that the namespace for thermostat-specific errors is Alexa.ThermostatController
        /// </summary>
        TEMPERATURE_VALUE_OUT_OF_RANGE,
        /// <summary>
        /// Indicates a directive contains a value that is outside the numerical range accepted for the target endpoint.
        /// For example, use to respond to a request to set a percentage value over 100 percent. For temperature values, use TEMPERATURE_VALUE_OUT_OF_RANGE
        /// </summary>
        VALUE_OUT_OF_RANGE,
        /// <summary>
        ///  	Thermostat is off and cannot be turned on.
        /// </summary>
        THERMOSTAT_IS_OFF,
        /// <summary>
        /// Setpoints are too close together.
        /// </summary>
        REQUESTED_SETPOINTS_TOO_CLOSE,
        /// <summary>
        /// The thermostat doesn’t support the specified mode.
        /// </summary>
        UNSUPPORTED_THERMOSTAT_MODE,
        /// <summary>
        /// The thermostat doesn’t support dual setpoints in the current mode.
        /// </summary>
        DUAL_SETPOINTS_UNSUPPORTED,
        /// <summary>
        /// The thermostat doesn’t support triple setpoints in the current mode.
        /// </summary>
        TRIPLE_SETPOINTS_UNSUPPORTED,
        /// <summary>
        /// You cannot set the value because it may cause damage to the device or appliance.
        /// </summary>
        UNWILLING_TO_SET_VALUE,
        /// <summary>
        /// If an error occurs for one of the following reasons, you should return an ACCEPT_GRANT_FAILED error type with a message that describes the error in more detail.
        ///   You were unable to call Login with Amazon to exchange the authorization code for access and refresh tokens
        ///  You were trying to store the access and refresh tokens for the customer, but were unable to complete the operation for some reason
        ///  Any other errors that occurred while trying to retrieve and store the access and refresh tokens
        /// </summary>
        ACCEPT_GRANT_FAILED
    }
}
