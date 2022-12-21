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
using System.Text.Json.Nodes;

namespace SylviesMp3s.ViewModels
{
    class SignInViewModel : BaseViewModel
    {
        private BaseViewModel logInViewModel;

        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public RelayCommand ConnexionPressedCommand { get; private set; }
      
        public RelayCommand ReturnToLogInPressedCommand { get; private set; }
        public MainViewModel mvm { get; set; }
        public MainContentViewModel mcvm { get; set; }

        public SignInViewModel(MainViewModel mvm, MainContentViewModel mcvm )
        {
            ConnexionPressedCommand = new RelayCommand(ConnexionPressed);
            ReturnToLogInPressedCommand = new RelayCommand(ReturnToLogInPressed);

            //Products = (ObservableCollection<Produit>)_db.Produits;
            this.mcvm = mcvm;
            this.mvm = mvm;
        }
        private void ConnexionPressed(object nothig)
        {
            if(username!="" && password!="" && email!="")
            {
                mvm.SignUpAsync(username, password, email);
                mvm.setloginpage();
            }

        }


        private void ReturnToLogInPressed(object nothig)
        {
            mvm.setloginpage();
        }
    }
}
