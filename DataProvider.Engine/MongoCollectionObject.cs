using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProvider.Abstractions;
using DataProvider.Model.Abstractions;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataProvider.Engine
{
    public class MongoCollectionObject<T> : IMongoCollectionObject<T>
    {
        private readonly IMongoDatabaseObject _mongoDatabase;
        private readonly IMongoCollection<T> _collection;
        public MongoCollectionObject(
            IMongoDatabaseObject mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
            _collection = mongoDatabase.Database.GetCollection<T>(typeof(T).Name);
        }
        public IMongoCollection<T> Collection => _collection;

        public IMongoDatabaseObject Database => _mongoDatabase;

        public async void Insert(T obj)
        {
            if(obj == null) throw new ArgumentNullException(nameof(obj));

            var today = DateTime.Now;
            ((ICollectionRepository)obj).CreateDate = today;
            ((ICollectionRepository)obj).UpdateDate = today;
            ((ICollectionRepository)obj).Id = Guid.NewGuid().ToString();
            await _collection.InsertOneAsync(obj);
        }

        public async Task<List<T>> SelectAll()
        {
            var list = await _collection.FindAsync(new BsonDocument());

            return list.ToList();
        }
        
    }
}
