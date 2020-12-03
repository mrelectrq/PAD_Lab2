using BusinessLayer.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.DBModels
{
    public class MongoCRUD
    {
        private IMongoDatabase db;
        private readonly IMongoCollection<Transactions> collectionTrans;
        private readonly IMongoCollection<Accounts> collectionAccount;
        public MongoCRUD(string database)
        {
            string connectionString = @"mongodb://padlaboratories:4mX5yrfc7S8fBusF0Mo0KNNO3d0mwdNYVl03Lq5OU4UsTXo11iY4B6nXZgiEqkuvfxL99CWnLqYF7VaSATAPbg==@padlaboratories.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@padlaboratories@";

            var client = new MongoClient(connectionString);
            db = client.GetDatabase(database);
            collectionTrans = db.GetCollection<Transactions>("Transactions");
            collectionAccount = db.GetCollection<Accounts>("Accounts");

        }

        public bool InsertTransaction(TransactionMessage transaction)
        {
            var ownercard = collectionAccount.Find<Accounts>(m=>m.AccountId==transaction.AccountOwnerId).FirstOrDefault();
            var receivercard = collectionAccount.Find<Accounts>(m => m.AccountId == transaction.AccountReceiverId).FirstOrDefault();
            if (ownercard == null || receivercard == null)
                return false;
            else
            {
                ownercard.Balance -= transaction.Amount;

                var filter1 = Builders<Accounts>.Filter.Where(m => m.AccountId == ownercard.AccountId);
                var update1=Builders<Accounts>.Update.Set(m => m.Balance,ownercard.Balance);
                collectionAccount.UpdateOne(filter1, update1);


                receivercard.Balance += transaction.Amount;

                var filter2 = Builders<Accounts>.Filter.Where(m => m.AccountId == receivercard.AccountId);
                var update2=Builders<Accounts>.Update.Set(m => m.Balance, receivercard.Balance);
                collectionAccount.UpdateOne(filter2, update2);

                var data = new Transactions
                {

                    AccountOwnerId = transaction.AccountOwnerId,
                    AccountReceiverId = transaction.AccountReceiverId,
                    Amount = transaction.Amount,
                    Currency = transaction.Currency,
                    TransactionId = collectionTrans.Find<Transactions>(m => true).Count().ToString()
                };
                collectionTrans.InsertOne(data);

                return true;
            }
        }
      
    }
}
