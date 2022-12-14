using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SylviesMp3s.Models 
{
    public class Tunes : INotifyPropertyChanged
    {
        int id = -1;
        string title;
        string artist;
        int? length;
        string? genre;
        int? year;
        string? filepath;
        int? id_album;
        int? id_user;

        public event PropertyChangedEventHandler PropertyChanged;


        [JsonConstructor]
        public Tunes(int id, string title, string artist, int? length, string? genre, int? year, string? filepath, int? id_album, int? id_user)
        {
            this.id = id;
            this.title = title;
            this.artist = artist;
            this.length = length;
            this.genre = genre;
            this.year = year;
            this.filepath = filepath;
            this.id_album = id_album;
            this.id_user = id_user;
        }

        public Tunes(string _title, string _artist, int? _length, string? _genre, int? _year, string? _filepath, int? _id_album, int? _id_user)
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

        public string Artist
        {
            get => artist;
            set
            {
                artist = value;
                NotifyPropertyChanged("Artist");
            }
        }
        [JsonInclude]

        public int? Length
        {
            get => length;
            set
            {
                length = value;
                NotifyPropertyChanged("Length");
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
        public string? Filepath
        {
            get => filepath;
            set
            {
                filepath = value;
                NotifyPropertyChanged("Filepath");
            }
        }

        [JsonInclude]
        public int? Id_Album
        {
            get => id_album;
            set
            {
                id_album = value;
                NotifyPropertyChanged("IdAlbum");
            }
        }
        [JsonInclude]
        public int? Id_User
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
