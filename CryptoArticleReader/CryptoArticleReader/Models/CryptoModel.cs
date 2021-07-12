using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoArticleReader.Models
{
    public class CryptoModel
    {
        public string URL { get; set; }
        public int Img { get; set; }
        public int Negativewords { get; set; }
        public int Positivewords { get; set; }
        public int BTC { get; set; }
        public int ETH { get; set; }
        public int USDT { get; set; }
        public int BNB { get; set; }
        public int ADA { get; set; }
        public int XRP { get; set; }
        public int DOGE { get; set; }
        public int USDC { get; set; }
        public int DOT { get; set; }
        public int LTC { get; set; }
    }
}
