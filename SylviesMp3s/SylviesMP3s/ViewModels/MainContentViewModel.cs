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



        public RelayCommand ChangeLeftViewPlayList { get; private set; }
        public RelayCommand ChangeLeftViewAlbum { get; private set; }
        public RelayCommand ChangeLeftViewPublic { get; private set; }


        public MainContentViewModel()
        {
            listPlayListViewModel = new ListPlayListViewModel();
            playListViewModel = new PlayListViewModel();
            playerViewModel = new PlayerViewModel();

            LeftViewModel = listPlayListViewModel;
            CentralViewModel = playListViewModel;
            upperViewModel = playerViewModel;




            ChangeLeftViewPlayList = new RelayCommand(ChangeLeftViewPL);
            ChangeLeftViewAlbum = new RelayCommand(ChangeLeftViewA);
            ChangeLeftViewPublic = new RelayCommand(ChangeLeftViewP);

        }

        private void ChangeLeftViewPL(object nothig)
        {
            ListPlayListViewModel listPlayListViewModel = new ListPlayListViewModel();
            LeftViewModel = listPlayListViewModel;
        }
        private void ChangeLeftViewA(object nothig)
        {
            AlbumViewModel albumViewModel = new AlbumViewModel();
            LeftViewModel = albumViewModel;
        }
        private void ChangeLeftViewP(object nothig)
        {

        }
    }
    
}

