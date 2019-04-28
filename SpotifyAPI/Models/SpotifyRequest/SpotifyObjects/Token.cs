using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpotifyAPI.Models.SpotifyRequest
{
    public class Token
    {
        [JsonProperty("access_token")]
        public string Access_token { get; set; }
        [JsonProperty("token_type")]
        public string Token_type { get ; set; }
        [JsonProperty("expires_in")]
        public string Expires_in { get; set; }
        [JsonProperty("refresh_token")]
        public string Refresh_token { get; set; }
        [JsonProperty("scope")]
        public string Scope { get ; set ; }
    }
}