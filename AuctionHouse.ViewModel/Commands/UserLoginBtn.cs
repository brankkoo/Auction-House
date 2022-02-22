using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using View.Commands;

namespace AuctionHouse.ViewModel.Commands
{
    public class UserLoginBtn : CommandBase
    {
        private MainWindowViewModel mwm;

        public UserLoginBtn(MainWindowViewModel mwm)
        {
            this.mwm = mwm;
            mwm.PropertyChanged += Mwm_PropertyChanged; ;
        }

        private void Mwm_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(mwm.CurrentUser.Username));
        }

        public override bool CanExecute(object? parameter)
        {
            
            return !string.IsNullOrEmpty(mwm.CurrentUser.Username) && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            MessageBox.Show("You are already logged in sir!");
        }
    }
}
