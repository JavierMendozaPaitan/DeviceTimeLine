using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace DataProvider.Abstractions
{
    public interface IMongoCollectionObject<T>
    {
        IMongoCollection<T> Collection { get; }
        IMongoDatabaseObject Database { get; }
        T SelectById(string id);
        void Insert(T obj);
        void Update(T obj);
        void Remove(T obj);
        Task<List<T>> SelectAll();
    }
}
