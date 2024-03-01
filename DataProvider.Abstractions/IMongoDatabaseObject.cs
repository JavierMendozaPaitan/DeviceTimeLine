using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace DataProvider.Abstractions
{
    public interface IMongoDatabaseObject
    {
        string Name { get; }
        IMongoClient Client { get; }
        IMongoDatabase Database { get; }
    }
}
