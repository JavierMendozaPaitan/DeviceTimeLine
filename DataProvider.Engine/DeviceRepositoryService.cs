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
        public async Task<List<DeviceRepository>> GetDevicesAsync()
        {
            var deviceRepository = new DeviceRepository
            {
                Id = Guid.NewGuid().ToString(),
                SerialNumber = "MT1234",
                Name = "Name",
                Status = DeviceStatusRepository.Initialized,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
            };
            await Task.Delay(10);
            return new List<DeviceRepository> { deviceRepository};
        }
    }
}
