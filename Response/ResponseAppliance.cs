using Newtonsoft.Json;
using RKon.Alexa.NET.Types;
using System.Collections.Generic;


namespace RKon.Alexa.NET.Response
{
    /// <summary>
    /// Gerät, das per Response geschickt wird
    /// </summary>
    public class ResponseAppliance
    {
        /// <summary>
        /// GeräteID
        /// </summary>
        [JsonProperty("applianceId")]
        [JsonRequired]
        public string ApplianceID { get; set; }
        /// <summary>
        /// Hersteller
        /// </summary>
        [JsonProperty("manufacturerName")]
        [JsonRequired]
        public string ManufacturerName { get; set; }
        /// <summary>
        /// Modell
        /// </summary>
        [JsonProperty("modelName")]
        [JsonRequired]
        public string ModelName { get; set; }
        /// <summary>
        /// Version
        /// </summary>
        [JsonProperty("version")]
        [JsonRequired]
        public string Version { get; set; }
        /// <summary>
        /// Name des Geräts, der vom Nutzer verwendet wird um das Gerät zu identifizieren
        /// </summary>
        [JsonProperty("friendlyName")]
        [JsonRequired]
        public string FriendlyName { get; set; }
        /// <summary>
        /// Beschreibung in 128 Zeichen
        /// </summary>
        [JsonProperty("friendlyDescription")]
        [JsonRequired]
        public string FriendlyDescription { get; set; }
        /// <summary>
        /// Gibt an, ob das Gerät erreichbar ist
        /// </summary>
        [JsonProperty("isReachable")]
        [JsonRequired]
        public bool IsReachable { get; set; }
        /// <summary>
        /// Aktionen, die durchgeführt werden können
        /// </summary>
        [JsonProperty("actions")]
        [JsonRequired]
        public List<string> Actions { get; set; }
        /// <summary>
        /// Zusätzliche Details
        /// </summary>
        [JsonProperty("additionalApplianceDetails")]
        public Dictionary<string,object> AdditionalApplianceDetails { get; private set; }

        /// <summary>
        /// Erstellt Gerät an Hand der übergebenen Werte. Aktionen müssen manuell gesetzt werden.
        /// </summary>
        /// <param name="id">GeräteId</param>
        /// <param name="manufacturerName">Hersteller</param>
        /// <param name="modelName">Modell</param>
        /// <param name="version">Version</param>
        /// <param name="friendlyName">Name des Geräts, der vom Nutzer verwendet wird um das Gerät zu identifizieren</param>
        /// <param name="friendlyDescription">Beschreibung in 128 Zeichen</param>
        /// <param name="isReachable">Gibt an, ob das Gerät erreichbar ist</param>
        public ResponseAppliance(string id, string manufacturerName, string modelName, string version, string friendlyName, string friendlyDescription, bool isReachable)
        {
            AdditionalApplianceDetails = new Dictionary<string, object>();
            ApplianceID = id;
            ManufacturerName = manufacturerName;
            ModelName = modelName;
            Version = version;
            FriendlyName = friendlyName;
            FriendlyDescription = friendlyDescription;
            IsReachable = isReachable;
            Actions = new List<string>();
        }

        /// <summary>
        /// Versucht einen Action hinzuzufügen. Gültige Actions finden Sie im Namespace RKon.Alexa.NET.Types.ApplianceActions
        /// </summary>
        /// <param name="action">Action die hinzugefügt werden soll</param>
        /// <returns>True, wenn Wert hinzugefügt wurde</returns>
        public bool TryAddAction(string action)
        {
            if (ApplianceActions.Actions.Contains(action))
            {
                Actions.Add(action);
                return true;
            }
            return false;
        }
    }
}
