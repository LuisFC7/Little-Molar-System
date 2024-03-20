using System.Security.Claims;
using LittleMolarApi.Models;

namespace LittleMolarApi.Interfaces;
public interface ISessionImp{
    Task<string>authenticateAsync(string username, string password);
    Task LogoutAsync(string userId);
    bool verifyPassword(string hashedPassword, string password);
    void logOut(string user);

}