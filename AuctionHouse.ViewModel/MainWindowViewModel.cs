using AuctionHouse.Model;
using AuctionHouse.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace AuctionHouse.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private User _currentUser;
        private ProductCollection _products;
        private Product _product;
       

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }


        public Product Product { get { return _product; } set { if (_product == value) { return;   } _product = value; OnPropertyChanged(new PropertyChangedEventArgs(nameof(Product))); } }

        public ProductCollection Products { get { return _products; } set { if (_products == value) { return;} _products = value; OnPropertyChanged(new PropertyChangedEventArgs(nameof(Products))); } }

        public User? CurrentUser { get { return _currentUser;} set
            {
                if (_currentUser == value)
                {
                    return;
                }
                _currentUser = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(CurrentUser)));
            }
        }

        
        public bool? IsLoggedIn { get { if (CurrentUser != null) { return false; } else { return true; } } }

        public bool? IsLoggedIn2 { get { if (CurrentUser != null) { return true; } else { return false; } } set { OnPropertyChanged(new PropertyChangedEventArgs(nameof(IsLoggedIn2))); } }

        public ICommand UserLoginBtn { get; }
       public ICommand BidCommand { get; }

        public ICommand DeleteCommand { get; }
        public MainWindowViewModel()
        {
            Products = ProductCollection.GetProducts();
            Product = new Product();

            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += Dt_Tick;
            dt.Start();

            
        }

        private void Dt2_Tick(object? sender, EventArgs e)
        {
            Products = ProductCollection.GetProducts();
        }

        private void Dt_Tick(object? sender, EventArgs e)
        {
            if (Product != null)
            {
                Product.Time--;
            }
            
        }
        
        public MainWindowViewModel(User _currentUser)
        {
            this._currentUser = _currentUser;
            UserLoginBtn = new UserLoginBtn(this);
            Products = ProductCollection.GetProducts();
            Product = new Product();
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += Dt_Tick;
            dt.Start();
            BidCommand = new BidCommand(this);

            DispatcherTimer dt2 = new DispatcherTimer();
            dt2.Interval = TimeSpan.FromSeconds(15);
            dt2.Tick += Dt2_Tick;
            dt2.Start();

            DeleteCommand = new DeleteCommand(this);

    }



    }
}
