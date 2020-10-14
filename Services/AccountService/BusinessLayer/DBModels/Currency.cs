using System;
using System.Collections.Generic;

namespace BusinessLayer.DBModels
{
    public partial class Currency
    {
        public double Usd { get; set; }
        public double Eur { get; set; }
        public double Rub { get; set; }
        public double Ron { get; set; }
        public double Uah { get; set; }
        public string Type { get; set; }
    }
}
