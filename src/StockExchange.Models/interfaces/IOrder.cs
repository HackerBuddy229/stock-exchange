using System;

namespace StockExchange.Models.interfaces {

    public interface IOrder: ISnowflake {
        public ITransaction OfferedTransaction { get; set; }
        public TimeSpan ValidFor { get; set; }
    }
    
}