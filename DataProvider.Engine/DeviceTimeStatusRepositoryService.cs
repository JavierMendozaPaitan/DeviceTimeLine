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
        public void AddDeviceTimeStatusAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<DeviceTimeStatusRepository>> GetDeviceTimeStatusesAsync()
        {
            var deviceTimeStatuses = await _deviceTimeStatus.SelectAll();
            //var deviceTimeStatus = new DeviceTimeStatusRepository
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    SerialNumber = "MT1234",
            //    StartDate = DateTime.Now.AddDays(-1),
            //    EndDate = DateTime.Now.AddDays(1),
            //    CreateDate = DateTime.Now.AddDays(-1),
            //    UpdateDate = DateTime.Now.AddDays(-1),
            //};
            //await Task.Delay(10);

            return deviceTimeStatuses;
        }
    }
}
