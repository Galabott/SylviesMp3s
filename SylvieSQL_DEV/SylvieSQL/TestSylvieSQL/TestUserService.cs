using System.Configuration;
using SylvieSQL;
using SylvieSQL.Users;

namespace TestSylvieSQL;

public class TestUserService
{
    TestUserService()
    {
        SylvieRequest.DbConnect();
    }
    
    [Fact]
    public void TestAddUser()
    {
        User user = new User(1, "a@a.ca", "aaaaaaaa");
        Assert.True(UserService.AddUser(user));
    }
}