using SylviesMp3s.Commands;
using SylviesMp3s.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
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
                compareTo = mcvm.UserPlaylists.Where(x => x.Id == SelectedPlaylist.Id).First();
            }
            catch
            {
                if (SelectedPlaylist != null)
                {
                    JsonObject playlist = new JsonObject();
                    playlist.Add("artist", SelectedPlaylist.Artist);
                    playlist.Add("genre", SelectedPlaylist.Genre);
                    playlist.Add("title", SelectedPlaylist.Title);
                    playlist.Add("year", SelectedPlaylist.Year);
                    playlist.Add("is_public", 0);
                    playlist.Add("id_user", mcvm.CurrentUserID);
                    playlist.Add("album_cover", SelectedPlaylist.Album_Cover);

                    mcvm.AddPublicPlaylist(playlist, SelectedPlaylist.Id);
                }
            }
        }
    }
}
