using System.Security.Claims;
using LittleMolarApi.Models;

namespace LittleMolarApi.Interfaces;
public interface ISessionImp{
    Task<string>authenticateAsync(string username, string password);
    bool verifyPassword(string hashedPassword, string password);
   
}