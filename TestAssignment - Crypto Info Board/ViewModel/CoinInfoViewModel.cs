using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;

namespace TestAssignment___Crypto_Info_Board.ViewModel
{
    class CoinInfoViewModel : BaseVM
    {
        CoinInfo _coinInfo;
        string _coinId = "bitcoin";
        public ObservableCollection<Market> Markets { get; set; }
        public Market _selectedMarket;
        public CoinInfoViewModel()
        {

            _coinAPI = CoinAPIStorage.GetInstance();
            CoinInfo = _coinAPI.GetCoinInfoAsync(_coinId).Result;
            Markets = _coinAPI.GetMarketsForCoinAsync(_coinId).Result;

        }
        public CoinInfo CoinInfo
        {
            get { return _coinInfo; }
            set
            {
                _coinInfo = value;
                OnPropertyChanged("CoinInfo");
            }
        }
        public Market SelectedMarket
        {
            get { return _selectedMarket; }
            set
            {
                _selectedMarket = value;
                OnPropertyChanged("SelectedMarket");
            }
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
        public ICommand SelectCoinInfo
        {
            get { return new RelayCommand(param => {
                CoinInfo = _coinAPI.GetCoinInfoAsync(_coinId).Result;
                Markets = _coinAPI.GetMarketsForCoinAsync(_coinId).Result;
            }); }
        }
        
        public ICommand OpenBrowser
        {
            get { return new RelayCommand(param => {
                try
                {
                    System.Diagnostics.Process.Start(param as string);
                }
                catch (System.ComponentModel.Win32Exception noBrowser)
                {
                    if (noBrowser.ErrorCode == -2147467259)
                        MessageBox.Show(noBrowser.Message);
                }
                catch (System.Exception other)
                {
                    MessageBox.Show(other.Message);
                }
            }); }
        }

    }
}
