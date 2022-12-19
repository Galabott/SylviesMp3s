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
        public MainContentViewModel mcvm { get; set; }
        public RelayCommand ReturnToConnexionCommand { get; private set; }
        public RelayCommand ResetPasswordCommand { get; private set; }

        string username;
        string email;



        public ForgotPasswordViewModel()
        {
            ReturnToConnexionCommand = new RelayCommand(ReturnToConnexion);
            ResetPasswordCommand = new RelayCommand(ResetPassword);


            //Products = (ObservableCollection<Produit>)_db.Produits;
        }
        private void ReturnToConnexion(object nothig)
        {
           

        }
        private void ResetPassword(object nothig)
        {
            if (username != "" && email != "")
            {
                mcvm.chercheUserAsync(username, email);
            }
        }
    }
}
