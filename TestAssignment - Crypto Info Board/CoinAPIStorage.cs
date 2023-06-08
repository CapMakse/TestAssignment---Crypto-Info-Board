using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssignment___Crypto_Info_Board
{
    static class CoinAPIStorage
    {
        static ICoinAPI _coinAPI;
        static public ICoinAPI GetInstance()
        {
            return _coinAPI;
        }
        static public ICoinAPI GetCoinCapAPIInstance()
        {
            _coinAPI = new CoinCapAPI();
            return _coinAPI;
        }
    }
}
