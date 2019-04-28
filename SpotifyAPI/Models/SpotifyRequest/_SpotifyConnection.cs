using Newtonsoft.Json;
using SpotifyAPI.Models.SpotifyRequest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAPI.Models
{
    public class SpotifyConnection
    {
        private static readonly HttpClient client = new HttpClient();
        private const string clientID = "278ff94f89bc4ec390d5a6ce9036dc7f";
        private const string clientSecret = "e8d6b297dd814840bfa75f9a9f6e263c";
        private const string redirectURI = "http://localhost:63353/Home/AuthAsync";

        /// <summary>
        /// Create the correct URL to make valide POST request with an Authorisation Code.
        /// 
        /// It's easier to use reponse_type=token but according to the Authorization Guide from Sportify, you have more freedom with the Authorization Code.
        /// </summary>
        /// <returns>string : URL use to obtain Authorisation Code</returns>
        public static string GetSpotifyAuthCodeUri(params string[] scopes)
        {
            string url = "https://accounts.spotify.com/authorize?" +
            "response_type=code" +
            "&client_id=" + clientID +
            "&redirect_uri=" + redirectURI +
            "&show_dialogue=true";

            int scopeSize = scopes.Length;
            if (scopeSize > 0)
            {
                url += "&scope=";

                for (int loopPosition = 0; loopPosition < scopeSize; loopPosition++)
                {
                    url += scopes[loopPosition];
                    if (loopPosition < scopeSize)
                        url += "%20";
                }
            }
            return url;
        }


        public static async Task<Token> GetTokenWithAuthCode_Async(string code)
        {
            Dictionary<string, string> values = new Dictionary<string, string>
            {
                { "grant_type", "authorization_code" },
                { "code", code },
                { "redirect_uri", redirectURI },
                { "client_id", clientID },
                { "client_secret", clientSecret }
            };

            FormUrlEncodedContent content = new FormUrlEncodedContent(values);

            HttpResponseMessage response = await client.PostAsync("https://accounts.spotify.com/api/token/", content);

            string s_response = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Token>(s_response);
        }

        public static async Task<Token> GetToken_Async()
        {
            Token token = new Token();
            string postString = string.Format("grant_type=client_credentials");

            byte[] byteArray = Encoding.UTF8.GetBytes(postString);
            string url = "https://accounts.spotify.com/api/token";

            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.Headers.Add("Authorization", "Basic " + EncodeCredentials());
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
                using (WebResponse response = await request.GetResponseAsync())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            string responseFromServer = reader.ReadToEnd();
                            token = JsonConvert.DeserializeObject<Token>(responseFromServer);
                        }
                    }
                }
            }

            return token;
        }

        static public string EncodeCredentials()
        {
            byte[] toEncodeAsBytes = Encoding.UTF8.GetBytes(clientID + ":" +clientSecret);
            string returnValue =Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }
    }
    
}