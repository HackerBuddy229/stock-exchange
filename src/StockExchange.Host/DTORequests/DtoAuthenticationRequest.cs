namespace StockExchange.Host.DTORequests
{
    public class DtoAuthenticationRequest
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public bool CreateRefreshToken { get; set; }
    }
}