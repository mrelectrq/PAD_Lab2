using System;
using System.Collections.Generic;

namespace BusinessLayer.DBModels
{
    public partial class Accounts
    {
        public Accounts()
        {
            TransactionsAccountOwner = new HashSet<Transactions>();
            TransactionsAccountReceiver = new HashSet<Transactions>();
        }

        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Balance { get; set; }
        public DateTime DateRegistered { get; set; }
        public string Phone { get; set; }
        public string Credits { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Transactions> TransactionsAccountOwner { get; set; }
        public virtual ICollection<Transactions> TransactionsAccountReceiver { get; set; }
    }
}
