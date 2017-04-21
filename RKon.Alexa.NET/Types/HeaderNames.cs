using System.Collections.Generic;

namespace RKon.Alexa.NET.Types
{
    /// <summary>
    /// Smarthomerequest, -response, und -errorresponse Headernames
    /// </summary>
    public class HeaderNames
    {
        /// <summary>
        /// Header Name für DiscoverAppliance Requests.
        /// </summary>
        public const string DISCOVERY_REQUEST = "DiscoverAppliancesRequest";
        /// <summary>
        /// Header Name für HealthCheck Requests.
        /// </summary>
        public const string HEALTH_CHECK_REQUEST = "HealthCheckRequest";
        /// <summary>
        /// Header Name für Turn On Requests.
        /// </summary>
        public const string TURN_ON_REQUEST = "TurnOnRequest";
        /// <summary>
        /// Header Name für Turn Off Requests.
        /// </summary>
        public const string TURN_OFF_REQUEST = "TurnOffRequest";
        /// <summary>
        /// Header Name für SetTargetTemperature Requests.
        /// </summary>
        public const string SET_TARGET_TEMPERATURE_REQUEST = "SetTargetTemperatureRequest";
        /// <summary>
        /// Header Name für IncrementTargetTemperature Requests.
        /// </summary>
        public const string INCREMENT_TARGET_TEMPERATURE_REQUEST = "IncrementTargetTemperatureRequest";
        /// <summary>
        /// Header Name für DecrementTargetTemperature Requests.
        /// </summary>
        public const string DECREMENT_TARGET_TEMPERATURE_REQUEST = "DecrementTargetTemperatureRequest";
        /// <summary>
        /// Header Name für SetPercentage Requests.
        /// </summary>
        public const string SET_PERCENTAGE_REQUEST = "SetPercentageRequest";
        /// <summary>
        /// Header Name für IncrementPercentage Requests.
        /// </summary>
        public const string INCREMENT_PERCENTAGE_REQUEST = "IncrementPercentageRequest";
        /// <summary>
        /// Header Name für DecrementPercentage Requests.
        /// </summary>
        public const string DECREMENT_PERCENTAGE_REQUEST = "DecrementPercentageRequest";
        /// <summary>
        /// Header Name für SetColor Requests.
        /// </summary>
        public const string SET_COLOR_REQUEST = "SetColorRequest";
        /// <summary>
        /// Header Name für IncrementColorTemperature Requests
        /// </summary>
        public const string INCREMENT_COLOR_TEMPERATURE_REQUEST = "IncrementColorTemperatureRequest";
        /// <summary>
        /// Header Name für DecrementColorTemperature Requests
        /// </summary>
        public const string DECREMENT_COLOR_TEMPERATURE_REQUEST = "DecrementColorTemperatureRequest";
        /// <summary>
        /// Header Name für SetColorTemperature Requests
        /// </summary>
        public const string SET_COLOR_TEMPERATURE_REQUEST = "SetColorTemperatureRequest";
        /// <summary>
        /// Header Name für GetTemperatureReading Requests
        /// </summary>
        public const string GET_TEMPERATURE_READING_REQUEST = "GetTemperatureReadingRequest";
        /// <summary>
        /// Header Name für GetTargetTemperature Requests
        /// </summary>
        public const string GET_TARGET_TEMPERATURE_REQUEST = "GetTargetTemperatureRequest";



        #region ERROR_NAMES
        /// <summary>
        /// Error Header Name wenn der zu setzende Wert ausserhalb der unterstützen Spanne liegt
        /// </summary>
        public const string VALUE_OUT_OF_RANGE_ERROR = "ValueOutOfRangeError";
        /// <summary>
        /// Error Header Name wenn das angesprochene Gerät nicht erreichbar ist
        /// </summary>
        public const string TARGET_OFFLINE_ERROR = "TargetOfflineError";
        /// <summary>
        /// Error Header Name wenn die Bridge oder der Hub für das angesprochene Gerät nicht erreichbar ist
        /// </summary>
        public const string BRIDGE_OFFLINE_ERROR = "BridgeOfflineError";
        /// <summary>
        /// Error Header Name wenn das angesprochene Gerät nicht existiert
        /// </summary>
        public const string NO_SUCH_TARGET_ERROR = "NoSuchTargetError";
        /// <summary>
        /// Error Header Name für generische Laufzeitfehler
        /// </summary>
        public const string DRIVER_INTERNAL_ERROR = "DriverInternalError";
        /// <summary>
        /// Error Header Name wenn ein benötigter Dienst nicht erreichbar ist
        /// </summary>
        public const string DEPENDENT_SERVICE_UNAVAILABLE_ERROR = "DependentServiceUnavailableError";
        /// <summary>
        /// Error Header Name wenn die Verbindung zum angesprochenen Gerät nicht stabil ist
        /// </summary>
        public const string TARGET_CONNECTIVITY_UNSTABLE_ERROR = "TargetConnectivityUnstableError";
        /// <summary>
        /// Error Header Name wenn die Verbindung zur Bridge oder Hub des angesprochenen Geräts nicht stabil ist
        /// </summary>
        public const string TARGET_BRIDGE_CONNECTIVITY_UNSTABLE_ERROR = "TargetBridgeConnectivityUnstableError";
        /// <summary>
        /// Error Header Name wenn die Firmware des angesprochenen Geräts nicht mehr aktuell ist
        /// </summary>
        public const string TARGET_FIRMWARE_OUTDATED_ERROR = "TargetFirmwareOutdatedError";
        /// <summary>
        /// Error Header Name wenn die Firmware der Bridge oder des Hubs des angesprochenen Geräts nicht mehr aktuell ist
        /// </summary>
        public const string TARGET_BRIDGE_FIRMWARE_OUTDATED_ERROR = "TargetBridgeFirmwareOutdatedError";
        /// <summary>
        /// Error Header Name wenn das angesprochene Gerät eine Hardware Fehlfunktion hat
        /// </summary>
        public const string TARGET_HARDWARE_MALFUNCTION_ERROR = "TargetHardwareMalfunctionError";
        /// <summary>
        /// Error Header Name wenn der Hub oder die Bridge des angesprochenen Geräts eine Hardware Fehlfunktion hat
        /// </summary>
        public const string TARGET_BRIDGE_HARDWARE_MALFUNCTION_ERROR = "TargetBridgetHardwareMalfunctionError";
        /// <summary>
        /// Error Header Name wenn das Gerät den Wert nicht setzt
        /// </summary>
        public const string UNWILLING_TO_SET_VALUE_ERROR = "UnwillingToSetValueError";
        /// <summary>
        /// Error Header Name wenn das Requestlimit des Gerät erreicht wurde
        /// </summary>
        public const string RATE_LIMIT_EXCEEDED_ERROR = "RateLimitExceededError";
        /// <summary>
        /// Error Header Name wenn die Aktion im aktuellen Modus des Geräts nicht unterstützt wird
        /// </summary>
        public const string NOT_SUPPORTED_IN_CURRENT_MODE_ERROR = "NotSupportedInCurrentModeError";

        /// <summary>
        /// Error Header Name wenn der übergebene Access Token abgelaufen ist
        /// </summary>
        public const string EXSPIRED_ACCESS_TOKEN_ERROR = "ExpiredAccessTokenError";
        /// <summary>
        /// Error Header Name wenn der übergebene Access Token abgelaufen ist
        /// </summary>
        public const string INVALID_ACCESS_TOKEN_ERROR = "InvalidAccessTokenError";
        /// <summary>
        /// Error Header Name wenn das Gerät nicht vom Skill Adapter unterstützt wird
        /// </summary>
        public const string UNSUPPORTED_TARGET_ERROR = "UnsupportedTargetError";
        /// <summary>
        /// Error Header Name wenn die Aktion auf dem Gerät nicht unterstützt wird.
        /// </summary>
        public const string UNSUPPORTED_OPERATION_ERROR = "UnsupportedOperationError";
        /// <summary>
        /// Error Header Name wenn die Option vom Gerät oder der Aktion nicht unterstützt wird
        /// </summary>
        public const string UNSUPPORTED_TARGET_SETTING_ERROR = "UnsupportedTargetSettingError";
        /// <summary>
        /// Error Header Name wenn ein Parameter einen nicht erwarteten Wert besitzt
        /// </summary>
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
            {DECREMENT_PERCENTAGE_REQUEST,"DecrementPercentageConfirmation"},
            {SET_COLOR_REQUEST,"SetColorConfirmation" },
            {SET_COLOR_TEMPERATURE_REQUEST,"SetColorTemperatureConfirmation" },
            {INCREMENT_COLOR_TEMPERATURE_REQUEST,"IncrementColorTemperatureConfirmation" },
            {DECREMENT_COLOR_TEMPERATURE_REQUEST, "DecrementColorTemperatureConfirmation" },
            {GET_TEMPERATURE_READING_REQUEST, "GetTemperatureReadingResponse" },
            { GET_TARGET_TEMPERATURE_REQUEST, "GetTargetTemperatureResponse" }
        };
    }
}
