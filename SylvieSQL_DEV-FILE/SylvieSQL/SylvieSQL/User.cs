namespace SylvieSQL;

public class User : IComparable<User>
{
    // Variables //
    private readonly int _id;
    private readonly string _email;
    private readonly string _password;

    // Constructors //
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

    // Compare to function //
    public int CompareTo(User? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        var emailComparison = string.Compare(_email, other._email, StringComparison.Ordinal);
        if (emailComparison != 0) return emailComparison;
        return string.Compare(_password, other._password, StringComparison.Ordinal);
    }
}