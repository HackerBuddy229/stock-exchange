using System;

namespace StockExchange.Models.interfaces {

    public interface ISnowflake {
        public string Id { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}