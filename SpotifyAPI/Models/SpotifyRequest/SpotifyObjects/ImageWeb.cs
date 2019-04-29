using Newtonsoft.Json;

namespace SpotifyAPI.Models.SpotifyRequest.SpotifyObjects
{
    public class ImageWeb
    {
        [JsonProperty("height")]
        public int Height { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("width")]
        public int Width { get; set; }
    }
}