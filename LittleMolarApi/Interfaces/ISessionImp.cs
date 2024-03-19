namespace LittleMolarApi.Interfaces;
public interface ISessionImp{
    Task<bool>authenticateAsync(string username, string password);
    bool verifyPassword(string hashedPassword, string password);
}