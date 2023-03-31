using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using AuthServer.Core.Configuration;
using AuthServer.Core.DTOs;
using AuthServer.Core.Models;
using AuthServer.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using SharedLibrary.Configurations;

namespace AuthServer.Service.Services
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly CustomTokenOption _customToken;

        public TokenService(UserManager<UserApp> userManager, IOptions<CustomTokenOption> customToken)
        {
            _userManager = userManager;
            _customToken = customToken.Value;
        }

        private string CreateRefreshToken()
        {
            var numberByte = new byte[3];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(numberByte);
            return Convert.ToBase64String(numberByte);
        }

        private IEnumerable<Claim> GetClaim(UserApp userApp, IEnumerable<string> audience)
        {
            var userList = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, userApp.Id),
                new(JwtRegisteredClaimNames.Email, userApp.Id),
                new(ClaimTypes.Name, userApp.UserName),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            if (userList == null) throw new ArgumentNullException(nameof(userList))
            {
                HelpLink = "https://github.com/SametUCA?tab=repositories",
                HResult = 0,
                Source = "Token Service"
            };
            
            userList.AddRange(audience.Select(x=> new Claim(JwtRegisteredClaimNames.Aud, x)));
            return userList;
        }

        public TokenDto CreateToken(UserApp userApp)
        {
            throw new NotImplementedException();
        }

        public ClientTokenDto CreateTokenByClient(Client client)
        {
            throw new NotImplementedException();
        }
    }
}