
public class DatabaseService
{
    public void Authenticate(string username, string password)
    {
        Console.WriteLine($"Authenticating user {username} with password {password}");
    }
}

public class LoginViewModel
{
    private readonly DatabaseService _db = new DatabaseService();
    public string Username { get; set; }
    public string Password { get; set; }

    public void Login()
    {
        _db.Authenticate(Username, Password);
    }
}