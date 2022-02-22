using AuctionHouse.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AuctionHouse
{
    
    public partial class App : Application
    {
        public App()
        {
            User user = new User();
            Product product = new Product();
            ProductCollection products = new ProductCollection();
        }
    }
}
