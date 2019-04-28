using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpotifyAPI.Models.SpotifyRequest.SpotifyObjects
{
    public class Artists
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
        [JsonProperty("href")]
        public string Href { get; set; }
        [JsonProperty("external_urls")]
        public External_urls External_urls { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }
        [JsonProperty("limit")]
        public int Limit { get; set; }
        [JsonProperty("next")]
        public string Next { get; set; }
        [JsonProperty("offset")]
        public string Offset { get; set; }
        [JsonProperty("previous")]
        public string Previous { get; set; }
        [JsonProperty("total")]
        public int Total { get; set; }
    }
}