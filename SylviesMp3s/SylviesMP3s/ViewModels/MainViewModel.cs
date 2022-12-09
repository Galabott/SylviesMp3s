using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SylviesMp3s.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        
        private BaseViewModel currentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                currentViewModel = value;
                OnPropertyChanged();
            }
        }

        MainContentViewModel mainContentViewModel;



        public MainViewModel()
        {
           mainContentViewModel = new MainContentViewModel(this);
           
            currentViewModel = mainContentViewModel;
            
        }
    }
}
