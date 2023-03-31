using System.Collections.Generic;

namespace SharedLibrary.Configurations
{
    public class CustomTokenOption
    {
        public List<string> Audience { get; set; } // List of audience for token
        public string Issuer { get; set; } // Issuer of token
        public int AccessTokenExpiration { get; set; } // Access token expiration time 
        public int RefreshTokenExpiration { get; set; } // Refresh token expiration time 
        public string SecurityKey { get; set; } // Security key for signing credentials
    }
}