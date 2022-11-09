﻿using System.Data.SQLite;

namespace SylvieSQL;

public static class SylvieRequest
{
    private static readonly string ConnectionString = "URI=file:" + Path.Combine(Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName ?? "", "database.sqlite");
    private static SQLiteConnection? _con;
    
    private static void DbConnect()
    {
        _con = new SQLiteConnection(ConnectionString);
        _con.Open();
    }
    
    public static SQLiteDataReader ExecuteCommand(string sql)
    {
        DbConnect();
        
        using var cmd = new SQLiteCommand(sql, _con);
        
        var reader = cmd.ExecuteReader();

        return reader;
    }
}