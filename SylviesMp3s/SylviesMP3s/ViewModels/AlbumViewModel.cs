using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SylviesMp3s.ViewModels
{
    internal class AlbumViewModel : BaseViewModel
    {
        public MainContentViewModel mcvm { get; set; }

        public AlbumViewModel(MainContentViewModel mcvm)
        {
            this.mcvm = mcvm;
        }
    }
}
