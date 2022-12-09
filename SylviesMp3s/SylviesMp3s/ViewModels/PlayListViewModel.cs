using SylviesMp3s.Commands;
using SylviesMp3s.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            get => songs;

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

        public PlayListViewModel()
        {

            AddTunesCommand = new RelayCommand(AddSong);
            DelTunesCommand = new RelayCommand(DelSong);
            UpdateTunesCommand = new RelayCommand(UpdateSong);
            SaveTunesCommand = new RelayCommand(SaveSong);
            CancelTunesCommand = new RelayCommand(CancelSong);

            //Products = (ObservableCollection<Produit>)_db.Produits;
        }

        private void UpdateSong(object nothig) {}
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
            string? _artist = null;
            string? _genre = null;
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


            int? _year = 2022;
            bool _is_public = true;
            string? _album_cover = null;

            /// IMPORTANT -- IMPORTANT -- IMPORTANT -- IMPORTANT -- IMPORTANT -- IMPORTANT -- IMPORTANT -- 
            /// CHANGER A CURRENT USER WHEN DONE
            int _id_user = -1;

            //Tunes A = new Tunes(_artist, _genre, _title, _year, _is_public, _id_user, _album_cover);
            //songs.Add(A);
            //SelectedSong = A;
        }
    }
}
