using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace StockMarket
{
    public class Stock
    {
        public Stock(string name, string director, decimal pricePerShare, int totalShares)
        {
            CompanyName = name;
            Director = director;
            PricePerShare = pricePerShare;
            TotalNumberOfShares = totalShares;
            MarketCapitalization = totalShares * pricePerShare;
        }
        public string CompanyName { get; set; }
        public string Director { get; set; }
        public decimal PricePerShare { get; set; }
        public int TotalNumberOfShares { get; set; }
        public decimal MarketCapitalization { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Company: {CompanyName}");
            sb.AppendLine($"Director: {Director}");
            sb.AppendLine($"Price per share: ${PricePerShare}");
            sb.AppendLine($"Market capitalization: ${MarketCapitalization}");

            return sb.ToString().TrimEnd();
        }
    }
}
