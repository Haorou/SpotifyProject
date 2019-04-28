using System.Web.Mvc;
using SpotifyAPI.Models;
using SpotifyAPI.Models.SpotifyRequest;
using SpotifyAPI.Models.SpotifyRequest.SpotifyObjects;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SpotifyAPI.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
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
            ViewBag.Artist = artist; 
            
            return View();
        }
    }
}