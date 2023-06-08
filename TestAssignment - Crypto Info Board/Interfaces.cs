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
        Task<ObservableCollection<Coin>> SearchCoinAsync(string id);
        Task<CoinInfo> GetCoinInfoAsync(string id);
        Task<ObservableCollection<Coin>> GetCoinsAsync(int limit = 10, int page = 0);
        Task<ObservableCollection<Market>> GetMarketsForCoinAsync(string coinId);

    }

}
