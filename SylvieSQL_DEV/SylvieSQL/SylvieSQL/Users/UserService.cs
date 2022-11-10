using System.Data.SqlClient;
using System.Data.SQLite;

namespace SylvieSQL.Users;

public static class UserService
{
    // Variables //
    public static User? CurrentUser;

    // Functions //
    public static bool AddUser(User u)
    {
        if (u.GetEmail().Trim() != "" || u.GetPassword().Length >= 8)
        {
            var sql = $"INSERT INTO Users (email, password) VALUES('{u.GetEmail()}', '{u.GetPassword()}')";

            if (SylvieRequest.ExecuteCommand(sql)! != null)
                return true;
        }

        return false;
    }

    public static bool Login(User u)
    {
        var sql = $"SELECT * FROM Users WHERE email = '{u.GetEmail()}' AND password = '{u.GetPassword()}'";
        
        var reader = SylvieRequest.ExecuteCommand(sql);

        return SylvieRequest.ExecuteCommand(sql)!.Read();
    }
}