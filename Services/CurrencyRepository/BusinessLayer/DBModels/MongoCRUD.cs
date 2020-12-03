﻿using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Text;

namespace BusinessLayer.DBModels
{
    public class MongoCRUD
    {

        private IMongoDatabase db;
        private readonly IMongoCollection<Currency> collection;
        public MongoCRUD(string database)
        {
            string connectionString = @"mongodb://padlaboratories:4mX5yrfc7S8fBusF0Mo0KNNO3d0mwdNYVl03Lq5OU4UsTXo11iY4B6nXZgiEqkuvfxL99CWnLqYF7VaSATAPbg==@padlaboratories.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@padlaboratories@";

            MongoClientSettings settings = MongoClientSettings.FromUrl(
              new MongoUrl(connectionString));
            settings.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var client = new MongoClient(settings);
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
