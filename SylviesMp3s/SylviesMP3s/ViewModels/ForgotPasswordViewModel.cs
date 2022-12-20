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
    class ForgotPasswordViewModel : BaseViewModel
    {
        public MainViewModel mvm { get; set; }
        public RelayCommand ReturnToConnexionCommand { get; private set; }
        public RelayCommand ResetPasswordCommand { get; private set; }

        public string username
        {
            get; set;
        }
        public string email
        {
            get; set;
        }



        public ForgotPasswordViewModel(MainViewModel mvm)
        {
            ReturnToConnexionCommand = new RelayCommand(ReturnToConnexion);
            ResetPasswordCommand = new RelayCommand(ResetPassword);

            this.mvm = mvm;
            //Products = (ObservableCollection<Produit>)_db.Produits;
        }
        private void ReturnToConnexion(object nothig)
        {
            mvm.setloginpage();

        }
        private void ResetPassword(object nothig)
        {
            if (username != "" && email != "")
            {
                mvm.chercheUserAsync(username, email);
            }
        }
    }
}
