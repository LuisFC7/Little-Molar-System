<<<<<<< HEAD
=======
using System.Configuration;
>>>>>>> 50267a9a48adbcf5776542b4e0dabb6d7bd9f507
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
<<<<<<< HEAD
using LittleMolarApi.DTO;
=======
>>>>>>> 50267a9a48adbcf5776542b4e0dabb6d7bd9f507
using LittleMolarApi.Interfaces;
using LittleMolarApi.Models;
using LittleMolarApi.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
=======
using Microsoft.Identity.Client;
>>>>>>> 50267a9a48adbcf5776542b4e0dabb6d7bd9f507
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Security;

public class SessionService : ISessionImp{

    private readonly ApplicationDbContext _context;
    private readonly TokenService _tokenService;
    private readonly string _jwtSecret;

<<<<<<< HEAD
    private readonly JwtService _jwtService;

    public SessionService(ApplicationDbContext context, JwtService jwtService){
        _context = context;
        _jwtService = jwtService;

    }

    public async Task<string> authenticateAsync(string username, string password){
        var user = await _context.Dentist.FirstOrDefaultAsync(u => u.dentistUser == username || u.dentistEmail == username);
        if(user == null){
            Console.WriteLine("Entro aqui en  user null");
            Console.WriteLine(user);
            return null;
        }

        if(!verifyPassword(password, user.dentistPassword)){
            Console.WriteLine("Entro aqui en passwordnull");
            return null;
        }

        var token = _jwtService.generateToken(user.dentistId);

        return token;

=======
    public SessionService(ApplicationDbContext context, TokenService tokenService, IConfiguration configuration){
        _context = context;
        // _jwtSecret = jwtSecret;
        _tokenService = tokenService;
        _jwtSecret =  configuration["JwtSecret"];
    }


    public async Task<string> authenticateAsync(string username, string password){
        var user = await _context.Dentist.FirstOrDefaultAsync(u => u.dentistUser == username || u.dentistEmail == username);
        if(user == null)
            return "El usuario o email es erroneo";

        if(!verifyPassword(password, user.dentistPassword)){
            return "La contraseña es erronea";
        }

        var token = GenerateJwtToken(user);
        if(token == null)
            return null;

        var data = _tokenService.validateToken(token);
        if(data == null)
            return null;

        var userIdClaim = data.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name");
        var id = "";

        if (userIdClaim != null){
            id = userIdClaim.Value;
        }
        else{
            return null;
        }

        var message = id.ToString() +"/"+ token;
        return message;
    }

    private string GenerateJwtToken(Dentist user){

        try{
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.id.ToString())
                    // Aquí puedes agregar más reclamaciones según necesites
                }),
                Expires = DateTime.UtcNow.AddMinutes(15), // Tiempo de expiración del token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }catch{
            return null;
        }
    }

    public async Task LogoutAsync(string userId)
    {
        throw new NotImplementedException();
>>>>>>> 50267a9a48adbcf5776542b4e0dabb6d7bd9f507
    }

    public bool verifyPassword(string password, string hashedPassword){
        byte[] hashBytes = Convert.FromBase64String(hashedPassword);

        byte[] salt = new byte[16];
        Array.Copy(hashBytes, 0, salt, 0, 16);

        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
        byte[] hash = pbkdf2.GetBytes(20);

        for (int i = 0; i < 20; i++){
            if (hashBytes[i + 16] != hash[i])
                return false;           
        }

        return true;
    }

<<<<<<< HEAD
=======
    public void logOut(string user){
        // var data = _tokenService.validateToken(user);
        // _tokenService.invalidateToken(data);
        _tokenService.invalidateTokenAsync(user);
    }

>>>>>>> 50267a9a48adbcf5776542b4e0dabb6d7bd9f507
}