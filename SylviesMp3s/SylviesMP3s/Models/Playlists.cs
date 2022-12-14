using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SylviesMp3s.Models
{
    public class Playlists : INotifyPropertyChanged
    {
        int id = -1;
        string? artist;
        string? genre;
        string title;
        int? year;
        int is_public;
        int id_user;
        string? album_cover;

        int publicIntToBool;

        public event PropertyChangedEventHandler PropertyChanged;

        [JsonConstructor]
        public Playlists(int id, string? artist, string? genre, string title, int? year, int is_public, int id_user, string? album_cover){
            this.id =           id;
            this.artist =       artist;
            this.genre =        genre;
            this.title =        title;
            this.year =         year;
            this.is_public =    is_public;
            this.id_user =      id_user;
            this.album_cover =  album_cover;
        }
        public Playlists(string? _artist, string? _genre, string _title, int? _year, int _is_public, int _id_user, string? _album_cover)
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

        [JsonInclude]
        public int Id {
            get => id;
            set
            {
                id = value;
                NotifyPropertyChanged("LastConnection");
            }
        }
        [JsonInclude]
        public string? Artist
        {
            get => artist;
            set
            {
                artist = value;
                NotifyPropertyChanged("Artist");
            }
        }
        [JsonInclude]
        public string? Genre
        {
            get => genre;
            set
            {
                genre = value;
                NotifyPropertyChanged("Genre");
            }
        }
        [JsonInclude]
        public string Title 
        {
            get => title;
            set
            {
                title = value;
                NotifyPropertyChanged("Title");
            }
        }
        [JsonInclude]
        public int? Year
        {
            get => year;
            set
            {
                year = value;
                NotifyPropertyChanged("Year");
            }
        }
        [JsonInclude]
        public int Is_Public
        {
            get => is_public;
            set
            {

                is_public = value;
                NotifyPropertyChanged("IsPublic");
            }
        }

        [JsonInclude]
        public int Id_User
        {
            get => id_user;
            set
            {
                id_user = value;
                NotifyPropertyChanged("IdUser");
            }
        }
        [JsonInclude]
        public string? Album_Cover 
        {
            get => album_cover;
            set
            {
                album_cover = value;
                NotifyPropertyChanged("AlbumCover");
            }
        }
    }
}
