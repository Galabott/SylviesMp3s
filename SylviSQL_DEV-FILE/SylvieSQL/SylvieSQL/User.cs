namespace SylvieSQL;

public class User
{
    private int id;
    private string email;
    private string password;

    public User()
    {
        id = 0;
    }

    public int GetId() { return id; }
}