using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProvider.Abstractions;
using MongoDB.Driver;

namespace DataProvider.Engine
{
    public class MongoDatabaseObject : IMongoDatabaseObject
    {
        private const string _dbName = "DeviceTimeLine";
        private readonly IMongoDatabase _mongoDatabase;
        private readonly IMongoClient _client;
        public MongoDatabaseObject() 
        {
            var connectionString = @"mongodb+srv://Javier_ToDo_2023:XDJwfLWBYMh0ltpS@cluster0.xkbb8.mongodb.net/";
            _client = new MongoClient(connectionString);
            _mongoDatabase = _client.GetDatabase(_dbName);
        }
        public string Name => _dbName;

        public IMongoClient Client => _client;

        public IMongoDatabase Database => _mongoDatabase;
    }
}
