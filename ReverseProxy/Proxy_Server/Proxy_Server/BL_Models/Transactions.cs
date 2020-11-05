using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proxy_Server.BL_Models
{
    public class Transactions
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
