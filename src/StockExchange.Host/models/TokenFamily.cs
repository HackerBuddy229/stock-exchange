namespace StockExchange.Host.models
{
    public class TokenFamily
    {
        public string AuthenticationToken { get; init; }
        public string RefreshToken { get; init; }
    }
}