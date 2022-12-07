using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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

        public Playlists_tunes(int _id, int _id_playlist, int _id_tune)
        {
            this.id = _id;
            this.id_playlist = _id_playlist;
            this.id_tune = _id_tune;
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

        public int IdTune
        {
            get => id_tune;
            set
            {
                id_tune = value;
                NotifyPropertyChanged("IdTune");
            }
        }
        public int IdPlaylist
        {
            get => id_playlist;
            set
            {
                id_playlist = value;
                NotifyPropertyChanged("IdPlaylist");
            }
        }
        public int Id
        {
            get => id;
            set
            {
                id = value;
                NotifyPropertyChanged("LastConnection");
            }
        }


    }
}
