using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace TestAssignment___Crypto_Info_Board.ViewModel
{
    class WindowViewModel : BaseVM
    {
        private ICoinAPI _coinAPI;
        private Page _currentPage;
        public WindowViewModel()
        {
            _coinAPI = CoinAPIStorage.GetCoinCapAPIInstance();
            _currentPage = new Pages.Main();
        }
        public Page CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }
    }
}
