using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalsBackend.Models
{
    public class Trade
    {
        public DateTime Time { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }

        public static Trade FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Trade trade = new Trade();
            trade.Time = UnixTimeStampToDateTime(Convert.ToDouble(values[0]));
            trade.Price = Convert.ToInt32(Convert.ToDecimal(values[1]));
            trade.Amount = Convert.ToInt32(Convert.ToDecimal(values[2]));
            return trade;
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public override string ToString()
        {
            return (new { Time, Price, Amount }).ToString();
        }

    }
}