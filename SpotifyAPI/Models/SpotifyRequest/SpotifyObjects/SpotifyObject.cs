using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpotifyAPI.Models.SpotifyRequest.SpotifyObjects
{
    public class SpotifyObject
    {
        [JsonProperty("artists")]
        public Artists Artists { get; set; }

    }
}

/*
{
  "artists" : 
  {
    "href" : "https://api.spotify.com/v1/search?query=Radiohead&type=artist&market=FR&offset=0&limit=20",
    "items" : 
    [ 
    {
      "external_urls" : 
      {
        "spotify" : "https://open.spotify.com/artist/4Z8W4fKeB5YxbusRsdQVPb"
      },
      "followers" : 
      {
        "href" : null,
        "total" : 4074750
      },
      "genres" : [ "alternative rock", "art rock", "melancholia", "modern rock", "oxford indie", "permanent wave", "rock" ],
      "href" : "https://api.spotify.com/v1/artists/4Z8W4fKeB5YxbusRsdQVPb",
      "id" : "4Z8W4fKeB5YxbusRsdQVPb",
      "images" : [ {
        "height" : 640,
        "url" : "https://i.scdn.co/image/afcd616e1ef2d2786f47b3b4a8a6aeea24a72adc",
        "width" : 640
      }, {
        "height" : 320,
        "url" : "https://i.scdn.co/image/563754af10b3d9f9f62a3458e699f58c4a02870f",
        "width" : 320
      }, {
        "height" : 160,
        "url" : "https://i.scdn.co/image/4067ea225d8b42fa6951857d3af27dd07d60f3c6",
        "width" : 160
      } ],
      "name" : "Radiohead",
      "popularity" : 80,
      "type" : "artist",
      "uri" : "spotify:artist:4Z8W4fKeB5YxbusRsdQVPb"
    }, {
      "external_urls" : {
        "spotify" : "https://open.spotify.com/artist/0ADkBHZhR2cVfANgK5gHQO"
      },
      "followers" : {
        "href" : null,
        "total" : 348
      },
      "genres" : [ ],
      "href" : "https://api.spotify.com/v1/artists/0ADkBHZhR2cVfANgK5gHQO",
      "id" : "0ADkBHZhR2cVfANgK5gHQO",
      "images" : [ {
        "height" : 624,
        "url" : "https://i.scdn.co/image/6e98957f4910be7ee4c767166ae3a5450c55bad3",
        "width" : 640
      }, {
        "height" : 293,
        "url" : "https://i.scdn.co/image/048879b4ec3226930eac25d67a67c59ec1769e8e",
        "width" : 300
      }, {
        "height" : 62,
        "url" : "https://i.scdn.co/image/b8a80bff1c2b36ea6a21722c70ea7198adce866d",
        "width" : 64
      } ],
      "name" : "Radiohead Tribute Band",
      "popularity" : 6,
      "type" : "artist",
      "uri" : "spotify:artist:0ADkBHZhR2cVfANgK5gHQO"
    } ],
    "limit" : 20,
    "next" : null,
    "offset" : 0,
    "previous" : null,
    "total" : 2
  }
}
*/