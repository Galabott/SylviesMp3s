using SylviesMp3s.Commands;
using SylviesMp3s.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SylviesMp3s.ViewModels
{
    internal class PublicPlaylistViewModel : BaseViewModel
    {
        //private ProduitDataService _db = new ProduitDataService();

        private Playlists _selectedPlaylist;

        private ObservableCollection<Playlists> pplaylists = new ObservableCollection<Playlists>();

        public RelayCommand AddPlaylistCommand { get; private set; }
        public RelayCommand DelPlaylistCommand { get; private set; }

        public ObservableCollection<Playlists> PPlaylists
        {

            get => mcvm.PublicPlaylists;

            set
            {
                mcvm.UserPlaylists = value;
                OnPropertyChanged();
            }
        }

        public Playlists SelectedPlaylist
        {
            get => _selectedPlaylist;
            set
            {
                _selectedPlaylist = value;
                OnPropertyChanged("SelectedPlaylist");
            }

        }

        public MainContentViewModel mcvm { get; set; }

        public PublicPlaylistViewModel(MainContentViewModel mcvm)
        {
            this.mcvm = mcvm;
            AddPlaylistCommand = new RelayCommand(AddPublicPlaylistToUserLibrary);

            //Products = (ObservableCollection<Produit>)_db.Produits;

            //Test Public Playlist
            string? _artist = null;
            string? _genre = null;
            string _title = "Public Playlist #";
            int i = 1;
            bool goodName = false;
            while (!goodName){Playlists compareTo;try{compareTo = PPlaylists.Where(x => x.Title == _title + i).First();i++;}catch{goodName = true;_title += i;}}
            int? _year = 2022;
            int _is_public = 1;
            string? _album_cover = null;
            int _id_user = -1;
            Playlists A = new Playlists(_artist, _genre, _title, _year, _is_public, _id_user, _album_cover);
            mcvm.PublicPlaylists.Add(A);
            //Test Public Playlist

        }
        public PublicPlaylistViewModel()
        {
            AddPlaylistCommand = new RelayCommand(AddPublicPlaylistToUserLibrary);

            //Products = (ObservableCollection<Produit>)_db.Produits;
        }

        private void AddPublicPlaylistToUserLibrary(object nothig)
        {

            Playlists compareTo;
            try
            {
                //Eventuellement le faire avec l'ID de la playlist
                compareTo = mcvm.UserPlaylists.Where(x => x.Title == SelectedPlaylist.Title).First();
            }
            catch
            {
                mcvm.UserPlaylists.Add(SelectedPlaylist);
            }
        }
    }
}
