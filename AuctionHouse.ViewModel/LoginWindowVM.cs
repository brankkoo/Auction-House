using AuctionHouse.Model;
using AuctionHouse.ViewModel.Commands;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AuctionHouse.ViewModel
{
    public class LoginWindowVM : Screen 
    {

        private string _userName;
        private User _currentUser;
        public string Username
        {
            get { return _userName; }
            set
            {
                _userName = value;
                NotifyOfPropertyChange(() => Username);
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }

        public ICommand LoginCommand { get; }

        public User CurrentUser
        {
            get { return _currentUser; }
            set
            {
                if (_currentUser == value)
                {
                    return;
                }
                _currentUser = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(CurrentUser)));
            }
        }

        public LoginWindowVM(User user) { _currentUser = user; }


        public LoginWindowVM()
        {
            LoginCommand = new LoginCommand(this);
        }
    }
}
