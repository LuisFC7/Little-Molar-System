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
    private readonly IConfiguration _configuration;

    public JwtService(IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection("JwtSettings");
        _secretKey = jwtSettings.GetValue<string>("Secret");
        _issuer = jwtSettings.GetValue<string>("Issuer");
        _audience = jwtSettings.GetValue<string>("Audience");
        _configuration = configuration;
    }

    
    public string generateToken(int userId)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        // var keyBytes = Encoding.UTF8.GetBytes(_secretKey);
        var keyBytes = Encoding.UTF8.GetBytes(_secretKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            }),
            Expires = DateTime.UtcNow.AddMinutes(2), // Token válido por dos minutos
            Issuer = _issuer,
            Audience = _audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
        };

        Console.WriteLine("Comprobación de ID: " + userId);
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    

    //DECODIFICADOR JWT

    public int DecodeJwt(string jwtToken){
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtTokenObj = tokenHandler.ReadJwtToken(jwtToken);
        int numberId = 0;

        Console.WriteLine("Header:");
        foreach (var (key, value) in jwtTokenObj.Header)
        {
            Console.WriteLine($"{key}: {value}");
        }

        Console.WriteLine("\nPayload:");
        foreach (var (key, value) in jwtTokenObj.Payload)
        {
            if(key == "nameid"){
                if (int.TryParse(value.ToString(), out int parsedValue))
                    numberId = parsedValue;
                else
                    Console.WriteLine("Failed to parse nameid as an integer.");
        
            }
            Console.WriteLine($"{key}: {value}");
        }
        Console.WriteLine("DECODE INFO");
        Console.WriteLine(numberId);
        return numberId;
    }

    //EXTRACTOR DE INFORMACION
    public int GetUserIdFromToken(string jwtToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtTokenObj = tokenHandler.ReadJwtToken(jwtToken);

        // Buscar la reclamación (claim) que contiene el ID del usuario
        var userIdClaim = jwtTokenObj.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name);

        if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId)){
            // Si se encontró la reclamación y se pudo convertir el valor a entero, retornar el ID del usuario
            return userId;
        }
        else{
            // En caso contrario, lanzar una excepción o retornar un valor predeterminado
            throw new InvalidOperationException("No se pudo encontrar el ID del usuario en el token JWT.");
        }
    }

}
