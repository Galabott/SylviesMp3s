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
        string username;
        string email;
        string password;
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

                mvm.LogInAsync(username, password);

                JsonObject playlist = new JsonObject();
                playlist.Add("artist", null);
                playlist.Add("genre", null);
                playlist.Add("title", "Liked Playlist");
                playlist.Add("year", null);
                playlist.Add("is_public", false);
                playlist.Add("id_user", mcvm.CurrentUserID);
                playlist.Add("album_cover", null);
                mcvm.AddPlaylist(playlist);

                playlist = new JsonObject();
                playlist.Add("artist", null);
                playlist.Add("genre", null);
                playlist.Add("title", "My Spngs");
                playlist.Add("year", null);
                playlist.Add("is_public", false);
                playlist.Add("id_user", mcvm.CurrentUserID);
                playlist.Add("album_cover", null);
                mcvm.AddPlaylist(playlist);

            }

        }


        private void ReturnToLogInPressed(object nothig)
        {
            mvm.setloginpage();
        }
    }
}
