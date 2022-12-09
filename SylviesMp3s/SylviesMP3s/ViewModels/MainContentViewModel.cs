using SylviesMp3s.Commands;
using SylviesMp3s.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SylviesMp3s.ViewModels
{
    public class MainContentViewModel : BaseViewModel
    {
        private BaseViewModel leftViewModel;

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

        public MainViewModel mvm { get; set; }


        public RelayCommand ChangeLeftViewPlayList { get; private set; }
        public RelayCommand ChangeLeftViewAlbum { get; private set; }
        public RelayCommand ChangeLeftViewPublic { get; private set; }


        public MainContentViewModel( MainViewModel mvm)
        {
            listPlayListViewModel = new ListPlayListViewModel(this);
            playListViewModel = new PlayListViewModel(this);
            playerViewModel = new PlayerViewModel();

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
            ListPlayListViewModel listPlayListViewModel = new ListPlayListViewModel(this);
            LeftViewModel = listPlayListViewModel;
        }
        private void ChangeLeftViewA(object nothig)
        {
            AlbumViewModel albumViewModel = new AlbumViewModel(this);
            LeftViewModel = albumViewModel;
        }
        private void ChangeLeftViewP(object nothig)
        {

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

