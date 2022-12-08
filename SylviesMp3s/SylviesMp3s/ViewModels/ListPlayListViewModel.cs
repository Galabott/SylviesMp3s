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

namespace SylviesMp3s.ViewModels
{
    public class ListPlayListViewModel : BaseViewModel
    {
        //private ProduitDataService _db = new ProduitDataService();

        private Playlists _selectedPlaylist;

        private ObservableCollection<Playlists> pplaylists = new ObservableCollection<Playlists>();

        public RelayCommand AddPlaylistCommand { get; private set; }
        public RelayCommand DelPlaylistCommand { get; private set; }

        public ObservableCollection<Playlists> PPlaylists
        {
            get => pplaylists;

            set
            {
                pplaylists = value;
                OnPropertyChanged();
            }
        }

        public Playlists SelectedPlaylist
        {
            get => _selectedPlaylist;
            set
            {
                _selectedPlaylist = value;
                OnPropertyChanged("SelectedProd");
            }

        }

        public ListPlayListViewModel()
        {

            AddPlaylistCommand = new RelayCommand(AddProd);
            DelPlaylistCommand = new RelayCommand(DelProd);

            //Products = (ObservableCollection<Produit>)_db.Produits;
        }

        private void DelProd(object nothig)
        {
            if (SelectedPlaylist != null)
            {
                pplaylists.Remove(SelectedPlaylist as Playlists);
            }
        }

        private void AddProd(object nothig)
        {
            string? _artist = null;
            string? _genre = null;
            string _title = "My Playlist #";

            int i = 1;
            bool goodName = false;

            while (!goodName)
            {
                foreach (Playlists p in pplaylists)
                {
                    if (_title + i == p.Title)
                    {
                        i++;
                    }
                    else
                    {
                        goodName = true;
                        _title += i;
                    }

                }
            }

            int? _year = 2022;
            bool _is_public = true;
            string? _album_cover = null;

            /// IMPORTANT -- IMPORTANT -- IMPORTANT -- IMPORTANT -- IMPORTANT -- IMPORTANT -- IMPORTANT -- 
            /// CHANGER A CURRENT USER WHEN DONE
            int _id_user = -1;
            
            Playlists A = new Playlists(_artist, _genre, _title, _year, _is_public, _id_user, _album_cover);
            pplaylists.Add(A);
            SelectedPlaylist = A;
        }
    }
}
