using BusinessLayer.DBModels;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class TransactionsImplementation
    {
        internal async Task<TransactionResponse> TransactionAction(TransactionMessage data)
        {
            try
            {
                using (var db = new PADLaboratoriesContext())
                {
                    var ownercard = db.Accounts.Find(data.AccountOwnerId);
                    ownercard.Balance -= data.Amount;
                    db.Accounts.Update(ownercard);


                    var receivercard = db.Accounts.Find(data.AccountReceiverId);
                    receivercard.Balance += data.Amount;
                    db.Accounts.Update(receivercard);


                    var transaction = new Transactions
                    {
                        AccountOwner = ownercard,
                        AccountReceiver = receivercard,
                        Currency = data.Currency,
                        Amount = data.Amount,
                        Date = DateTime.Now
                    };
                    db.Transactions.Add(transaction);

                    db.SaveChanges();
                    return new TransactionResponse
                    {
                        Status = true,
                        Message="Transaction has been successfully processed."
                    };
                }
            }
            catch(Exception ex)
            {
                return new TransactionResponse
                {
                    Status = false,
                    Message = $"{ex.Message}"
                };
            }
        }
    }
}
