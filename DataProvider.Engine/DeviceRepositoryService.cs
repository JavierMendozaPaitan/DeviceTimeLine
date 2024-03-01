﻿using System;
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
        public void AddDevice(DeviceRepository device)
        {
            _deviceCollection.Insert(device);
        }

        public async Task<List<DeviceRepository>> GetDevicesAsync()
        {
            var devices = await _deviceCollection.SelectAll();

            return devices;
        }

        public void RemoveDevice(DeviceRepository device)
        {
            _deviceCollection.Remove(device);
        }
    }
}
