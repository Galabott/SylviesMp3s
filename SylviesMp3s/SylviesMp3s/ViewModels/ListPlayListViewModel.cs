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

namespace SylviesMp3s.ViewModels
{
    public class ListPlayListViewModel : BaseViewModel
    {
        //private ProduitDataService _db = new ProduitDataService();

        private Playlists _selectedPlaylist;

        private ObservableCollection<Playlists> pplaylists = new ObservableCollection<Playlists>();

        public RelayCommand AddPlaylistCommand { get; private set; }
        public RelayCommand DelPlaylistCommand { get; private set; }


        public MainContentViewModel mcvm { get; set; }

        public ListPlayListViewModel(MainContentViewModel mcvm)
        {
            this.mcvm = mcvm;
            AddPlaylistCommand = new RelayCommand(AddPlaylist);
            DelPlaylistCommand = new RelayCommand(DelPlaylist);

            _selectedPlaylist = new Playlists("Select a playlist", "Select a playlist", "Select a playlist", 0, false, -1, "Select a playlist");


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
            }

        }

        private void DelPlaylist(object nothig)
        {
            if (SelectedPlaylist != null)
            {
                mcvm.UserPlaylists.Remove(SelectedPlaylist as Playlists);
            }
        }

        bool enabled = false;
        private void UpdatePlaylist(object nothig)
        {
            //if (SelectedPlaylist != null)
            //{
            //    mcvm.UserPlaylists.Remove(SelectedPlaylist as Playlists);
            //}
            //a7 b3 PLAYLISTS

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
            bool _is_public = false;
            string? _album_cover = null;

            /// IMPORTANT -- IMPORTANT -- IMPORTANT -- IMPORTANT -- IMPORTANT -- IMPORTANT -- IMPORTANT -- 
            /// CHANGER A CURRENT USER WHEN DONE
            int _id_user = -1;
            
            Playlists A = new Playlists(_artist, _genre, _title, _year, _is_public, _id_user, _album_cover);
            mcvm.UserPlaylists.Add(A);
            SelectedPlaylist = A;
        }

    }
}
