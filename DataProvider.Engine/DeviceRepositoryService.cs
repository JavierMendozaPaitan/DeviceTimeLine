using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProvider.Abstractions;
using DataProvider.Models;

namespace DataProvider.Engine
{
    public class DeviceRepositoryService : IDeviceRepositoryService
    {
        private readonly IMongoCollectionObject<DeviceRepository> _deviceCollection;
        public DeviceRepositoryService(
            IMongoCollectionObject<DeviceRepository> deviceCollection)
        {
            _deviceCollection = deviceCollection;
        }
        public void AddDeviceAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<DeviceRepository>> GetDevicesAsync()
        {
            var devices = await _deviceCollection.SelectAll();
            //var deviceRepository = new DeviceRepository
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    SerialNumber = "MT1234",
            //    Name = "Name",
            //    Status = DeviceStatusRepository.Initialized,
            //    CreateDate = DateTime.Now,
            //    UpdateDate = DateTime.Now,
            //};
            //await Task.Delay(10);
            return devices;
        }
    }
}
