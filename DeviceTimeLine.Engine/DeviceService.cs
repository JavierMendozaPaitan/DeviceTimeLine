using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProvider.Abstractions;
using DataProvider.Models;
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

        public async void AddDeviceTimeStatusAsync(DeviceTimeStatus deviceTimeStatus)
        {
            if (string.IsNullOrEmpty(deviceTimeStatus.SerialNumber)) { return; }

            var deviceTimeRepository = new DeviceTimeStatusRepository
            {
                SerialNumber = deviceTimeStatus.SerialNumber,
                Status = (DeviceStatusRepository)Enum.Parse(typeof(DeviceStatusRepository), deviceTimeStatus.Status.ToString()),
                StartDate = deviceTimeStatus.StartDate,
                EndDate = deviceTimeStatus.EndDate
            };

            await Task.Run(() => _deviceTimeStatusService.AddDeviceTimeStatus(deviceTimeRepository));
        }

        public async void CreateDeviceAsync(DeviceViewModel device)
        {
            if(string.IsNullOrEmpty(device.SerialNumber)) { return; }

            var deviceRepository = new DeviceRepository
            {
                 SerialNumber = device.SerialNumber,
                 Name = device.DeviceName,
                 Status = (DeviceStatusRepository)Enum.Parse(typeof(DeviceStatusRepository), device.CurrentStatus.ToString())                 
            };

            await Task.Run(()=>_deviceRepositoryService.AddDevice(deviceRepository));
        }

        public void DeleteDeviceAndTimeStatusAsync(string deviceId, string deviceSerialNumber)
        {
            if (string.IsNullOrEmpty(deviceId) || string.IsNullOrEmpty(deviceSerialNumber)) { return; }

            _deviceRepositoryService.RemoveDeviceById(deviceId);
            _deviceTimeStatusService.RemoveBySerialNumber(deviceSerialNumber);
        }

        public async void DeleteDeviceAsync(string deviceId)
        {
            if(string.IsNullOrEmpty(deviceId)) return;

            await Task.Run(() => _deviceRepositoryService.RemoveDeviceById(deviceId));
        }

        public async void DeleteDeviceTimeStatusAsync(string deviceTimeStatusId)
        {
            if (string.IsNullOrEmpty(deviceTimeStatusId)) return;

            await Task.Run(() => _deviceTimeStatusService.RemoveDeviceTimeStatusById(deviceTimeStatusId));
        }

        public async Task<List<DeviceViewModel>> GetDevicesAsync()
        {
            var deviceViewList = new List<DeviceViewModel>();
            var deviceList = await _deviceRepositoryService.GetDevicesAsync();
            deviceList.ForEach(device =>
            {
                var deviceViewModel = new DeviceViewModel
                {
                    Id = device.Id,
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
                    Id = device.Id,
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
