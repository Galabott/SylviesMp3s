using SylviesMp3s.Commands;
using SylviesMp3s.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Text.Json.Nodes;

namespace SylviesMp3s.ViewModels
{
    public class ListPlayListViewModel : BaseViewModel
    {
        //private ProduitDataService _db = new ProduitDataService();

        private Playlists _selectedPlaylist;

        private ObservableCollection<Playlists> pplaylists = new ObservableCollection<Playlists>();

        public RelayCommand AddPlaylistCommand { get; private set; }
        public RelayCommand DelPlaylistCommand { get; private set; }
        public RelayCommand SavePlaylistCommand { get; private set; }


        public MainContentViewModel mcvm { get; set; }

        public ListPlayListViewModel(MainContentViewModel mcvm)
        {
            this.mcvm = mcvm;
            AddPlaylistCommand = new RelayCommand(AddPlaylist);
            DelPlaylistCommand = new RelayCommand(DelPlaylist);
            SavePlaylistCommand = new RelayCommand(SavePlaylist);


            _selectedPlaylist = new Playlists("Select a playlist", "Select a playlist", "Select a playlist", 0, 0, -1, "Select a playlist");


            //Products = (ObservableCollection<Produit>)_db.Produits;
        }

        public ListPlayListViewModel()
        { 
            AddPlaylistCommand = new RelayCommand(AddPlaylist);
            DelPlaylistCommand = new RelayCommand(DelPlaylist);

            //Products = (ObservableCollection<Produit>)_db.Produits;
        }

        public ObservableCollection<Playlists> PPlaylists
        {
            get => mcvm.UserPlaylists;

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
                if (_selectedPlaylist != null)
                {
                    mcvm.ChangeCurrentPlayList(SelectedPlaylist.Id);
                }
            }

        }

        private void DelPlaylist(object nothig)
        {
            if (SelectedPlaylist != null)
            {
                JsonObject playlist = new JsonObject();
                playlist.Add("userid", mcvm.CurrentUserID);
                playlist.Add("playlistid", SelectedPlaylist.Id);
                mcvm.DelPlaylist(playlist);
            }
        }

        bool enabled = false;
        private void SavePlaylist(object nothig)
        {
            if (SelectedPlaylist != null)
            {
                JsonObject playlist = new JsonObject();
                playlist.Add("playlistid", SelectedPlaylist.Id);
                playlist.Add("artist", SelectedPlaylist.Artist);
                playlist.Add("genre", SelectedPlaylist.Genre);
                playlist.Add("title", SelectedPlaylist.Title);
                playlist.Add("year", SelectedPlaylist.Year);
                playlist.Add("is_public", SelectedPlaylist.Is_Public);
                playlist.Add("id_user", mcvm.CurrentUserID);
                playlist.Add("album_cover", SelectedPlaylist.Album_Cover);

                mcvm.SavePlaylist(playlist);
            }
        }

        private void AddPlaylist(object nothig)
        {
            string? _artist = null;
            string? _genre = null;
            string _title = "My Playlist #";

            int i = 1;
            bool goodName = false;

            while (!goodName)
            {
                Playlists compareTo;
                try
                {
                    compareTo = PPlaylists.Where(x => x.Title == _title + i).First();
                    i++;
                }
                catch
                {
                    goodName = true;
                    _title += i;
                }
            }


            int? _year = 2022;
            int _is_public = 0;
            string? _album_cover = null;

            JsonObject playlist = new JsonObject();
            playlist.Add("artist", _artist);
            playlist.Add("genre", _genre);
            playlist.Add("title", _title);
            playlist.Add("year", _year);
            playlist.Add("is_public", _is_public);
            playlist.Add("id_user", mcvm.CurrentUserID);
            playlist.Add("album_cover", _album_cover);
            //"?", "?genre", "?title", ?year, ?is_public, ?id_user, "?album_cover"

            mcvm.AddPlaylist(playlist);
        }

    }
}
