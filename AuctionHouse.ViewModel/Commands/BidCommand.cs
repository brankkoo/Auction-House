using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Commands;

namespace AuctionHouse.ViewModel.Commands
{
    public class BidCommand : CommandBase
    {
        MainWindowViewModel viewModel;


        public BidCommand(MainWindowViewModel main) { viewModel = main; }


        public override void Execute(object? parameter)
        {
            viewModel.Product.Bid(viewModel.CurrentUser.Username);
        }
    }
}
