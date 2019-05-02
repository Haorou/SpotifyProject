using System;
using System.Collections.Generic;
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
                                   set { DateExpireToken = DateTime.Now + TimeSpan.FromSeconds(value.Expires_in);
                                         tokenLoaded = value;} }
        public DateTime DateExpireToken { get { return dateExpireToken; } set { dateExpireToken = value; } }



        public async Task<string> GetTokenAccessAsync()
        {
            if(TokenLoaded == null || DateTime.Now >= DateExpireToken)
            {
                this.TokenLoaded = await SpotifyConnection.GetToken_Async();
            }

            return this.TokenLoaded.Access_token;
        }
    }
}