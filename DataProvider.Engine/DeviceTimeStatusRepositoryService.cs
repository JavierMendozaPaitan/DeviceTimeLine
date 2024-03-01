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
        public async Task<List<DeviceTimeStatusRepository>> GetDeviceTimeStatusesAsync()
        {
            var deviceTimeStatus = new DeviceTimeStatusRepository
            {
                Id = Guid.NewGuid().ToString(),
                SerialNumber = "MT1234",
                StartDate = DateTime.Now.AddDays(-1),
                EndDate = DateTime.Now.AddDays(1),
                CreateDate = DateTime.Now.AddDays(-1),
                UpdateDate = DateTime.Now.AddDays(-1),
            };
            await Task.Delay(10);

            return new List<DeviceTimeStatusRepository> { deviceTimeStatus };
        }
    }
}
