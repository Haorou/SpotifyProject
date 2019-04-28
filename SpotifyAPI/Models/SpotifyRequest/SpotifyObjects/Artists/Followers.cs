using Newtonsoft.Json;

namespace SpotifyAPI.Models.SpotifyRequest.SpotifyObjects
{
    public class Followers
    {
        [JsonProperty("href")]
        public string Href { get; set; }
        [JsonProperty("total")]
        public string Total { get; set; }
    }
}