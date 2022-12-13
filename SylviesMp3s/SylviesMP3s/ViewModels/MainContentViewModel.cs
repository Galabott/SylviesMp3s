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
    public class MainContentViewModel : BaseViewModel
    {
        private BaseViewModel leftViewModel;

        public ObservableCollection<Playlists> UserPlaylists = new ObservableCollection<Playlists>();
        public ObservableCollection<Tunes> SelectedPlaylistSongs = new ObservableCollection<Tunes>();
        public ObservableCollection<Playlists> PublicPlaylists = new ObservableCollection<Playlists>();

        public BaseViewModel LeftViewModel
        {
            get { return leftViewModel; }
            set
            {
                leftViewModel = value;
                OnPropertyChanged();
            }
        }

        private BaseViewModel centralViewModel;

        public BaseViewModel CentralViewModel
        {
            get { return centralViewModel; }
            set
            {
                centralViewModel = value;
                OnPropertyChanged();
            }
        }
        private BaseViewModel upperViewModel;

        public BaseViewModel UpperViewModel
        {
            get { return upperViewModel; }
            set
            {
                upperViewModel = value;
                OnPropertyChanged();
            }
        }

        ListPlayListViewModel listPlayListViewModel;
        PlayListViewModel playListViewModel;
        PlayerViewModel playerViewModel;
        AlbumViewModel albumViewModel;
        PublicPlaylistViewModel publicPlaylistViewModel;

        public MainViewModel mvm { get; set; }


        public RelayCommand ChangeLeftViewPlayList { get; private set; }
        public RelayCommand ChangeLeftViewAlbum { get; private set; }
        public RelayCommand ChangeLeftViewPublic { get; private set; }


        public MainContentViewModel( MainViewModel mvm)
        {
            listPlayListViewModel = new ListPlayListViewModel(this);
            playListViewModel = new PlayListViewModel(this);
            playerViewModel = new PlayerViewModel(this);
            albumViewModel = new AlbumViewModel(this);
            publicPlaylistViewModel = new PublicPlaylistViewModel(this);

            LeftViewModel = listPlayListViewModel;
            CentralViewModel = playListViewModel;
            upperViewModel = playerViewModel;

            this.mvm = mvm;


            ChangeLeftViewPlayList = new RelayCommand(ChangeLeftViewPL);
            ChangeLeftViewAlbum = new RelayCommand(ChangeLeftViewA);
            ChangeLeftViewPublic = new RelayCommand(ChangeLeftViewP);

        }

        private void ChangeLeftViewPL(object nothig)
        { 
            LeftViewModel = listPlayListViewModel;
        }
        private void ChangeLeftViewA(object nothig)
        {
            LeftViewModel = albumViewModel;
        }
        private void ChangeLeftViewP(object nothig)
        {
            LeftViewModel = publicPlaylistViewModel;
        }

        public void changeParentViewModel(BaseViewModel newView)
        {
            mvm.CurrentViewModel = newView;
        }
        public void changeLeftView(BaseViewModel newView)
        {
            LeftViewModel= newView;
        }
        public void changeUpperView(BaseViewModel newView)
        {
            UpperViewModel = newView;
        }
        public void changeCentralView(BaseViewModel newView)
        {
            CentralViewModel = newView;
        }
    }
    
}

