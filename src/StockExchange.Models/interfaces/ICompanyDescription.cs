using System;

namespace StockExchange.Models.interfaces {

    public interface ICompanyDescription {
        public string Name { get; set; }

        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }

        public string Founder { get; set; }
    }

}