using MarthaService;
using Microsoft.VisualBasic.ApplicationServices;
using SylviesMp3s.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json.Nodes;
using System.Windows.Controls;

namespace SylviesMp3s.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MarthaProcessor _db = MarthaProcessor.Instance;

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
        public int currentUserID = 1;
        public int CurrentUserID 
        {
            get { return currentUserID; }
            set { currentUserID = value; mainContentViewModel.CurrentUserID = value; }
        }
        public Models.User currentUser = null;
        public Models.User CurrentUser 
        {
            get { return currentUser; }
            set { currentUser = value; mainContentViewModel.CurrentUser = value; }
        }

        public MainContentViewModel mcvm { get; set; }


        MainContentViewModel mainContentViewModel;
        LogInViewModel logInViewModel;
        SignInViewModel signInViewModel;
        ForgotPasswordViewModel forgotPasswordViewModel;
        ConfirmPasswordViewModel confirmPasswordViewModel;
        AdminViewModel adminViewModel;

        public MainViewModel()
        {
            logInViewModel = new LogInViewModel(this);
            mainContentViewModel = new MainContentViewModel(this);
            signInViewModel = new SignInViewModel(this, mainContentViewModel);
            forgotPasswordViewModel = new ForgotPasswordViewModel(this);
            confirmPasswordViewModel= new ConfirmPasswordViewModel(this);
            adminViewModel = new AdminViewModel(this);
            currentViewModel = logInViewModel;
            //currentViewModel = adminViewModel;
        }
        private void RefreshList()
        {
            ObservableCollection<Models.User> Userlists = new ObservableCollection<Models.User>();
            Userlists = adminViewModel.ListUser;
            adminViewModel.ListUser = Userlists;
        }
        public void setloginpage()
        {
            CurrentViewModel = logInViewModel;
        }
        public void setsigninpage()
        {
            CurrentViewModel = signInViewModel;
        }
        public void setforgotpage()
        {
            CurrentViewModel = forgotPasswordViewModel;
        }
        public void setconfirmpage()
        {
            CurrentViewModel = confirmPasswordViewModel;
        }
        public async void getUsers()
        {
            MarthaResponse mresponse = new MarthaResponse();
            mresponse = await _db.ExecuteQueryAsync("select-all-users");

            List<Models.User> users = new List<Models.User>();

            users = MarthaResponseConverter<Models.User>.Convert(mresponse);

            foreach (Models.User m in users)
            {
                adminViewModel.ListUser.Add(m);
            }

            RefreshList();
        }

        public async void LogInAsync(string userame, string password)
        {
            JsonObject b = new JsonObject();
            b.Add("username", userame);
            b.Add("password", password);
            MarthaResponse mresponse = new MarthaResponse();
            mresponse = await _db.ExecuteQueryAsync("select-user-login", b);

            if (mresponse.Success && mresponse.Data.Any())
            {
                CurrentUser = MarthaResponseConverter<Models.User>.Convert(mresponse).First();
                CurrentUserID = CurrentUser.Id;
                mainContentViewModel.CurrentUserID = CurrentUser.Id;

                mainContentViewModel.LoadPage();
                if(currentUser.Is_Admin==1)
                {
                    CurrentViewModel = adminViewModel;
                }
                else
                {
                    CurrentViewModel = mainContentViewModel;
                }

               
            }
        }

        public async void SignUpAsync(string username, string password, string email)
        {

            JsonObject b = new JsonObject();
            b.Add("username", username);
            b.Add("password", password);
            b.Add("email", email);

            MarthaResponse mresponse = new MarthaResponse();
            mresponse = await _db.ExecuteQueryAsync("insert-user-signup", b);

            if (mresponse.Success)
            {
                AddPlaylistinSignUp(username, password);

            }

        }

        public async void ConfirmPasswordAsync(string password)
        {

            JsonObject b = new JsonObject();
            b.Add("password", password);
            b.Add("id", currentUserID);
            MarthaResponse mresponse = new MarthaResponse();
            mresponse = await _db.ExecuteQueryAsync("update-user", b);

            setloginpage();
        }
        public async void chercheUserAsync(string userame, string email)
        {
            JsonObject b = new JsonObject();
            b.Add("username", userame);
            b.Add("email", email);
            MarthaResponse mresponse = new MarthaResponse();
            mresponse = await _db.ExecuteQueryAsync("select-user-email", b);

            if (mresponse.Success && mresponse.Data.Any())
            {

                CurrentUser = MarthaResponseConverter<Models.User>.Convert(mresponse).First();
                CurrentUserID = CurrentUser.Id;
            }
            setconfirmpage();
        }
        public async void AddPlaylistinSignUp(string userame, string password)
        {
            JsonObject b = new JsonObject();
            b.Add("username", userame);
            b.Add("password", password);
            MarthaResponse mresponse = new MarthaResponse();
            mresponse = await _db.ExecuteQueryAsync("select-user-login", b);

            if (mresponse.Success && mresponse.Data.Any())
            {
                CurrentUser = MarthaResponseConverter<Models.User>.Convert(mresponse).First();
                CurrentUserID = CurrentUser.Id;
                mainContentViewModel.CurrentUserID = CurrentUser.Id;
                mainContentViewModel.CurrentUser = CurrentUser;
            }
            if (CurrentUserID != 1)
            {

               

                JsonObject playlist = new JsonObject();
                playlist.Add("artist", null);
                playlist.Add("genre", null);
                playlist.Add("title", "Liked Playlist");
                playlist.Add("year", 2022);
                playlist.Add("is_public", 0);
                playlist.Add("id_user", CurrentUserID);
                playlist.Add("album_cover", null);

                mresponse = await _db.ExecuteQueryAsync("insert-playlist", playlist);

                playlist = new JsonObject();
                playlist.Add("artist", null);
                playlist.Add("genre", null);
                playlist.Add("title", "My Songs");
                playlist.Add("year", 2022);
                playlist.Add("is_public", 0);
                playlist.Add("id_user", CurrentUserID);
                playlist.Add("album_cover", null);
                mresponse = await _db.ExecuteQueryAsync("insert-playlist", playlist);

                

            }

           
        }
        //admin crudl

        public async void delUserAsync(int selectedUserId ,string selectedUserPassword)
        {

            JsonObject b = new JsonObject();
            b.Add("password", selectedUserPassword);
            b.Add("id", selectedUserId);
            MarthaResponse mresponse = new MarthaResponse();
            mresponse = await _db.ExecuteQueryAsync("deleate-user", b);

           
        }

        public async void UpdateUserAsync(string username, string password,string email,int id)
        {

            JsonObject b = new JsonObject();
            b.Add("username", username);
            b.Add("password", password);
            b.Add("email", email);
            b.Add("id", id);
            MarthaResponse mresponse = new MarthaResponse();
            mresponse = await _db.ExecuteQueryAsync("update-user-complete", b);

           
        }

        public async void deleteTuneAsync( int id)
        {

            JsonObject b = new JsonObject();
           
            b.Add("id", id);
            MarthaResponse mresponse = new MarthaResponse();
            mresponse = await _db.ExecuteQueryAsync("delete-tune-user", b);


        }
        public async void deletePlayAsync(int id)
        {

            JsonObject b = new JsonObject();

            b.Add("id", id);
            MarthaResponse mresponse = new MarthaResponse();
            mresponse = await _db.ExecuteQueryAsync("delete-play-user", b);


        }
        public async void changeViewAsync()
        {
            CurrentViewModel = mainContentViewModel;
        }



    }
}

