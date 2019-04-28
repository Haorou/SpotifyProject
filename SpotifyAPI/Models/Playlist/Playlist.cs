using SpotifyAPI.Models.SpotifyRequest.SpotifyObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpotifyAPI.Models.Playlist
{
    public class Playlist
    {
        public string GroupName { get; set; }
        public List<Album> Albums { get; set; }

        public Playlist(Artists artits)
        {
            this.GroupName = artits.Items[0].Artists[0].Name;
            this.Albums = new List<Album>();
            foreach(Item album in artits.Items)
            {
                this.AddAlbum(new Album(album));
            }
        }

        /// <summary>
        /// Spotify give many albums with the same name and not the same number of tracks
        /// That function add one album with the most important number of tracks in Albums.
        /// </summary>
        /// <param name="album"></param>
        public void AddAlbum(Album album)
        {
            bool isInAlbumsList = false;

            foreach (Album albumLoop in this.Albums)
            {
                if (albumLoop.Name == album.Name)
                {
                    if (albumLoop.Total_tracks < album.Total_tracks)
                    {
                        this.Albums.Remove(albumLoop);
                        this.Albums.Add(album);
                    }
                    isInAlbumsList = true;
                    break;
                }
            }


            if (!isInAlbumsList)
            {
                this.Albums.Add(album);
            }
        }
    }
}