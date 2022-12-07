using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SylviesMp3s.Models
{
    class Playlists : INotifyPropertyChanged
    {
        int id = -1;
        string? artist;
        string? genre;
        string title;
        int? year;
        bool is_public;
        int id_user;
        string? album_cover;

        public event PropertyChangedEventHandler PropertyChanged;

        public Playlists(int _id, string? _artist, string? _genre, string _title, int? _year, bool _is_public, int _id_user, string? _album_cover){
            this.id = _id;
            this.artist = _artist;
            this.genre = _genre;
            this.title = _title;
            this.year = _year;
            this.is_public = _is_public;
            this.id_user = _id_user;
            this.album_cover = _album_cover;
        }
        public Playlists(string? _artist, string? _genre, string _title, int? _year, bool _is_public, int _id_user, string? _album_cover)
        {
            this.artist = _artist;
            this.genre = _genre;
            this.title = _title;
            this.year = _year;
            this.is_public = _is_public;
            this.id_user = _id_user;
            this.album_cover = _album_cover;
        }

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public int Id {
            get => id;
            set
            {
                id = value;
                NotifyPropertyChanged("LastConnection");
            }
        }

        public string? Artist
        {
            get => artist;
            set
            {
                artist = value;
                NotifyPropertyChanged("Artist");
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
        public string Title 
        {
            get => title;
            set
            {
                title = value;
                NotifyPropertyChanged("Title");
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
        public bool IsPublic
        {
            get => is_public;
            set
            {
                is_public = value;
                NotifyPropertyChanged("IsPublic");
            }
        }
        public int IdUser
        {
            get => id_user;
            set
            {
                id_user = value;
                NotifyPropertyChanged("IdUser");
            }
        }
        public string? AlbumCover 
        {
            get => album_cover;
            set
            {
                album_cover = value;
                NotifyPropertyChanged("AlbumCover");
            }
        }
        
        //bool is_public;
        //int id_user;
        //string? album_cover;
    }
}
