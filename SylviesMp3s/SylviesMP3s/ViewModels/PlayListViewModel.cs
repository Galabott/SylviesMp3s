using SylviesMp3s.Commands;
using SylviesMp3s.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
        private void SaveSong(object nothig) {}
        private void CancelSong(object nothig) { }


        private void DelSong(object nothig)
        {
            if (SelectedSong != null)
            {
                songs.Remove(SelectedSong as Tunes);
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
            int?    _id_album = 0;

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

            /// IMPORTANT -- IMPORTANT -- IMPORTANT -- IMPORTANT -- IMPORTANT -- IMPORTANT -- IMPORTANT -- 
            /// CHANGER A CURRENT USER WHEN DONE
            int? _id_user = -1;


            //int _id, string _title, string _artist, int _length, string _genre, int _year, string _filepath, int _id_album, int _id_user
            Tunes A = new Tunes(_title, _artist, _length, _genre, _year, _filepath, _id_album, _id_user);
            mcvm.SelectedPlaylistSongs.Add(A);
            SelectedSong = A;
        }
    }
}
