using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace TestAssignment___Crypto_Info_Board.ViewModel
{
    class MainViewModel : BaseVM
    {
        ICoinAPI _coinAPI;
        public ObservableCollection<Coin> PopularCoins { get; set; }

         public MainViewModel()
        {

            _coinAPI = CoinAPIStorage.GetInstance();

        }
    }
}
