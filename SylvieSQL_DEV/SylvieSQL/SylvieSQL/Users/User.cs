using System.Security.Cryptography;
using System.Text;

namespace SylvieSQL.Users;

public class User : IComparable<User>
{
    // Variables //
    private readonly int _id;
    private readonly string _username;
    private readonly string _password;

    // Constructors //
    public User(int id, string username, string password)
    {
        _id = id;
        _username = username;
        _password = Hash(password);
    }

    // Get functions //
    public int GetId() { return _id; }
    public string GetUsername() { return _username; }
    public string GetPassword() { return _password; }

    // CompareTo function //
    public int CompareTo(User? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        var emailComparison = string.Compare(_username, other._username, StringComparison.Ordinal);
        if (emailComparison != 0) return emailComparison;
        return string.Compare(_password, other._password, StringComparison.Ordinal);
    }
    
    // Hash password function //
    private string Hash(string? plainText)
    {
        // Create a SHA256 hash from string   
        using SHA256 sha256Hash = SHA256.Create();
        // Computing Hash - returns here byte array
        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(plainText!));

        // now convert byte array to a string   
        StringBuilder stringBuilder = new StringBuilder();
        foreach (var t in bytes)
        {
            stringBuilder.Append(t.ToString("x2"));
        }
        return stringBuilder.ToString();
    }
}