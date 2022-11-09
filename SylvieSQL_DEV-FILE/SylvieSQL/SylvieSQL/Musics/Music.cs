namespace SylvieSQL.Musics;

public class Music
{
    // Variables //
    private readonly int _id;
    private string _title;
    private string _author;
    private readonly int _userId;
    private readonly DateTime _createdAt;
    private readonly DateTime _editedAt;

    // Constructors //
    public Music(int id, string title, string author, int userId, DateTime createdAt, DateTime editedAt)
    {
        _id = id;
        _title = title;
        _author = author;
        _userId = userId;
        _createdAt = createdAt;
        _editedAt = editedAt;
    }
    
    // Set functions //
    public void SetTitle(string title) { _title = title; }
    public void SetAuthor(string author) { _author = author; }
    
    // Get functions //
    public int GetId() { return _id; }
    public string GetTitle() { return _title; }
    public string GetAuthor() { return _author; }
    public int GetUserId() { return _userId; }
    public DateTime GetCreatedAt() { return _createdAt; }
    public DateTime GetEditedAt() { return _editedAt; }
}