using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TestAssignment___Crypto_Info_Board
{
    interface ICoinAPI
    {
        ObservableCollection<Coin> SearchCoin(string id);
        CoinInfo GetCoinInfo(string id);
        ObservableCollection<Coin> GetCoins(int limit, int page);
        ObservableCollection<Market> GetMarketsForCoin(string coinId);

    }

}
