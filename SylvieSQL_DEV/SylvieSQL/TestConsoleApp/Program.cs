using SylvieSQL;
using SylvieSQL.Musics;
using SylvieSQL.Users;

SylvieRequest.DbConnect();
User user = new User(0, "Test", "aaaaaaaa");

// Insert test
Console.WriteLine("Test 1 : Insert a user into the database \n");

Console.WriteLine(UserService.AddUser(user) ? "Success" : "Error");


// Login Test
Console.WriteLine("\nTest 2 : Connect a user into the database \n");

Console.WriteLine(UserService.Login(user) ? "Success" : "Error");

Console.WriteLine("\nBonjour " + UserService.CurrentUser!.GetUsername());

// Insert Music Test
Console.WriteLine("\nTest 3 : Insert a music \n");

Music music = new Music(0, "Test", "Testeur", 1,null, null);

Console.WriteLine(MusicService.Insert(music) ? "Success" : "Error");