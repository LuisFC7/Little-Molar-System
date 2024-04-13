using System.Security.Claims;
using LittleMolarApi.Models;

namespace LittleMolarApi.Interfaces;
public interface ISessionImp{
    Task<string>authenticateAsync(string username, string password);
<<<<<<< HEAD
    bool verifyPassword(string hashedPassword, string password);
   
=======
    Task LogoutAsync(string userId);
    bool verifyPassword(string hashedPassword, string password);
    void logOut(string user);

>>>>>>> 50267a9a48adbcf5776542b4e0dabb6d7bd9f507
}