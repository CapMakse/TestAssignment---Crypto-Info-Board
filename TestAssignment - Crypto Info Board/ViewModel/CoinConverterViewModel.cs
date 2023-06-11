using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TestAssignment___Crypto_Info_Board.ViewModel
{
    class CoinConverterViewModel : BaseVM
    {
        private string _coinIdFrom;
        private string _coinIdTo;
        private string _currencyRate;
        public ObservableCollection<Coin> CoinsFrom { get; set; }
        public ObservableCollection<Coin> CoinsTo { get; set; }
        private Coin _selectedCoinFrom;
        private Coin _selectedCoinTo;
        public CoinConverterViewModel()
        {
            _coinAPI = CoinAPIStorage.GetInstance();
            CoinsFrom = new ObservableCollection<Coin>();
            CoinsTo = new ObservableCollection<Coin>();
        }
        public string CoinIdFrom
        {
            get { return _coinIdFrom; }
            set
            {
                _coinIdFrom = value;
                UpdateSearchResult(CoinsFrom, _coinAPI.SearchCoinAsync(_coinIdFrom).Result);
                OnPropertyChanged("CoinIdFrom");
            }
        }
        public string CoinIdTo
        {
            get { return _coinIdTo; }
            set
            {
                _coinIdTo = value;
                UpdateSearchResult(CoinsTo, _coinAPI.SearchCoinAsync(_coinIdTo).Result);
                OnPropertyChanged("CoinIdTo");
            }
        }
        public string CurrencyRate
        {
            get { return _currencyRate; }
            set
            {
                _currencyRate = value;
                OnPropertyChanged("CurrencyRate");
            }
        }
        public Coin SelectedCoinFrom
        {
            get { return _selectedCoinFrom; }
            set
            {
                _selectedCoinFrom = value;
                ChangeCurrencyRate();
                OnPropertyChanged("SelectedCoinFrom");
            }
        }
        public Coin SelectedCoinTo
        {
            get { return _selectedCoinTo; }
            set
            {
                _selectedCoinTo = value;
                ChangeCurrencyRate();
                OnPropertyChanged("SelectedCoinTo");
            }
        }
        private void UpdateSearchResult(ObservableCollection<Coin> coins, ObservableCollection<Coin> newCoins)
        {
            coins.Clear();
            if (newCoins != null)
                foreach (var coin in newCoins)
                {
                    coins.Add(coin);
                }
        }
        private void ChangeCurrencyRate()
        {
            if (_selectedCoinFrom == null || _selectedCoinTo == null) return;
            double priceFrom = Double.Parse(_selectedCoinFrom.Price);
            double priceTo = Double.Parse(_selectedCoinTo.Price);
            CurrencyRate = Math.Round(priceFrom / priceTo, 7).ToString();
        }
    }
}
