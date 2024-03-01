using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeviceTimeLine.Models;
using DeviceTimeLine.Models.ViewModels;

namespace DeviceTimeLine.Abstractions
{
    public interface IDeviceService
    {
        Task<List<DeviceViewModel>> GetDevicesAsync();
        void CreateDeviceAsync(DeviceViewModel device);
        void DeleteDeviceAsync(string deviceId);
        Task<List<DeviceTimeStatus>> GetDeviceTimeStatusListAsync();
    }
}
