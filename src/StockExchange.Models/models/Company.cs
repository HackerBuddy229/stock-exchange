using System;
using System.Collections.Generic;
using StockExchange.Models.interfaces;

namespace StockExchange.Models.models
{

    public class Company : ICompany
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        
        public string Founder { get; set; }
        public ISymbol Symbol { get; init; }
        
        public IList<ISecurity> Stocks { get; set; }
        public int ExistingStocksCount => Stocks.Count;

        public IList<string> Owners { get; set; }

        public string Id { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}