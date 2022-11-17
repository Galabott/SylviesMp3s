namespace SylvieSQL.Musics;

public static class MusicService
{
    public static List<Music> SelectAllByUser(int id)
    {
        var sql = $"SELECT * FROM Musics WHERE user_id = {id}";

        var reader = SylvieRequest.ExecuteCommand(sql);

        List<Music> musics = new List<Music>();
        while (reader!.Read())
        {
            Music m = new Music(reader);
            musics.Add(m);
        }
        reader.Close();

        return musics;
    }

    public static bool Insert(Music data)
    {
        var sql = $"INSERT INTO Musics (title, author, user_id) VALUES (" +
                  $"'{data.GetTitle()}', '{data.GetAuthor()}', {data.GetUserId()})";
        
        if (SylvieRequest.ExecuteCommand(sql)! != null)
            return true;

        return false;
    }

    public static bool Delete(int id)
    {
        var sql = $"DELETE FROM Musics WHERE id = {id}";
        
        if (SylvieRequest.ExecuteCommand(sql)! != null)
            return true;

        return false;
    }
}