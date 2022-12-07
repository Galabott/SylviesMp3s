using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SylviesMp3s.Models
{
    public class User
    {
        int id;
        string username;
        string password;
        string? email;
        bool is_admin;
        DateTime last_connection;

        //int id = -1;
        //bool is_admin = false;
        //DateTime last_connection = DateTime.Now;
    }
}
