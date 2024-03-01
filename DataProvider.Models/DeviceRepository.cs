using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProvider.Model.Abstractions;

namespace DataProvider.Models
{
    public class DeviceRepository : ICollectionRepository
    {
        public string? Id { get; set; }
        public string? SerialNumber { get; set; }
        public string? Name { get; set; }
        public DeviceStatusRepository Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
