using SylvieSQL;
using SylvieSQL.Users;

SylvieRequest.DbConnect();
User user = new User(0, "e@e", "aaaaaaaa");

// Insert test
Console.WriteLine("Test 1 : Insert a user into the database \n");

Console.WriteLine(UserService.AddUser(user) ? "Success" : "Error");


// Login Test
Console.WriteLine("\nTest 2 : Connect a user into the database \n");

Console.WriteLine(UserService.Login(user) ? "Success" : "Error");