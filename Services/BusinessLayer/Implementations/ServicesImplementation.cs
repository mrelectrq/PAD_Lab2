using BusinessLayer.DBModels;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class ServicesImplementation
    {
        internal async Task<AccountResponse> AccountAction(AccountMessage data)
        {
            try
            {
                using (var context = new PadLaboratoriesContext())
                {
                    var account = context.Accounts.FirstOrDefault(m => m.FirstName == data.FirstName && m.LastName == data.LastName
                   || m.AccountId == data.AccountId || m.Phone == data.Phone);
                    if (account == null)
                    {
                        return new AccountResponse
                        {
                            Status = false,
                            Message = "Account doesn't exist.",
                            Account = null
                        };
                    }
                    else
                    {
                        var dataAccount = new AccountMessage();
                        dataAccount.AccountId = account.AccountId;
                        dataAccount.FirstName = account.FirstName;
                        dataAccount.LastName = account.LastName;
                        dataAccount.Phone = account.Phone;
                        dataAccount.DateRegistered = account.DateRegistered;
                        dataAccount.Balance = account.Balance;
                        dataAccount.Credits = account.Credits;
                        dataAccount.Description = account.Description;

                        return new AccountResponse
                        {
                            Status = true,
                            Account = dataAccount,
                            Message = $"Account {data.AccountId} exists!"
                        };
                    }
                }
            }
            catch (Exception e)
            {
                return new AccountResponse
                {
                    Status = false,
                    Message = e.Message,
                    Account = null
                };
            }
        }
        internal async Task<CurrencyResponse> CurrencyAction()
        {
            try
            {
                using (var db = new PadLaboratoriesContext())
                {
                    var sellCurrency = db.Currency.FirstOrDefault(x => x.Type == "Sell");
                    var buyCurrency = db.Currency.FirstOrDefault(x => x.Type == "Buy");
                    if (sellCurrency == null && buyCurrency == null)
                    {
                        return new CurrencyResponse
                        {
                            Message = "ERROR! Currencies are null",
                            Time = DateTime.Now
                        };
                    }
                    else
                    {
                        var sell = new CurrencyItems
                        {
                            Eur = sellCurrency.Eur,
                            Ron = sellCurrency.Ron,
                            Rub = sellCurrency.Rub,
                            Usd = sellCurrency.Usd,
                            Uah = sellCurrency.Uah,
                            Type = sellCurrency.Type,
                            TimeCurrency = sellCurrency.TimeCurrency
                        };
                        var buy = new CurrencyItems
                        {
                            Eur = buyCurrency.Eur,
                            Ron = buyCurrency.Ron,
                            Rub = buyCurrency.Rub,
                            Usd = buyCurrency.Usd,
                            Uah = buyCurrency.Uah,
                            Type = buyCurrency.Type,
                            TimeCurrency = buyCurrency.TimeCurrency
                        };
                        return new CurrencyResponse
                        {
                            BuyCurrency = buy,
                            SellCurrency = sell,
                            Time = DateTime.Now,
                            Message = "Currency was updated successfully!"
                        };

                    }
                }

            }
            catch (Exception ex)
            {
                return new CurrencyResponse
                {
                    Message = $"ERROR! {ex.Message}",
                    Time = DateTime.Now
                };

            }
        }
        internal async Task<TransactionResponse> TransactionAction(TransactionMessage data)
        {
            try
            {
                using (var db = new PadLaboratoriesContext())
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
                        Message = "Transaction has been successfully processed."
                    };
                }
            }
            catch (Exception ex)
            {
                return new TransactionResponse
                {
                    Status = false,
                    Message = $"{ex.Message}"
                };
            }
        }


        internal List<Transactions> GetTransactions(int client_id)
        {
             using(var context = new PadLaboratoriesContext())
            {

                var data = context.Transactions.Where(m => m.AccountOwnerId == client_id).ToList();

                var owner = context.Accounts.Where(m => m.AccountId == data[0].AccountOwnerId)
                    .Select(m => new Accounts { FirstName = m.FirstName, LastName = m.LastName, Balance = m.Balance, DateRegistered = m.DateRegistered, Phone = m.Phone })
                .FirstOrDefault();
                var receiver = context.Accounts.Where(m => m.AccountId == data[0].AccountOwnerId)
                    .Select(m => new Accounts { FirstName = m.FirstName, LastName = m.LastName, Balance = m.Balance, DateRegistered = m.DateRegistered, Phone = m.Phone })
                  .FirstOrDefault();


                for (int i = 1; i < data.Count; i++)
                {
                    data[i].AccountOwner = owner;
                    data[i].AccountReceiver = receiver;
                }
                return data;
            }
            
        }
    }
}
