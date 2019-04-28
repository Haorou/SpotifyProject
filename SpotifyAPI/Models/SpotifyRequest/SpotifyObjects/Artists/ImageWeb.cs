using Newtonsoft.Json;

namespace SpotifyAPI.Models.SpotifyRequest.SpotifyObjects
{
    public class ImageWeb
    {
        [JsonProperty("height")]
        public string Height { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("width")]
        public string Width { get; set; }
    }
}