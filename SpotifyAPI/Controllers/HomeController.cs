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
        public async Task<ActionResult> Index()
        {
            Token token = await SpotifyConnection.GetToken_Async();

            ViewBag.Token = token;
            return View();
        }

        public async Task<ActionResult> SearchResult()
        {
            string artisteName = Request["ArtistName"];

            if(artisteName != "")
            {
                Token token = await SpotifyConnection.GetToken_Async();
                SpotifyArtist artist = await GetRequest<SpotifyArtist>.ArtistSearchAsync(artisteName, token.Access_token);
                ViewBag.Artists = artist.Artists;
                return View();
            }
            else
            {
                return View("Index");
            }
        }

        public async Task<ActionResult>SearchURI(string uri, string type, string offset, string limit)
        {
            string completUri = uri + "&type=" + type + "&offset=" + offset + "&limit=" + limit;
            Token token = await SpotifyConnection.GetToken_Async();
            SpotifyArtist artist = await GetRequest<SpotifyArtist>.UriSearchAsync(completUri, token.Access_token);
            ViewBag.Artists = artist.Artists;
            return View("SearchResult");
        }

        public async Task<ActionResult> DisplayArtist(string idArtist)
        {
            string completUri = "https://api.spotify.com/v1/artists/" + idArtist + "/albums";

            Token token = await SpotifyConnection.GetToken_Async();
            Artists artist = await GetRequest<Artists>.UriSearchAsync(completUri, token.Access_token);

            Playlist playlist = new Playlist(artist);

            ViewBag.Playlist = playlist;

            return View();
        }
    }
}