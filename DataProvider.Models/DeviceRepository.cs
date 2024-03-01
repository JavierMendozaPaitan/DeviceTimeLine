using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProvider.Model.Abstractions;
using MongoDB.Bson.Serialization.Attributes;

namespace DataProvider.Models
{
    public class DeviceRepository : ICollectionRepository
    {
        [BsonId]
        public string? Id { get; set; }
        public string? SerialNumber { get; set; }
        public string? Name { get; set; }
        public DeviceStatusRepository Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
