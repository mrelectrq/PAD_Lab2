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
            string connectionString =@"mongodb://padlaboratories:4mX5yrfc7S8fBusF0Mo0KNNO3d0mwdNYVl03Lq5OU4UsTXo11iY4B6nXZgiEqkuvfxL99CWnLqYF7VaSATAPbg==@padlaboratories.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@padlaboratories@";
            MongoClientSettings settings = MongoClientSettings.FromUrl(
              new MongoUrl(connectionString)
            );
            settings.SslSettings =
              new SslSettings() { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
            var client = new MongoClient(settings);
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
                   && m.AccountId == data.AccountId || m.Phone == data.Phone).FirstOrDefault();

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
