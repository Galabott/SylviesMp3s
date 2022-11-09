namespace SylvieSQL;

public class User
{
    // Variables //
    private readonly int _id;
    private readonly string _email;
    private readonly string _password;

    // Constructors //
    public User()
    {
        _id = 0;
        _email = "";
        _password = "";
    }

    public User(int id, string email, string password)
    {
        _id = id;
        _email = email;
        _password = password;
    }

    // Get functions //
    public int GetId() { return _id; }
    public string GetEmail() { return _email; }
    public string GetPassword() { return _password; }
}