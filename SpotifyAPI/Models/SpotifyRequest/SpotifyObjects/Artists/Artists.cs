using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpotifyAPI.Models.SpotifyRequest.SpotifyObjects
{
    public class Artists
    {
        [JsonProperty("href")]
        public string Href { get; set; }
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