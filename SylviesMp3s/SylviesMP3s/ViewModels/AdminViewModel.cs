using SylviesMp3s.Commands;
using SylviesMp3s.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;

namespace SylviesMp3s.ViewModels
{
    internal class AdminViewModel : BaseViewModel
    {
        int modes = 0;

        public MainViewModel mvm;

        public string username;
        public string email;
        public string password;


        public RelayCommand AddUserCommand { get; private set; }
        public RelayCommand DelUserCommand { get; private set; }
        public RelayCommand SaveUserCommand { get; private set; }
        public RelayCommand ReturnCommand { get; private set; }
        public RelayCommand CancelPlaylistCommand { get; private set; }


        private User _selectedUser;
        public User SelectedUser
        {
            get => _selectedUser;
            set
            {

                _selectedUser = value;
                OnPropertyChanged("SelectedPlaylist");
            }

        }

        public ObservableCollection<User> _ListUser;
        public ObservableCollection<User> ListUser
        {
            get => _ListUser;

            set
            {
                _ListUser = value;
                OnPropertyChanged();
            }
        }


        public AdminViewModel(MainViewModel mvm)
        {
            this.mvm = mvm;
            AddUserCommand = new RelayCommand(AddUser);
            DelUserCommand = new RelayCommand(DelUser);
            SaveUserCommand = new RelayCommand(SaveUser);
            ReturnCommand = new RelayCommand(Return);
            CancelPlaylistCommand = new RelayCommand(Cancel);
            ListUser = new ObservableCollection<User>();
         
            mvm.getUsers();
        }

        public void refreshList()
        {
            ListUser = new ObservableCollection<User>();
            mvm.getUsers();

        }
        private void AddUser(object nothig)
        {


            modes = 1;

           
               // mvm.SignUpAsync(_selectedUser.Username, _selectedUser.Password, _selectedUser.Email);
               //  refreshList();


        }
        private void DelUser(object nothig)
        { 
            if(_selectedUser!=null)
            {
                mvm.delUserAsync(_selectedUser.Id, _selectedUser.Password);
                mvm.deleteTuneAsync(_selectedUser.Id);
                mvm.deletePlayAsync(_selectedUser.Id);
                refreshList();
            }


        }
        private void SaveUser(object nothig) 
        {
            if(modes ==1 )
            {
                mvm.SignUpAsync(_selectedUser.Username, _selectedUser.Password, _selectedUser.Email);
                refreshList();

                modes = 0;

            }
            else
            {
                if (_selectedUser != null)
                {
                    if (_selectedUser.Username != "" && _selectedUser.Password != "" && _selectedUser.Email != "")
                    {
                        mvm.UpdateUserAsync(_selectedUser.Username, _selectedUser.Password, _selectedUser.Email, _selectedUser.Id);
                        refreshList();
                    }

                }

            }

           
           
        }
        private void Return(object nothig) 
        {
            mvm.changeViewAsync();
        }
        private void Cancel(object nothig)
        {
            modes = 0;
        }
    }
}
