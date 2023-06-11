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
        public ICommand SelectMain
        {
            get { return new RelayCommand(param => { CurrentPage = new Pages.Main(); }); }
        }
        public ICommand SelectCoinInfo
        {
            get { return new RelayCommand(param => { CurrentPage = new Pages.CoinInfo(); }); }
        }
        public ICommand SelectSearch
        {
            get { return new RelayCommand(param => { CurrentPage = new Pages.Search(); }); }
        }
        public ICommand SelectConverter
        {
            get { return new RelayCommand(param => { CurrentPage = new Pages.CoinConverter(); }); }
        }
    }
}
