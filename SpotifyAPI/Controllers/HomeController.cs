using System.Web.Mvc;
using SpotifyAPI.Models;
using SpotifyAPI.Models.SpotifyRequest;
using SpotifyAPI.Models.SpotifyRequest.SpotifyObjects;
using System.Threading.Tasks;

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
                SpotifyObject artist = await GetRequest<SpotifyObject>.ArtistSearchAsync(artisteName, token.Access_token);
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
            SpotifyObject artist = await GetRequest<SpotifyObject>.UriSearchAsync(completUri, token.Access_token);
            ViewBag.Artists = artist.Artists;
            return View("SearchResult");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}