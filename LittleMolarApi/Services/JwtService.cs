using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

public class JwtService
{
    private readonly string _secretKey;
    private readonly string _issuer;
    private readonly string _audience;

    public JwtService(IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection("JwtSettings");
        _secretKey = jwtSettings.GetValue<string>("Secret");
        _issuer = jwtSettings.GetValue<string>("Issuer");
        _audience = jwtSettings.GetValue<string>("Audience");
    }

    public string generateToken(int userId){

        var randomBytes = new byte[32]; // 128 bits
        var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomBytes);
        var secretKey = Convert.ToBase64String(randomBytes);

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(secretKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, userId.ToString())
            }),
            Expires = DateTime.UtcNow.AddMinutes(2),
            Issuer = _issuer,
            Audience = _audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
