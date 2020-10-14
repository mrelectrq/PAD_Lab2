using BusinessLayer.DBModels;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementation
{
    public class AccountImplementation
    {
        internal async Task<AccountResponse> AccountAction(AccountMessage data)
        {
            try
            {
                using (var context = new PADLaboratoriesContext())
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
    }
}
