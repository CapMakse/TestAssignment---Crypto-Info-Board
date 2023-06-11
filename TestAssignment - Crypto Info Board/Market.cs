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
    class Market : INotifyPropertyChanged
    {
        private string _id;
        private string _name;
        private string _priceUSD;
        private string _URL;
        [JsonPropertyName("exchangeId")]
        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }
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
                _priceUSD = Math.Round(Double.Parse(value.Replace('.', ',')), 4).ToString();
                OnPropertyChanged("Price");
            }
        }
        public string URL
        {
            get { return _URL; }
            set
            {
                _URL = value;
                OnPropertyChanged("URL");
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

