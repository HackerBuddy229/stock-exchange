using System;
using StockExchange.Models.enums;

namespace StockExchange.Models.interfaces {

    public interface ITransaction: ISnowflake {

        public TransactionType TransactionType { get; set;}

        public ISecurity Entity { get; set; }
        public float Value { get; set; }

        public bool IsReal { get; set; }

        public string Owner { get; set; }
        public string Participant { get; set; } 

    }
    
}