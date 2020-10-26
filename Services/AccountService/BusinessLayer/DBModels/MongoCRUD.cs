using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.DBModels
{
    public class MongoCRUD
    {
        private IMongoDatabase db;
        private readonly IMongoCollection<Accounts> collection;
        public MongoCRUD(string database)
        {
            var client = new MongoClient("mongodb://localhost:40000");
            db = client.GetDatabase(database);
            collection = db.GetCollection<Accounts>("Accounts");

        }

        public string InsertAccount(AccountMessage account)
        {
            var data = new Accounts
            {
                AccountId = collection.Find<Accounts>(m=>true).Count().ToString(),
                Balance = account.Balance,
                Credits = account.Credits,
                DateRegistered = account.DateRegistered,
                FirstName = account.FirstName,
                LastName = account.LastName,
                Description = account.Description,
                Phone = account.Phone
            };
            collection.InsertOne(data);
            return "Success";
        }
        public AccountMessage GetAccount(AccountMessage data)
        {
           var account= collection.Find<Accounts>(m => m.FirstName == data.FirstName && m.LastName == data.LastName
                   || m.AccountId == data.AccountId || m.Phone == data.Phone).FirstOrDefault();

            return new AccountMessage
            {
                AccountId = account.AccountId,
                Balance = account.Balance,
                Credits = account.Credits,
                DateRegistered = account.DateRegistered,
                FirstName = account.FirstName,
                LastName = account.LastName,
                Description = account.Description,
                Phone = account.Phone
            };
        }

    }
}
