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
    class LogInViewModel : BaseViewModel
    {
        User current_user { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public MainContentViewModel mcvm { get; set; }
        public RelayCommand LogInPressedCommand { get; private set; }
        public RelayCommand SignInPressedCommand { get; private set; }
        public RelayCommand ForgotPasswordCommand { get; private set; }


        public LogInViewModel()
        {
            LogInPressedCommand = new RelayCommand(LogInPressed);
            SignInPressedCommand = new RelayCommand(SignInPressed);
            ForgotPasswordCommand = new RelayCommand(ForgotPassword);

            //Products = (ObservableCollection<Produit>)_db.Produits;
            
        }
        private void LogInPressed(object nothig)
        {
            if(username!= "" && password!="")
            {
                mcvm.LogInAsync(username, password);
            }
            
        }

        private void SignInPressed(object nothig)
        {

        }

        private void ForgotPassword(object nothig)
        {

        }

    }
}
