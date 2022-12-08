using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SylviesMp3s.ViewModels
{
    public class MainViewModel : BaseViewModel
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


        public MainViewModel()
        {
            listPlayListViewModel = new ListPlayListViewModel();
            playListViewModel = new PlayListViewModel();
            playerViewModel = new PlayerViewModel();

            LeftViewModel = listPlayListViewModel;
            CentralViewModel = playListViewModel;
            upperViewModel = playerViewModel;

        }
    }
}
