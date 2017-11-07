using Newtonsoft.Json;

namespace RKon.Alexa.NET46.JsonObjects
{
    /// <summary>
    /// Resolution for a CameraStream
    /// </summary>
    public class Resolution
    {
        /// <summary>
        /// Describes the width of the video stream.
        /// </summary>
        [JsonProperty("width")]
        public int Width { get; set; }
        /// <summary>
        /// Describes the height of the video stream.
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }

        /// <summary>
        /// Standardconstructor
        /// </summary>
        public Resolution()
        {
        }

        /// <summary>
        /// Initializes Width and Height
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Resolution(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
