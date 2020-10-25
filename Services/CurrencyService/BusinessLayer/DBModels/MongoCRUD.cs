using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.DBModels
{
    public class MongoCRUD
    {

        private IMongoDatabase db;
        private readonly IMongoCollection<Currency> collection;
        public MongoCRUD(string database)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            db = client.GetDatabase(database);
            collection = db.GetCollection<Currency>("Currency");

        }

        public void InsertCurrency(Currency data)
        {
            data.ID = collection.Find<Currency>(m =>true).Count().ToString();
            collection.InsertOne(data);
        }
        public Currency GetCurrency(string type)
        {
            var currency = collection.Find<Currency>(m => m.Type==type).FirstOrDefault();
            
            return new Currency
            {
               Eur=currency.Eur,
               Ron=currency.Ron,
               Rub=currency.Rub,
               Uah=currency.Uah,
               Usd=currency.Usd,
               TimeCurrency=currency.TimeCurrency,
               Type=currency.Type
            };
        }
    }
}
