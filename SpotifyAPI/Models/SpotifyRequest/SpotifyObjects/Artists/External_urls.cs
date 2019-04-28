using Newtonsoft.Json;

namespace SpotifyAPI.Models.SpotifyRequest.SpotifyObjects
{
    public class External_urls
    {
        [JsonProperty("spotify")]
        public string Spotify { get; set; }
    }
}