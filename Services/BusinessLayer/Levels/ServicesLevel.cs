using BusinessLayer.DBModels;
using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Levels
{
    public class ServicesLevel : ServicesImplementation, IServices
    {
        public Task<AccountResponse> GetAccount(AccountMessage account)
        {
            return AccountAction(account);
        }

        public Task<CurrencyResponse> GetCurrency()
        {
            return CurrencyAction();
        }
        public Task<TransactionResponse> GetTransaction(TransactionMessage transaction)
        {
            return TransactionAction(transaction);
        }


        public List<Transactions> SearchTransaction(int client_id)
        {
            return GetTransactions(client_id);
        }

    }
}
