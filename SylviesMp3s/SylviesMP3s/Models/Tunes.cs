using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SylviesMp3s.Models 
{
    class Tunes : INotifyPropertyChanged
    {
        int id;
        string title;
        string artist;
        int? length;
        string? genre;
        int? year;
        string? filepath;
        int? id_album;
        int? id_user;

        public event PropertyChangedEventHandler PropertyChanged;

        public Tunes(int _id, string _title, string _artist, int _length, string _genre, int _year, string _filepath, int _id_album, int _id_user)
        {
            this.id = _id;
            this.title = _title;
            this.artist = _artist;
            this.length = _length;
            this.genre = _genre;
            this.year = _year;
            this.filepath = _filepath;
            this.id_album = _id_album;
            this.id_user = _id_user;
        }

        public Tunes(string _title, string _artist, int _length, string _genre, int _year, string _filepath, int _id_album, int _id_user)
        {
            this.title = _title;
            this.artist = _artist;
            this.length = _length;
            this.genre = _genre;
            this.year = _year;
            this.filepath = _filepath;
            this.id_album = _id_album;
            this.id_user = _id_user;
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

        public string Title
        {
            get => title;
            set
            {
                title = value;
                NotifyPropertyChanged("Title");
            }

        }
        public string Artist
        {
            get => artist;
            set
            {
                artist = value;
                NotifyPropertyChanged("Artist");
            }
        }
        public int? Length
        {
            get => length;
            set
            {
                length = value;
                NotifyPropertyChanged("Length");
            }
        }
        public string? Genre
        {
            get => genre; 
            set
            {
                genre = value;
                NotifyPropertyChanged("Genre");
            }
        }
        public int? Year
        {
            get => year;
            set
            {
                year = value;
                NotifyPropertyChanged("Year");
            }
        }
        public string? Filepath
        {
            get => filepath;
            set
            {
                filepath = value;
                NotifyPropertyChanged("Filepath");
            }
        }

        public int? IdAlbum
        {
            get => id_album;
            set
            {
                id_album = value;
                NotifyPropertyChanged("IdAlbum");
            }
        }
        public int? IdUser
        {
            get => id_user; 
            set
            {
                id_user = value;
                NotifyPropertyChanged("IdUser");
            }

        }
    }
}
