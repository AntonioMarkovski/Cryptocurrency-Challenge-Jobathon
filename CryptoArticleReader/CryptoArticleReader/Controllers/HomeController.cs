using CryptoArticleReader.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace CryptoArticleReader.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CryptoModel model)
        {
            var url = model.URL;
            using var client = new HttpClient();
            var content = await client.GetStringAsync(url);
            string myEncodedString = HttpUtility.HtmlEncode(content).ToLower();

            string[] splitcontent = content.Split("<");

            var rising = "raising";
            var falling = "falling";
            var bitcoin = "bitcoin";
            var countrising = 0;
            var countfalling = 0;
            var countbit = 0;
            var img = 0;
            var Ethereum = 0;
            var Tether = 0;
            var BinanceCoin = 0;
            var Cardano = 0;
            var XRP = 0;
            var Dogecoin = 0;
            var USDCoin = 0;
            var Polkadot = 0;
            var Uniswap = 0;
            var BinanceUSD = 0;
            var Solana = 0;
            var Litecoin = 0;

            for (int i = 0; i < splitcontent.Length; i++)
            {
                if (splitcontent[i].Contains(rising))
                {
                    countrising++;
                }
                if (splitcontent[i].Contains(falling))
                {
                    countfalling++;
                }
                if (splitcontent[i].Contains(bitcoin) || splitcontent[i].Contains("BTC" +
                    ""))
                {
                    countbit++;
                }
                if (splitcontent[i].Contains("img"))
                {
                    img++;
                }
                if (splitcontent[i].Contains("ethereum"))
                {
                    Ethereum++;
                }
                if (splitcontent[i].Contains("tether"))
                {
                    Tether++;
                }
                if (splitcontent[i].Contains("binanceCoin"))
                {
                    BinanceCoin++;
                }
                if (splitcontent[i].Contains("cardano"))
                {
                    Cardano++;
                }
                if (splitcontent[i].Contains("xrp"))
                {
                    XRP++;
                }
                if (splitcontent[i].Contains("dogecoin"))
                {
                    Dogecoin++;
                }
                if (splitcontent[i].Contains("usdcoin"))
                {
                    USDCoin++;
                }
                if (splitcontent[i].Contains("polkadot"))
                {
                    Polkadot++;
                }
                if (splitcontent[i].Contains("uniswap"))
                {
                    Uniswap++;
                }
                if (splitcontent[i].Contains("binanceusd"))
                {
                    BinanceUSD++;
                }
                if (splitcontent[i].Contains("solana"))
                {
                    Solana++;
                }
                if (splitcontent[i].Contains("litecoin"))
                {
                    Litecoin++;
                }
            }

            var resultCryptos = new CryptoModel()
            {
                Img = img,
                Negativewords = countfalling,
                Positivewords = countrising,
                BTC = countbit,
                ETH = Ethereum,
                USDT = Tether,
                BNB = BinanceCoin,
                ADA = Cardano,
                XRP = XRP,
                DOGE = Dogecoin,
                USDC = USDCoin,
                DOT = Polkadot,
                LTC = Litecoin
            };
            return View(resultCryptos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
