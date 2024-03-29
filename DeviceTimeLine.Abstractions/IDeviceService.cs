﻿using System;
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
        void DeleteDeviceAndTimeStatusAsync(string deviceId, string deviceSerialNumber);
        Task<List<DeviceTimeStatus>> GetDeviceTimeStatusListAsync();
        void AddDeviceTimeStatusAsync(DeviceTimeStatus deviceTimeStatus);
        void DeleteDeviceTimeStatusAsync(string deviceTimeStatusId);
    }
}
