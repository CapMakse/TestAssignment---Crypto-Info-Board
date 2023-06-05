using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Net.Http;

namespace TestAssignment___Crypto_Info_Board
{
    class CoinCapAPI : ICoinAPI
    {
        private HttpClient _client = new HttpClient();
        private string baseURL = "http://api.coincap.io/v2";
        public ObservableCollection<Coin> SearchCoin(string id)
        {
            var response = _client.GetStreamAsync(baseURL + $"/assets?search={id}").Result;
            var document = JsonDocument.Parse(response);
            var coins = document.RootElement.GetProperty("data");
            var coinsCollection = coins.Deserialize<List<Coin>>();
            return new ObservableCollection<Coin>(coinsCollection);
        }
        public ObservableCollection<Coin> GetCoins(int limit, int page)
        {
            
            return null;
        }
        public ObservableCollection<Market> GetMarketsForCoin(string coinId)
        {
            var response = _client.GetStreamAsync(baseURL + $"/markets?baseId={coinId}&quoteId=united-states-dollar").Result;
            return null;
        }

    }
}
