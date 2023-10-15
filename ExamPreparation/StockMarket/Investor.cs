using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enumerable = System.Linq.Enumerable;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string name, string email, decimal money, string broker)
        {
            FullName = name;
            EmailAddress = email;
            MoneyToInvest = money;
            BrokerName = broker;
            Portfolio = new List<Stock>();
        }

        private List<Stock> Portfolio;
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }

        public int Count
        {
            get => Portfolio.Count;
        }

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && MoneyToInvest >= stock.PricePerShare)
            {
                Portfolio.Add(stock);
                MoneyToInvest -= stock.PricePerShare;
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            Stock stockToSell = Portfolio.Find(x => x.CompanyName == companyName);
            if (stockToSell == null)
            {
                return $"{companyName} does not exist.";
            }

            if (sellPrice < stockToSell.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }
            Portfolio.Remove(stockToSell);
            MoneyToInvest += stockToSell.PricePerShare;
            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName) =>
            Portfolio.FirstOrDefault(x => x.CompanyName == companyName);
        public Stock FindBiggestCompany() =>
            Portfolio.OrderByDescending(x => x.MarketCapitalization).FirstOrDefault();

        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");
            foreach (var item in Portfolio)
            {
                sb.AppendLine(item.ToString().TrimEnd());
            }

            return sb.ToString().TrimEnd();
        }


    }
}
