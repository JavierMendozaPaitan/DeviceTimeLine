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
        void Insert(T obj);
        Task<List<T>> SelectAll();
    }
}
