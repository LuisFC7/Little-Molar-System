
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Asn1.X509;

namespace LittleMolarApi.Services;
public class TokenService{
    private readonly string _jwtSecret;
    private readonly List<string> _validTokens;

    public TokenService(string jwtSecret){
        _jwtSecret = jwtSecret;
    }

    public ClaimsPrincipal validateToken(string token){
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSecret);

        try{
            var tokenValidationParameters = new TokenValidationParameters{
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };

        var ClaimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);

        return ClaimsPrincipal;

        }catch(Exception ex){
            Console.WriteLine("Error al validar el token: " + ex.Message);
            throw;
        }
    }

    public void invalidateToken(ClaimsPrincipal userClaim){
        if(userClaim != null){
            var jwt = userClaim.FindFirstValue("jwt");
            _validTokens.Remove(jwt);
        }
    }

// public void invalidateToken(string jwt){
    //     // var jwt = userClaim.FindFirstValue("jwt");
    //     _validTokens.Remove(jwt);
    // }

}