using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        int is_admin;
        DateTime last_connection;

        public User() { }
        public User(int id, string username, string password, string email, int is_admin, DateTime last_connection) {
            this.id =id;
            this.username = username;
            this.password = password;
            this.email = email;
            this.is_admin= is_admin;
            this.last_connection = last_connection;
        }

        public User(string _username, string _password, string _email, int _isadmin, DateTime _last_connection)
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
        [JsonInclude]
        public int Id 
        {
            get => id;
            set
            {
                id = value;
                NotifyPropertyChanged("Id");
            }
        }
        [JsonInclude]
        public string Username
        {
            get => username;
            set
            {
                username = value;
                NotifyPropertyChanged("Username");
            }
        }
        [JsonInclude]
        public string Password
        {
            get => password;
            set
            {
                password = value;
                NotifyPropertyChanged("Password");
            }
        }
        [JsonInclude]
        public string Email
        {
            get => email; 
            set
            {
                email = value;
                NotifyPropertyChanged("Email");
            }
        }
        [JsonInclude]
        public int Is_Admin
        {
            get => is_admin; 
            set
            {
                is_admin = value;
                NotifyPropertyChanged("IsAdmin");
            }
        }
        [JsonInclude]
        public DateTime LastConnection
        {
            get => last_connection; 
            set
            {
                last_connection = value;
                NotifyPropertyChanged("LastConnection");
            }
        }
    }
}
