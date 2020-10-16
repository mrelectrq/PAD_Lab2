using System;
using System.Collections.Generic;

namespace BusinessLayer.DBModels
{
    public partial class Transactions
    {
        public int TransactionId { get; set; }
        public int AccountOwnerId { get; set; }
        public int AccountReceiverId { get; set; }
        public DateTime Date { get; set; }
        public string Currency { get; set; }
        public double Amount { get; set; }

        public virtual Accounts AccountOwner { get; set; }
        public virtual Accounts AccountReceiver { get; set; }
    }
}
