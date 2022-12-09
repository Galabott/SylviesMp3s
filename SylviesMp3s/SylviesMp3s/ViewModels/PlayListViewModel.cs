using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SylviesMp3s.ViewModels
{
    class PlayListViewModel : BaseViewModel
    {
        public MainContentViewModel mcvm { get; set; }

        public PlayListViewModel(MainContentViewModel mcvm)
        {
            this.mcvm = mcvm;
        }
    }
}
