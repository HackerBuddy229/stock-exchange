using System;
using System.Collections.Generic;

namespace StockExchange.Models.interfaces {

    public interface IListed {
        public ISymbol Symbol { get; init; }

        public IList<ISecurity> Stocks { get; set; }
        public int ExistingStocksCount { get; }

        public IList<string> Owners { get; set; }
    }
}