using Newtonsoft.Json;

namespace SpotifyAPI.Models.SpotifyRequest.SpotifyObjects
{
    public class Followers
    {
        [JsonProperty("href")]
        public string Href { get; set; }
        [JsonProperty("total")]
        public int Total { get; set; }
    }
}