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
        public MainViewModel mvm;




        public RelayCommand AddUserCommand { get; private set; }
        public RelayCommand DelUserCommand { get; private set; }
        public RelayCommand SaveUserCommand { get; private set; }
        public RelayCommand ReturnCommand { get; private set; }


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
            ListUser= new ObservableCollection<User>();


            mvm.getUsers();
        }

        private void AddUser(object nothig)
        {

        }
        private void DelUser(object nothig) 
        {
        
        }
        private void SaveUser(object nothig) 
        {
        
        }
        private void Return(object nothig) 
        {
        
        }
    }
}
