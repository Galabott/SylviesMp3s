namespace SylvieSQL.Users;

public class UserService
{
    // Variables //
    private User _currentUser;

    // Constructors //
    public UserService(User currentUser)
    {
        _currentUser = currentUser;
    }
    
    // Functions //
    public bool AddUser(User u)
    {
        var sql = $"INSERT INTO Users VALUES(default, '{u.GetEmail()}', '{u.GetPassword()}', default, null)";
        
        return SylvieRequest.ExecuteCommand(sql).Read();
    }

    public bool Login(User u)
    {
        var sql = $"SELECT * FROM Users WHERE email = '{u.GetEmail()}' && password = '{u.GetPassword()}'";
        
        var reader = SylvieRequest.ExecuteCommand(sql);

        return SylvieRequest.ExecuteCommand(sql).Read();
    }
}