using System.Collections.Generic;

namespace RKon.Alexa.NET.Types
{
    /// <summary>
    /// Smarthomerequest, -response, and -errorresponse Headernames
    /// </summary>
    public class HeaderNames
    {
        /// <summary>
        /// Headernames in V3
        /// </summary>
        public static class V3
        {
            #region HeaderNames
            /// <summary>
            /// Header Name for the DiscoverAppliance Requests.
            /// </summary>
            public const string DISCOVERY_REQUEST = "Discover";
            /// <summary>
            /// Header Name for Report States.
            /// </summary>
            public const string REPORT_STATE = "ReportState";
            /// <summary>
            /// Header Name for the Turn On Requests.
            /// </summary>
            public const string TURN_ON_REQUEST = "TurnOn";
            /// <summary>
            /// Header Name for the Turn Off Requests.
            /// </summary>
            public const string TURN_OFF_REQUEST = "TurnOff";
            /// <summary>
            /// Header Name for the Set Power Level Requests.
            /// </summary>
            public const string SET_POWER_LEVEL = "SetPowerLevel";
            /// <summary>
            /// Header Name for the Adjust Power Level Requests.
            /// </summary>
            public const string ADJUST_POWER_LEVEL = "AdjustPowerLevel";
            /// <summary>
            /// Header Name for the Lock Requests.
            /// </summary>
            public const string LOCK = "Lock";
            /// <summary>
            /// Header Name for the Unlock Requests.
            /// </summary>
            public const string UNLOCK = "Unlock";
            /// <summary>
            /// Header Name for SetTargetTemperature Requests.
            /// </summary>
            public const string SETTARGETTEMPERATURE = "SetTargetTemperature";
            /// <summary>
            /// Header Name for AdjustTargetTemperature Requests.
            /// </summary>
            public const string ADJUSTTARGETTEMPERATURE = "AdjustTargetTemperature";
            /// <summary>
            /// Header Name for SetPercentage Requests.
            /// </summary>
            public const string SET_PERCENTAGE = "SetPercentage";
            /// <summary>
            /// Header Name for AdjustPercentage Requests.
            /// </summary>
            public const string ADJUST_PERCENTAGE = "AdjustPercentage";
            /// <summary>
            /// Header Name for SetBrightness Requests.
            /// </summary>
            public const string SET_BRIGHTNESS = "SetBrightness";
            /// <summary>
            /// Header Name for AdjustBrightness Requests.
            /// </summary>
            public const string ADJUST_BRIGHTNESS = "AdjustBrightness";
            /// <summary>
            /// Header Name for SetColor Requests.
            /// </summary>
            public const string SET_COLOR = "SetColor";
            /// <summary>
            /// Header Name for SetColorTemperature Requests.
            /// </summary>
            public const string SET_COLORTEMPERATURE = "SetColorTemperature";
            /// <summary>
            /// Header Name for IncreaseColorTemperature Requests.
            /// </summary>
            public const string INCREASE_COLORTEMPERATURE = "IncreaseColorTemperature";
            /// <summary>
            /// Header Name for DecreaseColorTemperature Requests.
            /// </summary>
            public const string DECREASE_COLORTEMPERATURE = "DecreaseColorTemperature";
            /// <summary>
            /// Header Name for InitializeCameraStreams Requests.
            /// </summary>
            public const string INIT_CAMERA_STREAMS = "InitializeCameraStreams";
            /// <summary>
            /// Header Name for ChangeChannel Requests.
            /// </summary>
            public const string CHANGE_CHANNEL = "ChangeChannel";
            /// <summary>
            /// Header Name for SkipChannels Requests.
            /// </summary>
            public const string SKIP_CHANNELS = "SkipChannels";
            /// <summary>
            /// Header Name for SelectInput Requests.
            /// </summary>
            public const string SELECT_INPUT = "SelectInput";
            /// <summary>
            /// Header Name for FastForward Requests.
            /// </summary>
            public const string FAST_FORWARD = "FastForward";
            /// <summary>
            /// Header Name for Next Requests.
            /// </summary>
            public const string NEXT = "Next";
            /// <summary>
            /// Header Name for Pause Requests.
            /// </summary>
            public const string PAUSE = "Pause";
            /// <summary>
            /// Header Name for Play Requests.
            /// </summary>
            public const string PLAY = "Play";
            /// <summary>
            /// Header Name for Previous Requests.
            /// </summary>
            public const string PREVIOUS = "Previous";
            /// <summary>
            /// Header Name for Rewind Requests.
            /// </summary>
            public const string REWIND = "Rewind";
            /// <summary>
            /// Header Name for StartOver Requests.
            /// </summary>
            public const string START_OVER = "StartOver";
            /// <summary>
            /// Header Name for Stop Requests.
            /// </summary>
            public const string STOP = "Stop";
            /// <summary>
            /// Header Name for AdjustVolume Requests.
            /// </summary>
            public const string ADJUST_VOLUME = "AdjustVolume";
            /// <summary>
            /// Header Name for SetMute Requests.
            /// </summary>
            public const string SET_MUTE = "SetMute";
            /// <summary>
            /// Header Name for SetMute Requests.
            /// </summary>
            public const string SET_VOLUME = "SetVolume";
            #endregion
            /// <summary>
            /// Header Name for Responses;
            /// </summary>
            public const string RESPONSE = "Response";
        }

        /// <summary>
        /// Headernames in V2
        /// </summary>
        public static class V2
        {
            #region HeaderNames
            /// <summary>
            /// Header Name for the DiscoverAppliance Requests.
            /// </summary>
            public const string DISCOVERY_REQUEST = "DiscoverAppliancesRequest";
            /// <summary>
            /// Header Name for the HealthCheck Requests.
            /// </summary>
            public const string HEALTH_CHECK_REQUEST = "HealthCheckRequest";
            /// <summary>
            /// Header Name for the Turn On Requests.
            /// </summary>
            public const string TURN_ON_REQUEST = "TurnOnRequest";
            /// <summary>
            /// Header Name for the Turn Off Requests.
            /// </summary>
            public const string TURN_OFF_REQUEST = "TurnOffRequest";
            /// <summary>
            /// Header Name for the SetTargetTemperature Requests.
            /// </summary>
            public const string SET_TARGET_TEMPERATURE_REQUEST = "SetTargetTemperatureRequest";
            /// <summary>
            /// Header Name for the IncrementTargetTemperature Requests.
            /// </summary>
            public const string INCREMENT_TARGET_TEMPERATURE_REQUEST = "IncrementTargetTemperatureRequest";
            /// <summary>
            /// Header Name for the DecrementTargetTemperature Requests.
            /// </summary>
            public const string DECREMENT_TARGET_TEMPERATURE_REQUEST = "DecrementTargetTemperatureRequest";
            /// <summary>
            /// Header Name for the SetPercentage Requests.
            /// </summary>
            public const string SET_PERCENTAGE_REQUEST = "SetPercentageRequest";
            /// <summary>
            /// Header Name for the IncrementPercentage Requests.
            /// </summary>
            public const string INCREMENT_PERCENTAGE_REQUEST = "IncrementPercentageRequest";
            /// <summary>
            /// Header Name for the DecrementPercentage Requests.
            /// </summary>
            public const string DECREMENT_PERCENTAGE_REQUEST = "DecrementPercentageRequest";
            /// <summary>
            /// Header Name for the SetColor Requests.
            /// </summary>
            public const string SET_COLOR_REQUEST = "SetColorRequest";
            /// <summary>
            /// Header Name for the IncrementColorTemperature Requests
            /// </summary>
            public const string INCREMENT_COLOR_TEMPERATURE_REQUEST = "IncrementColorTemperatureRequest";
            /// <summary>
            /// Header Name for the DecrementColorTemperature Requests
            /// </summary>
            public const string DECREMENT_COLOR_TEMPERATURE_REQUEST = "DecrementColorTemperatureRequest";
            /// <summary>
            /// Header Name for the SetColorTemperature Requests
            /// </summary>
            public const string SET_COLOR_TEMPERATURE_REQUEST = "SetColorTemperatureRequest";
            /// <summary>
            /// Header Name for the GetTemperatureReading Requests
            /// </summary>
            public const string GET_TEMPERATURE_READING_REQUEST = "GetTemperatureReadingRequest";
            /// <summary>
            /// Header Name for the GetTargetTemperature Requests
            /// </summary>
            public const string GET_TARGET_TEMPERATURE_REQUEST = "GetTargetTemperatureRequest";
            /// <summary>
            /// Header Name for the GetLockState Requests
            /// </summary>
            public const string GET_LOCK_STATE_REQUEST = "GetLockStateRequest";
            /// <summary>
            /// Header Name for the SetLockState Requests
            /// </summary>
            public const string SET_LOCK_STATE_REQUEST = "SetLockStateRequest";

            /// <summary>
            /// Header Name for the SetLockState Requests
            /// </summary>
            public const string RETRIEVE_CAMERA_STREAM_URI_REQUEST = "RetrieveCameraStreamUriRequest";
            #endregion


            #region ERROR_NAMES
            /// <summary>
            /// Error Header Name if value out of range
            /// </summary>
            public const string VALUE_OUT_OF_RANGE_ERROR = "ValueOutOfRangeError";
            /// <summary>
            /// Error Header Name if the target is offline
            /// </summary>
            public const string TARGET_OFFLINE_ERROR = "TargetOfflineError";
            /// <summary>
            /// Error Header Name if the Bridge or the Hub for the device is offline
            /// </summary>
            public const string BRIDGE_OFFLINE_ERROR = "BridgeOfflineError";
            /// <summary>
            /// Error Header Name if the target does not exist
            /// </summary>
            public const string NO_SUCH_TARGET_ERROR = "NoSuchTargetError";
            /// <summary>
            /// Error Header Name for runtime erros
            /// </summary>
            public const string DRIVER_INTERNAL_ERROR = "DriverInternalError";
            /// <summary>
            /// Error Header Name if a dependent service is unavailable
            /// </summary>
            public const string DEPENDENT_SERVICE_UNAVAILABLE_ERROR = "DependentServiceUnavailableError";
            /// <summary>
            /// Error Header Name if the target connectivity is unstable
            /// </summary>
            public const string TARGET_CONNECTIVITY_UNSTABLE_ERROR = "TargetConnectivityUnstableError";
            /// <summary>
            /// Error Header Name if the connection to the Bridge or Hub dis unstable
            /// </summary>
            public const string TARGET_BRIDGE_CONNECTIVITY_UNSTABLE_ERROR = "TargetBridgeConnectivityUnstableError";
            /// <summary>
            /// Error Header Name if the firmware of the appliance is outdated 
            /// </summary>
            public const string TARGET_FIRMWARE_OUTDATED_ERROR = "TargetFirmwareOutdatedError";
            /// <summary>
            /// Error Header Name if the Firmware of the Bridge or Hub is outdated 
            /// </summary>
            public const string TARGET_BRIDGE_FIRMWARE_OUTDATED_ERROR = "TargetBridgeFirmwareOutdatedError";
            /// <summary>
            /// Error Header Name if the appliance has a hardware malfunction
            /// </summary>
            public const string TARGET_HARDWARE_MALFUNCTION_ERROR = "TargetHardwareMalfunctionError";
            /// <summary>
            /// Error Header Name if the Hub or the Bridge has a hardware malfunction
            /// </summary>
            public const string TARGET_BRIDGE_HARDWARE_MALFUNCTION_ERROR = "TargetBridgetHardwareMalfunctionError";
            /// <summary>
            /// Error Header Name if the target is unwilling to set the value
            /// </summary>
            public const string UNWILLING_TO_SET_VALUE_ERROR = "UnwillingToSetValueError";
            /// <summary>
            /// Error Header Name if the Requestlimit is exseeded
            /// </summary>
            public const string RATE_LIMIT_EXCEEDED_ERROR = "RateLimitExceededError";
            /// <summary>
            /// Error Header Name if the action is not supported in the current mode
            /// </summary>
            public const string NOT_SUPPORTED_IN_CURRENT_MODE_ERROR = "NotSupportedInCurrentModeError";

            /// <summary>
            /// Error Header Name if the Access Token is exspired.
            /// </summary>
            public const string EXSPIRED_ACCESS_TOKEN_ERROR = "ExpiredAccessTokenError";
            /// <summary>
            /// Error Header Name if the übergebene Access Token is invalid.
            /// </summary>
            public const string INVALID_ACCESS_TOKEN_ERROR = "InvalidAccessTokenError";
            /// <summary>
            /// Error Header Name the target is not supported by the skill adapter
            /// </summary>
            public const string UNSUPPORTED_TARGET_ERROR = "UnsupportedTargetError";
            /// <summary>
            /// Error Header Name if the operation is not supported by the appliance.
            /// </summary>
            public const string UNSUPPORTED_OPERATION_ERROR = "UnsupportedOperationError";
            /// <summary>
            /// Error Header Name if the setting is not supported by the appliance.
            /// </summary>
            public const string UNSUPPORTED_TARGET_SETTING_ERROR = "UnsupportedTargetSettingError";
            /// <summary>
            /// Error Header Name if a parameter has a unecpeted information
            /// </summary>
            public const string UNEXCEPTED_INFORMATION_RECEIVED_ERROR = "UnexpectedInformationReceivedError";

            #endregion

            /// <summary>
            /// KeyValuePairs of RequestHeaderNames(Key) and ResponseHeaderNames(Value).
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
                {DECREMENT_PERCENTAGE_REQUEST,"DecrementPercentageConfirmation"},
                {SET_COLOR_REQUEST,"SetColorConfirmation" },
                {SET_COLOR_TEMPERATURE_REQUEST,"SetColorTemperatureConfirmation" },
                {INCREMENT_COLOR_TEMPERATURE_REQUEST,"IncrementColorTemperatureConfirmation" },
                {DECREMENT_COLOR_TEMPERATURE_REQUEST, "DecrementColorTemperatureConfirmation" },
                {GET_TEMPERATURE_READING_REQUEST, "GetTemperatureReadingResponse" },
                { GET_TARGET_TEMPERATURE_REQUEST, "GetTargetTemperatureResponse" },
                {GET_LOCK_STATE_REQUEST, "GetLockStateResponse" },
                {SET_LOCK_STATE_REQUEST, "SetLockStateConfirmation" },
                {RETRIEVE_CAMERA_STREAM_URI_REQUEST, "RetrieveCameraStreamUriResponse" }
            };
        }
    }
}
