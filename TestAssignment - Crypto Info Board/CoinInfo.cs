using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace TestAssignment___Crypto_Info_Board
{
    class CoinInfo : Coin
    {

        private string _symbol;
        private string _supply;
        private string _maxSupply;
        private string _volumeUsd24Hr;
        [JsonPropertyName("symbol")]
        public string Symbol
        {
            get { return _symbol; }
            set
            {
                _symbol = value;
                OnPropertyChanged("Symbol");
            }
        }
        [JsonPropertyName("supply")]
        public string Supply
        {
            get { return _supply; }
            set
            {
                _supply = value == null ? "0" : value.Substring(0, value.IndexOf('.'));
                OnPropertyChanged("Supply");
            }
        }
        [JsonPropertyName("maxSupply")]
        public string MaxSupply
        {
            get { return _maxSupply; }
            set
            {
                _maxSupply = value == null ? "0" : value.Substring(0, value.IndexOf('.'));
                OnPropertyChanged("MaxSupply");
            }
        }
        [JsonPropertyName("volumeUsd24Hr")]
        public string VolumeUsd24Hr
        {
            get { return _volumeUsd24Hr; }
            set
            {
                _volumeUsd24Hr = value == null ? "0" : value.Substring(0, value.IndexOf('.') + 3) + " USD";
                OnPropertyChanged("VolumeUsd24Hr");
            }
        }
    }
}
