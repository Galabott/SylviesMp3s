using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SylviesMp3s.Models
{
    class Playlists_tunes : INotifyPropertyChanged
    {
        // Plus cote BD, did it just in case

        int id = -1;
        int id_playlist;
        int id_tune;

        public event PropertyChangedEventHandler PropertyChanged;

        [JsonConstructor]
        public Playlists_tunes(int id, int id_playlist, int id_tune)
        {
            this.id = id;
            this.id_playlist = id_playlist;
            this.id_tune = id_tune;
        }
        public Playlists_tunes(int _id_playlist, int _id_tune)
        {
            this.id_playlist = _id_playlist;
            this.id_tune = _id_tune;
        }

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        [JsonInclude]
        public int Id_Tune
        {
            get => id_tune;
            set
            {
                id_tune = value;
                NotifyPropertyChanged("IdTune");
            }
        }
        [JsonInclude]
        public int Id_Playlist
        {
            get => id_playlist;
            set
            {
                id_playlist = value;
                NotifyPropertyChanged("IdPlaylist");
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


    }
}
