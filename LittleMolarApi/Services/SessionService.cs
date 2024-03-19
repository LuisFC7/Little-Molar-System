using System.Security.Cryptography;
using LittleMolarApi.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Security;

public class SessionService : ISessionImp{

    private readonly ApplicationDbContext _context;

    public SessionService(ApplicationDbContext context){
        _context = context;
    }

    public async Task<bool> authenticateAsync(string username, string password){
        var user = await _context.Dentist.FirstOrDefaultAsync(u => u.dentistUser == username || u.dentistEmail == username);
        if(user == null)
            return false;

        if(!verifyPassword(user.dentistPassword, password)){
            return false;
        }

        return true;

        throw new NotImplementedException();


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