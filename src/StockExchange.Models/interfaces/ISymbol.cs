namespace StockExchange.Models.interfaces {

    public interface ISymbol: ISnowflake {
        public string Symbol { get; set; }
    }

}