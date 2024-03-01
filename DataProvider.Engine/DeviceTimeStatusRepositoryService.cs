using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProvider.Abstractions;
using DataProvider.Models;

namespace DataProvider.Engine
{
    public class DeviceTimeStatusRepositoryService : IDeviceTimeStatusRepositoryService
    {
        private readonly IMongoCollectionObject<DeviceTimeStatusRepository> _deviceTimeStatus;
        public DeviceTimeStatusRepositoryService(
            IMongoCollectionObject<DeviceTimeStatusRepository> deviceTimeStatus)
        {
            _deviceTimeStatus = deviceTimeStatus;
        }
        public void AddDeviceTimeStatus(DeviceTimeStatusRepository deviceTimeStatus)
        {
            _deviceTimeStatus.Insert(deviceTimeStatus);
        }

        public async Task<List<DeviceTimeStatusRepository>> GetDeviceTimeStatusesAsync()
        {
            var deviceTimeStatuses = await _deviceTimeStatus.SelectAll();

            return deviceTimeStatuses;
        }
    }
}
