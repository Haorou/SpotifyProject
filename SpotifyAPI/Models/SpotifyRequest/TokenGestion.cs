using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SpotifyAPI.Models.SpotifyRequest
{
    public class TokenGestion
    { 
        private Token tokenLoaded = null;
        private DateTime dateExpireToken;
        
        public Token TokenLoaded { get { return tokenLoaded; }
                                   // Thanks to the DateExpireTaken we can save a request to the Spotify API
                                   set { DateExpireToken = DateTime.Now + TimeSpan.FromSeconds(value.Expires_in);
                                         tokenLoaded = value;} }
        public DateTime DateExpireToken { get { return dateExpireToken; } set { dateExpireToken = value; } }


        /// <summary>
        /// Use to get the Token or renew it and return the TokenAccess
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetTokenAccessAsync()
        {
            if(TokenLoaded == null || DateTime.Now >= DateExpireToken)
            {
                Debug.WriteLine(" ============================= On renouvelle le token ======================");
                this.TokenLoaded = await SpotifyConnection.GetToken_Async();
            }

            return this.TokenLoaded.Access_token;
        }
    }
}