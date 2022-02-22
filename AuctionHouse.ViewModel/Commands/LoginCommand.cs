using AuctionHouse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using View.Commands;

namespace AuctionHouse.ViewModel.Commands
{
    public class LoginCommand : CommandBase
    {
        private LoginWindowVM uvm;

        public LoginCommand(LoginWindowVM uvm)
        {
            this.uvm = uvm;
            uvm.PropertyChanged += Uvm_PropertyChanged;
        }

        private void Uvm_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(uvm.Username))
            {
                RaiseCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(uvm.Username) && base.CanExecute(parameter);
        }
        public override void Execute(object? parameter)
        {
            User user = new User(uvm.Username, uvm.Password);
            user.Login();
            MainWindowViewModel mainWindow = new MainWindowViewModel(user.CurrentUser);
            Application.Current.MainWindow.DataContext = mainWindow;
            
        }
    }
}
