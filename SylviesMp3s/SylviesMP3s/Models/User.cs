using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SylviesMp3s.Models
{
    public class User : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        int id = -1;
        string username;
        string password;
        string? email;
        bool is_admin;
        DateTime last_connection;

        public User(int _id, string _username, string _password, string _email, bool _isadmin, DateTime _last_connection) {
            this.id = _id;
            this.username = _username;
            this.password = _password;
            this.email = _email;
            this.is_admin= _isadmin;
            this.last_connection = _last_connection;
        }

        public User(string _username, string _password, string _email, bool _isadmin, DateTime _last_connection)
        {
            this.username = _username;
            this.password = _password;
            this.email = _email;
            this.is_admin = _isadmin;
            this.last_connection = _last_connection;
        }

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public int Id
        {
            get => id;
            set
            {
                id = value;
                NotifyPropertyChanged("Id");
            }
        }

        public string Username
        {
            get => username;
            set
            {
                username = value;
                NotifyPropertyChanged("Username");
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                NotifyPropertyChanged("Password");
            }
        }

        public string Email
        {
            get => email; 
            set
            {
                email = value;
                NotifyPropertyChanged("Email");
            }
        }

        public bool IsAdmin
        {
            get => is_admin; 
            set
            {
                is_admin = value;
                NotifyPropertyChanged("IsAdmin");
            }
        }

        public DateTime LastConnection
        {
            get => last_connection; 
            set
            {
                last_connection = value;
                NotifyPropertyChanged("LastConnection");
            }
        }

        //int id = -1;
        //bool is_admin = false;
        //DateTime last_connection = DateTime.Now;
    }
}
