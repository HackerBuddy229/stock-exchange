using System;

namespace StockExchange.Models.interfaces {

    public interface ISecurity: ISnowflake{
        public int Amount { get; set; }
        public ISymbol Symbol { get; set; }
    }
    
}