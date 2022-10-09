using FlexWallet.Abstractions.Models.Dtos;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FlexWallet.API.Helpers
{
    public static class AuthJwt
    {
        public static (string token, DateTime expiryTime) GenerateABearerToken(IConfiguration _configuration, WalletUserDto walletUserDto)
        {

                string jwt = string.Empty;
                var payLoad = JsonConvert.SerializeObject(walletUserDto);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, ""),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                }; 
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])); 
                 var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
                  token.Payload["user"] = payLoad; 
                jwt = new JwtSecurityTokenHandler().WriteToken(token);
                return (jwt, token.ValidTo);
        }
       

    }
    
}
