 using BusinessLayer.DBModels;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
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
                MongoCRUD context = new MongoCRUD("PADLaboratories");

                //var insert = context.InsertAccount(data);
               var account = context.GetAccount(data);
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
                    return new AccountResponse
                    {
                        Status = true,
                        Account = account,
                        Message = $"Account {data.AccountId} exists!"
                    };
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
