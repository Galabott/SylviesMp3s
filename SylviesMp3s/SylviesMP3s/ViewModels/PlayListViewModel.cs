using SylviesMp3s.Commands;
using SylviesMp3s.Models;
using SylviesMp3s.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace SylviesMp3s.ViewModels
{
    class PlayListViewModel : BaseViewModel
    {
        private Tunes _selectedSong;

        private ObservableCollection<Tunes> songs = new ObservableCollection<Tunes>();

        public RelayCommand AddTunesCommand { get; private set; }
        public RelayCommand DelTunesCommand { get; private set; }
        public RelayCommand UpdateTunesCommand { get; private set; }
        public RelayCommand SaveTunesCommand { get; private set; }
        public RelayCommand CancelTunesCommand { get; private set; }

        public ObservableCollection<Tunes> Songs
        {
            get => mcvm.SelectedPlaylistSongs;

            set
            {
                songs = value;
                OnPropertyChanged();
            }
        }

        public Tunes SelectedSong
        {
            get => _selectedSong;
            set
            {
                _selectedSong = value;
                OnPropertyChanged("SelectedSong");
            }

        }
        public MainContentViewModel mcvm { get; set; }

        public PlayListViewModel()
        {

            AddTunesCommand = new RelayCommand(AddSong);
            DelTunesCommand = new RelayCommand(DelSong);
            UpdateTunesCommand = new RelayCommand(UpdateSong);
            SaveTunesCommand = new RelayCommand(SaveSong);
            CancelTunesCommand = new RelayCommand(CancelSong);

            //Products = (ObservableCollection<Produit>)_db.Produits;
        }
        public PlayListViewModel(MainContentViewModel mcvm )
        {
            this.mcvm = mcvm;
            AddTunesCommand = new RelayCommand(AddSong);
            DelTunesCommand = new RelayCommand(DelSong);
            UpdateTunesCommand = new RelayCommand(UpdateSong);
            SaveTunesCommand = new RelayCommand(SaveSong);
            CancelTunesCommand = new RelayCommand(CancelSong);

            //Products = (ObservableCollection<Produit>)_db.Produits;
        }

        private void UpdateSong(object nothig) {

        }
        private void SaveSong(object nothig) {
            if (SelectedSong != null)
            {
                JsonObject song = new JsonObject();
                song.Add("songid", SelectedSong.Id);
                song.Add("artist", SelectedSong.Artist);
                song.Add("genre", SelectedSong.Genre);
                song.Add("title", SelectedSong.Title);
                song.Add("year", SelectedSong.Year);
                song.Add("length", SelectedSong.Length);
                song.Add("id_user", mcvm.CurrentUserID);

                mcvm.SaveSongAsync(song);
            }
        }
        private void CancelSong(object nothig) { }


        private void DelSong(object nothig)
        {
            if (SelectedSong != null)
            {
                JsonObject song = new JsonObject();
                song.Add("userid", mcvm.CurrentUserID);
                song.Add("songid", SelectedSong.Id);
                mcvm.DelSong(song);
            }
        }

        private void AddSong(object nothig)
        {
            //ADD PLAYLISTS_TUNES

            string  _artist = "";
            int?     _length = 0;
            string? _genre = "";
            int?     _year = 0;
            string? _filepath = "";
            int?    _id_album = -1;

            string _title = "My Song #";

            int i = 1;
            bool goodName = false;

            while (!goodName)
            {
                Tunes compareTo;
                try
                {
                    compareTo = Songs.Where(x => x.Title == _title + i).First();
                    i++;
                }
                catch
                {
                    goodName = true;
                    _title += i;
                }
            }

            //int _id, string _title, string _artist, int _length, string _genre, int _year, string _filepath, int _id_album, int _id_user
            JsonObject song = new JsonObject();
            song.Add("artist", _artist);
            song.Add("genre", _genre);
            song.Add("title", _title);
            song.Add("year", _year);
            song.Add("length", _length);
            song.Add("id_user", mcvm.CurrentUserID);
            song.Add("id_album", _id_album);
            song.Add("id_playlist", mcvm.currentPlayListId);

            if (_id_album == -1)
            {
                mcvm.AddSong(song);
            }
        }
    }
}
