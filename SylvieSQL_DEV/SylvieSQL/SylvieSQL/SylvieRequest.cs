using System.Data.SqlClient;
using System.Data.SQLite;

namespace SylvieSQL;

public static class SylvieRequest
{
    private static readonly string ConnectionString = "URI=file:" +
        Path.Combine (
            Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.Parent?.FullName ?? "", 
            "database.sqlite"
        );
    
    private static SQLiteConnection? _con;
    
    public static void DbConnect()
    {
        _con = new SQLiteConnection(ConnectionString);
        _con.Open();
    }
    
    public static SQLiteDataReader? ExecuteCommand(string sql)
    {
        using var cmd = new SQLiteCommand(sql, _con);
        SQLiteDataReader? reader = null;

        try
        {
            reader = cmd.ExecuteReader();
        }
        catch(SQLiteException)
        {
            return reader;
        }

        return reader;
    }
}