using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Commands;

namespace AuctionHouse.ViewModel.Commands
{
    public class DeleteCommand : CommandBase
    {
        MainWindowViewModel vm;

        public DeleteCommand(MainWindowViewModel mainWindowView)
        {
            vm = mainWindowView;
        }
        public override void Execute(object? parameter)
        {
            vm.Product.DeleteProduct();
        }
    }
}
