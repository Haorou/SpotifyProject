using System.Web.Mvc;
using SpotifyAPI.Models;
using SpotifyAPI.Models.SpotifyRequest;
using SpotifyAPI.Models.SpotifyRequest.SpotifyObjects;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Generic;
using SpotifyAPI.Models.Playlist;

namespace SpotifyAPI.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Start the app. with the TopTen artist.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            ViewBag.Access_token = await GetAccessTokenAsync();
            SpotifyArtist artist = await GetRequest<SpotifyArtist>.TopArtistSearchAsync(ViewBag.Access_token);
            ViewBag.Artists = artist.Artists;

            return View();
        }

        /// <summary>
        /// Find a list of artists according to the given artist name
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> SearchResult()
        {
            string artisteName = Request["ArtistName"];

            if(artisteName != "" && artisteName != null)
            {
                SpotifyArtist artist = await GetRequest<SpotifyArtist>.ArtistSearchNameAsync(artisteName, await GetAccessTokenAsync());
                ViewBag.Artists = artist.Artists;
                return View();
            }
            else
            {
                return await Index();
            }
        }

        /// <summary>
        /// Use to change page when you have more than 20 artists
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="type"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public async Task<ActionResult>SearchURI(string uri, string type, string offset, string limit)
        {
            if(uri != "" && type != "" && offset != "" && limit != "")
            {
                string completUri = uri + "&type=" + type + "&offset=" + offset + "&limit=" + limit;

                SpotifyArtist artist = await GetRequest<SpotifyArtist>.UriSearchAsync(completUri, await GetAccessTokenAsync());
                ViewBag.Artists = artist.Artists;
                return View("SearchResult");
            }
            else
            {
                return await Index();
            }
        }

        /// <summary>
        /// Use to found an artists thanks to his Spotify's Id.
        /// </summary>
        /// <param name="idArtist"></param>
        /// <returns></returns>
        public async Task<ActionResult> DisplayArtist(string idArtist)
        {
            string completUri = "https://api.spotify.com/v1/artists/" + idArtist + "/albums";

            Artists artist = await GetRequest<Artists>.UriSearchAsync(completUri, await GetAccessTokenAsync());

            Playlist playlist = new Playlist(artist);

            ViewBag.Playlist = playlist;

            return View();
        }

        /// <summary>
        /// Use to get the token to make some request
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetAccessTokenAsync()
        {
            if (Session["TokenGestion"] == null)
            {
                Session["TokenGestion"] = new TokenGestion();
            }
            TokenGestion TokenGestion = (TokenGestion)Session["TokenGestion"];

            return await TokenGestion.GetTokenAccessAsync();
        }

    }
}