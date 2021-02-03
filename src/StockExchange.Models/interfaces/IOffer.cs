using System;

namespace StockExchange.Models.interfaces {

    public interface IOffer: ISnowflake {
        public ITransaction OfferedTransaction { get; set; }
        public TimeSpan ValidFor { get; set; }
    }
    
}