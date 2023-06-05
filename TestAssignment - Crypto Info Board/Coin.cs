using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
namespace TestAssignment___Crypto_Info_Board
{
    class Coin : INotifyPropertyChanged
    {
        private string _id;
        private string _name;
        private string _priceUSD;
        private string _changePercent;
        [JsonPropertyName("id")]
        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }
        [JsonPropertyName("name")]
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        [JsonPropertyName("priceUsd")]
        public string Price
        {
            get { return _priceUSD; }
            set
            {
                _priceUSD = value.Substring(0, value.IndexOf('.') + 3) + " USD";
                OnPropertyChanged("Price");
            }
        }
        [JsonPropertyName("changePercent24Hr")]
        public string ChangePercent
        {
            get { return _changePercent;   }
            set
            {
                _changePercent = value == null ? "0" : value.Substring(0, value.IndexOf('.') + 4);
                OnPropertyChanged("ChangePercent");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
