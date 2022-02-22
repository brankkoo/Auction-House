using AuctionHouse.ViewModel.Commands;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AuctionHouse.ViewModel
{
    public class AddProductVm:Screen
    {
        private string _name;
        private int _price;

        public string Name
        {
            get { return _name; }
            set
            {
               _name = value;
                NotifyOfPropertyChange(() => _name);
            }
        }



        public int Price
        {
            get { return _price; }
            set
            {
                _price = value;
                NotifyOfPropertyChange(() => _price);
            }
        }

        public ICommand AddCommand { get; }

        public AddProductVm()
        {
            AddCommand = new AddCommand(this);
        }

    }
}
