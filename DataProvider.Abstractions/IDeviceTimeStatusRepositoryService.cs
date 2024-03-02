using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProvider.Models;

namespace DataProvider.Abstractions
{
    public interface IDeviceTimeStatusRepositoryService
    {
        Task<List<DeviceTimeStatusRepository>> GetDeviceTimeStatusesAsync();
        void AddDeviceTimeStatus(DeviceTimeStatusRepository deviceTimeStatus);
        void RemoveDeviceTimeStatusById(string id);
        void RemoveBySerialNumber(string serialNumber);
    }
}
