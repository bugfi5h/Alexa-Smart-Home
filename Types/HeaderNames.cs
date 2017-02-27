using System.Collections.Generic;

namespace RKon.Alexa.NET.Types
{
    /// <summary>
    /// Smarthomerequest, -response, und -errorresponse Headernames
    /// </summary>
    public class HeaderNames
    {
        public const string DISCOVERY_REQUEST = "DiscoverAppliancesRequest";
        public const string HEALTH_CHECK_REQUEST = "HealthCheckRequest";
        public const string TURN_ON_REQUEST = "TurnOnRequest";
        public const string TURN_OFF_REQUEST = "TurnOffRequest";
        public const string SET_TARGET_TEMPERATURE_REQUEST = "SetTargetTemperatureRequest";
        public const string INCREMENT_TARGET_TEMPERATURE_REQUEST = "IncrementTargetTemperatureRequest";
        public const string DECREMENT_TARGET_TEMPERATURE_REQUEST = "DecrementTargetTemperatureRequest";
        public const string SET_PERCENTAGE_REQUEST = "SetPercentageRequest";
        public const string INCREMENT_PERCENTAGE_REQUEST = "IncrementPercentageRequest";
        public const string DECREMENT_PERCENTAGE_REQUEST = "DecrementPercentageRequest";

        #region ERROR_NAMES

        public const string VALUE_OUT_OF_RANGE_ERROR = "ValueOutOfRangeError";
        public const string TARGET_OFFLINE_ERROR = "TargetOfflineError";
        public const string BRIDGE_OFFLINE_ERROR = "BridgeOfflineError";
        public const string NO_SUCH_TARGET_ERROR = "NoSuchTargetError";

        public const string DRIVER_INTERNAL_ERROR = "DriverInternalError";
        public const string DEPENDENT_SERVICE_UNAVAILABLE_ERROR = "DependentServiceUnavailableError";
        public const string TARGET_CONNECTIVITY_UNSTABLE_ERROR = "TargetConnectivityUnstableError";
        public const string TARGET_BRIDGE_CONNECTIVITY_UNSTABLE_ERROR = "TargetBridgeConnectivityUnstableError";
        public const string TARGET_FIRMWARE_OUTDATED_ERROR = "TargetFirmwareOutdatedError";
        public const string TARGET_BRIDGE_FIRMWARE_OUTDATED_ERROR = "TargetBridgeFirmwareOutdatedError";
        public const string TARGET_HARDWARE_MALFUNCTION_ERROR = "TargetHardwareMalfunctionError";
        public const string TARGET_BRIDGE_HARDWARE_MALFUNCTION_ERROR = "TargetBridgetHardwareMalfunctionError";
        public const string UNWILLING_TO_SET_VALUE_ERROR = "UnwillingToSetValueError";
        public const string RATE_LIMIT_EXCEEDED_ERROR = "RateLimitExceededError";
        public const string NOT_SUPPORTED_IN_CURRENT_MODE_ERROR = "NotSupportedInCurrentModeError";

        public const string EXSPIRED_ACCESS_TOKEN_ERROR = "ExpiredAccessTokenError";
        public const string INVALID_ACCESS_TOKEN_ERROR = "InvalidAccessTokenError";
        public const string UNSUPPORTED_TARGET_ERROR = "UnsupportedTargetError";
        public const string UNSUPPORTED_OPERATION_ERROR = "UnsupportedOperationError";
        public const string UNSUPPORTED_TARGET_SETTING_ERROR = "UnsupportedTargetSettingError";
        public const string UNEXCEPTED_INFORMATION_RECEIVED_ERROR = "UnexpectedInformationReceivedError";

        #endregion

        /// <summary>
        /// KeyValuePairs von RequestHeaderNames(Key) und ResponseHeaderNames(Value).
        /// </summary>
        public static readonly Dictionary<string, string> ResponseHeaderNames = new Dictionary<string, string>()
        {
            {DISCOVERY_REQUEST,"DiscoverAppliancesResponse"},
            {HEALTH_CHECK_REQUEST, "HealthCheckResponse"},
            {TURN_ON_REQUEST,"TurnOnConfirmation"},
            {TURN_OFF_REQUEST,"TurnOffConfirmation"},
            {SET_TARGET_TEMPERATURE_REQUEST,"SetTargetTemperatureConfirmation"},
            {INCREMENT_TARGET_TEMPERATURE_REQUEST,"IncrementTargetTemperatureConfirmation"},
            {DECREMENT_TARGET_TEMPERATURE_REQUEST,"DecrementTargetTemperatureConfirmation"},
            {SET_PERCENTAGE_REQUEST,"SetPercentageConfirmation"},
            {INCREMENT_PERCENTAGE_REQUEST,"IncrementPercentageConfirmation"},
            {DECREMENT_PERCENTAGE_REQUEST,"DecrementPercentageConfirmation"}
        };
    }
}
