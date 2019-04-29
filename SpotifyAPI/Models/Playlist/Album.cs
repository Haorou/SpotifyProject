using SpotifyAPI.Models.SpotifyRequest.SpotifyObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpotifyAPI.Models.Playlist
{
    public class Album
    {
        public string Name { get; set; }
        public string Image_url { get; set; }
        public int Image_height { get; set; }
        public int Image_width { get; set; }
        public string Release_date { get; set; }
        public string Album_type { get; set; }
        public int Total_tracks { get; set; }
        public string Id { get; set; } 
        public Album(Item album)
        {
            this.Name = album.Name;
            this.Image_url = album.Images[0].Url;
            this.Image_height = album.Images[0].Height;
            this.Image_width = album.Images[0].Width;
            this.Release_date = album.Release_date; 
            this.Album_type = album.Album_type;
            this.Total_tracks = album.Total_tracks;
            this.Id = album.Id;
        }
    }
}