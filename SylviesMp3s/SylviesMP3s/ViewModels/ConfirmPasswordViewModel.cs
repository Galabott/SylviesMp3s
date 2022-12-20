using System;
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
    class ConfirmPasswordViewModel : BaseViewModel
    {
        string password;
        string confirn_password;
        public MainViewModel mvm { get; set; }

        public RelayCommand ResetPasswordCommand { get; private set; }



        public ConfirmPasswordViewModel(MainViewModel mvm)
        {
            ResetPasswordCommand = new RelayCommand(ResetPassword);

            this.mvm = mvm;
            //Products = (ObservableCollection<Produit>)_db.Produits;
        }
        private void ResetPassword(object nothig)
        {
            if(password!="" && confirn_password !="")
            { 
                if(password == confirn_password)
                {
                    mvm.ConfirmPasswordAsync(password);
                }
            }
            
        }

       
    }
}
