using Newtonsoft.Json;
using RKon.Alexa.NET.JsonObjects;

namespace RKon.Alexa.NET.Response
{
    /// <summary>
    /// Returns the URI of a camera feed to display in the Alexa-enabled device. This is sent from the skill adapter to the Smart Home SKill API.
    /// </summary>
    public class RetrieveCameraStreamUriResponsePayload : ResponsePayload
    {
        /// <summary>
        /// The URI to the feed for the camera specified in the request.
        /// The hostname of this URI must be a valid domain that can be verified as a Common Name or Subject Alternative Name in your SSL certificate.
        /// Hostnames that contain IP addresses will be rejected. Required
        /// </summary>
        [JsonRequired]
        [JsonProperty("uri")]
        public URI Uri { get; set; }
        /// <summary>
        /// The URI to a static image from a previous feed of the camera specified in the request.
        /// The hostname of this URI must be a valid domain that can be verified as a Common Name or Subject Alternative Name in your SSL certificate.
        /// Hostnames that contain IP addresses will be rejected. Required
        /// </summary>
        [JsonRequired]
        [JsonProperty("imageUri")]
        public URI ImageUri { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public RetrieveCameraStreamUriResponsePayload()
        {
            Uri = new URI();
            ImageUri = new URI();
        }
    }
}
