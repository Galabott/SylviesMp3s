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
        if (u.GetUsername().Trim() != "" || u.GetUsername().Length > 20 || u.GetPassword().Length >= 8)
        {
            var sql = $"INSERT INTO Users (username, password) VALUES('{u.GetUsername()}', '{u.GetPassword()}')";

            if (SylvieRequest.ExecuteCommand(sql)! != null)
                return true;
        }

        return false;
    }

    public static bool Login(User u)
    {
        var sql = $"SELECT * FROM Users WHERE username = '{u.GetUsername()}' AND password = '{u.GetPassword()}'";

        if (SylvieRequest.ExecuteCommand(sql)!.Read())
        {
            CurrentUser = u;
            return true;
        }

        return false;
    }
}