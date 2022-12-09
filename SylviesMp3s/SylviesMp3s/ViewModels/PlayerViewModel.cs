using SylviesMp3s.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SylviesMp3s.ViewModels
{


    class PlayerViewModel : BaseViewModel
    {
        public RelayCommand NextTuneCommand { get; private set; }
        public MainContentViewModel mcvm { get; private set; }


        public PlayerViewModel()
        {
            NextTuneCommand = new RelayCommand(NextTune);
        }
        public PlayerViewModel(MainContentViewModel mcvm)
        {
            NextTuneCommand = new RelayCommand(NextTune);
        }

        private void NextTune(object nothig)
        {
            Console.WriteLine("Next song");
        }
    }


}