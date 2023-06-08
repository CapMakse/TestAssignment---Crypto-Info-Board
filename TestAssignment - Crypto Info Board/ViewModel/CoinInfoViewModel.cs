using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TestAssignment___Crypto_Info_Board.ViewModel
{
    class CoinInfoViewModel : BaseVM
    {
        ICoinAPI _coinAPI;
        CoinInfo _coinInfo;
        public ObservableCollection<Market> Markets { get; set; }
        public CoinInfoViewModel()
        {

            _coinAPI = CoinAPIStorage.GetInstance();

        }
        public string SetCoinInfo
        {
            set 
            { 
                CoinInfo = _coinAPI.GetCoinInfoAsync(value).Result;
                Markets = _coinAPI.GetMarketsForCoinAsync(value).Result;
            }
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

    }
}
