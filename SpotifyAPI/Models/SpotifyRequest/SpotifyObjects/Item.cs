using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpotifyAPI.Models.SpotifyRequest.SpotifyObjects
{
    public class Item
    {
        [JsonProperty("external_urls")]
        public External_urls External_urls { get; set; }
        [JsonProperty("followers")]
        public Followers Followers { get; set; }
        [JsonProperty("genres")]
        public List<string> Genres { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("images")]
        public List<ImageWeb> Images { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("popularity")]
        public string Popularity { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }


        [JsonProperty("artists")]
        public List<Artists> Artists { get; set; }
        [JsonProperty("available_markets")]
        public string[] Available_markets { get; set; }
        [JsonProperty("album_group")]
        public string Album_group { get; set; }
        [JsonProperty("album_type")]
        public string Album_type { get; set; }
        [JsonProperty("release_date")]
        public string Release_date { get; set; }
        [JsonProperty("release_date_precision")]
        public string Release_date_precision { get; set; }
        [JsonProperty("total_tracks")]
        public int Total_tracks { get; set; }
    }
}