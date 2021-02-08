using System.Collections.Generic;
using System.Linq;

namespace StockExchange.Host.mediatr.responses
{
    public class ResponseWrapper<T>
    {
        public bool Succeeded => !Errors.Any();
        public IList<string> Errors { get; init; }= new List<string>();
        public T WorkProduct { get; init; }
    }
}