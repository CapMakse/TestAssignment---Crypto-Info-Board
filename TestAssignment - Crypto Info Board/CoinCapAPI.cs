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
        private JsonElement GetDataFromStream(System.IO.Stream stream)
        {
            return JsonDocument.Parse(stream).RootElement.GetProperty("data");
        }
        public ObservableCollection<Coin> SearchCoin(string id)
        {
            var response = _client.GetStreamAsync(baseURL + $"/assets?search={id}").Result;
            var coinsCollection = GetDataFromStream(response).Deserialize<List<Coin>>();
            return new ObservableCollection<Coin>(coinsCollection);
        }
        public CoinInfo GetCoinInfo(string id)
        {
            var response = _client.GetStreamAsync(baseURL + $"/assets/{id}").Result;
            return GetDataFromStream(response).Deserialize<CoinInfo>();
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
