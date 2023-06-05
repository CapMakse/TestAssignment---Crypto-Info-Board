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
        public async Task<ObservableCollection<Coin>> SearchCoinAsync(string id)
        {
            var response = await _client.GetStreamAsync(baseURL + $"/assets?search={id}");
            List<Coin> coinsCollection = GetDataFromStream(response).Deserialize<List<Coin>>();
            return new ObservableCollection<Coin>(coinsCollection);
        }
        public async Task<CoinInfo> GetCoinInfoAsync(string id)
        {
            var response = await _client.GetStreamAsync(baseURL + $"/assets/{id}");
            return GetDataFromStream(response).Deserialize<CoinInfo>();
        }
        public async Task<ObservableCollection<Coin>> GetCoinsAsync(int limit, int page)
        {
            
            return null;
        }
        public async Task<ObservableCollection<Market>> GetMarketsForCoinAsync(string coinId)
        {
            var response = await _client.GetStreamAsync(baseURL + $"/markets?baseId={coinId}&quoteId=united-states-dollar");
            List<Market> marketsCollection = GetDataFromStream(response).Deserialize<List<Market>>();
            foreach (Market market in marketsCollection)
            {
                var marketResponse = await _client.GetAsync(baseURL + $"/exchanges/{market.Id}");
                if (!marketResponse.IsSuccessStatusCode) continue;
                response = await marketResponse.Content.ReadAsStreamAsync();
                var data = GetDataFromStream(response);
                market.Name = data.GetProperty("name").GetString();
                market.URL = data.GetProperty("exchangeUrl").GetString();
            }
            marketsCollection.RemoveAll(market => market.Name == null);
            return new ObservableCollection<Market>(marketsCollection);
        }
    }
}
