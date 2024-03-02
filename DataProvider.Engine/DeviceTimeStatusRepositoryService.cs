using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProvider.Abstractions;
using DataProvider.Models;
using MongoDB.Driver;

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

        public async void RemoveBySerialNumber(string serialNumber)
        {
            if (string.IsNullOrEmpty(serialNumber)) throw new ArgumentNullException(serialNumber);
            var filter = Builders<DeviceTimeStatusRepository>.Filter.Eq(x => x.SerialNumber, serialNumber);
            await _deviceTimeStatus.Collection.DeleteManyAsync(filter);
        }

        public async void RemoveDeviceTimeStatusById(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(id);
            var filter = Builders<DeviceTimeStatusRepository>.Filter.Eq(x => x.Id, id);
            await _deviceTimeStatus.Collection.DeleteOneAsync(filter);
        }
    }
}
