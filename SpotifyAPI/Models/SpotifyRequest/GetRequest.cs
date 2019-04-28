using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace SpotifyAPI.Models.SpotifyRequest
{
    public class GetRequest<T>
    {
        public static async Task<T> ArtistSearchAsync(string artistName, string access_token)
        {
            string url = "https://api.spotify.com/v1/search?" +
                        "q=" + artistName +
                        "&type=" + "artist";

            try
            {
                WebRequest request = WebRequest.Create(url);
                request.Method = "GET";
                request.Headers.Add("Authorization", "Bearer " + access_token);
                request.ContentType = "application/json; charset=utf-8";
                T type = default(T);

                using (WebResponse response = await request.GetResponseAsync())
                {
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(dataStream))
                        {
                            string responseFromServer = reader.ReadToEnd();
                            System.Diagnostics.Debug.WriteLine(responseFromServer);
                            type = JsonConvert.DeserializeObject<T>(responseFromServer);
                        }
                    }
                }

                return type;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error", ex);
                throw;
            }
        }

        public static async Task<T> UriSearchAsync(string uri, string access_token)
        {
            try
            {
                WebRequest request = WebRequest.Create(uri);
                request.Method = "GET";
                request.Headers.Add("Authorization", "Bearer " + access_token);
                request.ContentType = "application/json; charset=utf-8";
                T type = default(T);

                using (WebResponse response = await request.GetResponseAsync())
                {
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(dataStream))
                        {
                            string responseFromServer = reader.ReadToEnd();
                            System.Diagnostics.Debug.WriteLine(responseFromServer);
                            type = JsonConvert.DeserializeObject<T>(responseFromServer);
                        }
                    }
                }

                return type;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error", ex);
                throw;
            }
        }
    }
}