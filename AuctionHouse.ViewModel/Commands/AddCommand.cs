using AuctionHouse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Commands;

namespace AuctionHouse.ViewModel.Commands
{
    public class AddCommand : CommandBase
    {


        private AddProductVm vm;


        public AddCommand(AddProductVm vm) { this.vm = vm; }
        public override void Execute(object? parameter)
        {
            Product product = new Product(vm.Name, vm.Price);
            product.AddProduct();
        }
    }
}
