﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProvider.Abstractions;
using DeviceTimeLine.Abstractions;
using DeviceTimeLine.Models;
using DeviceTimeLine.Models.ViewModels;
using Microsoft.Extensions.Logging;

namespace DeviceTimeLine.Engine
{
    public class DeviceService : IDeviceService
    {
        private readonly ILogger<DeviceService> _logger;
        private readonly IDeviceRepositoryService _deviceRepositoryService;
        private readonly IDeviceTimeStatusRepositoryService _deviceTimeStatusService;
        public DeviceService(
            ILogger<DeviceService> logger,
            IDeviceRepositoryService deviceRepositoryService,
            IDeviceTimeStatusRepositoryService deviceTimeStatusService)
        {
            _logger = logger;
            _deviceRepositoryService = deviceRepositoryService;
            _deviceTimeStatusService = deviceTimeStatusService;
        }
        public async Task<List<DeviceViewModel>> GetDevicesAsync()
        {
            var deviceViewList = new List<DeviceViewModel>();
            var deviceList = await _deviceRepositoryService.GetDevicesAsync();
            deviceList.ForEach(device =>
            {
                var deviceViewModel = new DeviceViewModel
                {
                    SerialNumber = device.SerialNumber,
                    DeviceName = device.Name,
                    CurrentStatus = (DeviceStatus)Enum.Parse( typeof(DeviceStatus), device.Status.ToString()),
                    LastUpdateDate = device.UpdateDate
                };
                deviceViewList.Add(deviceViewModel);
            });

            return deviceViewList;
        }

        public async Task<List<DeviceTimeStatus>> GetDeviceTimeStatusListAsync()
        {
            var deviceTimeStatusList = new List<DeviceTimeStatus>();
            var deviceTimeList = await _deviceTimeStatusService.GetDeviceTimeStatusesAsync();
            deviceTimeList.ForEach(device =>
            {
                var deviceTimeStatus = new DeviceTimeStatus
                {
                    SerialNumber= device.SerialNumber,
                    Status = (DeviceStatus)Enum.Parse(typeof(DeviceStatus), device.Status.ToString()),
                    StartDate = device.StartDate,
                    EndDate = device.EndDate,
                    StartDateString = device.StartDate.ToString("yyyy-MM-ddTHH:mm:ss"),
                    EndDateString = device.EndDate.ToString("yyyy-MM-ddTHH:mm:ss")
                };
                deviceTimeStatusList.Add(deviceTimeStatus);
            });

            return deviceTimeStatusList;
        }
    }
}