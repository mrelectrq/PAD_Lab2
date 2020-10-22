using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class TransactionMessage
    {
        public int AccountOwnerId { get; set; }
        public int AccountReceiverId { get; set; }
        public string Currency { get; set; }
        public double Amount { get; set; }

    }
}
