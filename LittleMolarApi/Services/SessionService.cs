using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using LittleMolarApi.DTO;
using LittleMolarApi.Interfaces;
using LittleMolarApi.Models;
using LittleMolarApi.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Security;

public class SessionService : ISessionImp{

    private readonly ApplicationDbContext _context;
    private readonly string _jwtSecret;

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

        var token = _jwtService.generateToken(user.id);
        // _jwtService.DecodeJwt(token);
        // Console.WriteLine("PRUEBA DE RETURN ID DESDE TOKEN");
        // _jwtService.GetUserIdFromToken(token);

        return token;

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

}