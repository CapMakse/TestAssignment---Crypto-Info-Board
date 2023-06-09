using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace TestAssignment___Crypto_Info_Board.ViewModel
{
    class SearchViewModel : BaseVM
    {
        private string _coinId;
        public ObservableCollection<Coin> Coins { get; set; }

        public SearchViewModel()
        {
            _coinAPI = CoinAPIStorage.GetInstance();
            Coins = _coinAPI.GetCoinsAsync().Result;
        }
        public string CoinId
        {
            get { return _coinId; }
            set
            {
                _coinId = value;
                OnPropertyChanged("CoinId");
            }
        }
        public ICommand SearchCoin
        {
            get
            {
                return new RelayCommand(param => {
                    Coins.Clear();
                    var newCoins = _coinAPI.SearchCoinAsync(_coinId).Result;
                    foreach (var coin in newCoins)
                    {
                        Coins.Add(coin);
                    }
                });
            }
        }
    }
}
