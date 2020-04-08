using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using SignalsBackend.Models;
using System.IO;

namespace SignalsBackend.Data
{
    public sealed class BitcoinData
    {
        private static BitcoinData instance = null;
        private static readonly object padlock = new object();
        private static DateTime lastCall = new DateTime();
        private static Trade[] ChartData = new Trade[] { };
        private static string url = "http://api.bitcoincharts.com/v1/trades.csv?symbol=krakenUSD";
        private static string urlParameters = "?api_key=123";

        BitcoinData()
        {
        }

        public static BitcoinData Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new BitcoinData();
                    }
                    return instance;
                }
            }
        }

        public Trade[] GetData
        {
            get
            {
                if (DateTime.Now < lastCall.AddMinutes(15))
                {
                    return ChartData;
                }
                else
                {
                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage response = client.GetAsync(url).Result;
                        //nesekmes atveju error..
                        response.EnsureSuccessStatusCode();
                        //responsas to string
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        lastCall = DateTime.Now;
                        ChartData = responseBody.Split("\n").Select(v => Trade.FromCsv(v)).ToArray();
                        return ChartData;
                    }
                }
            }
        }

    }
}
