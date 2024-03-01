using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DeviceTimeLine.Abstractions;
using DeviceTimeLine.Models.ViewModels;
using Microsoft.Extensions.Logging;

namespace DeviceTimeLine.Engine
{
    public class TimeLineService : ITimeLineService
    {
        private readonly IDeviceService _deviceService;
        private readonly ILogger<TimeLineService> _logger;
        public TimeLineService(
            ILogger<TimeLineService> logger,
            IDeviceService deviceService)
        {
            _logger = logger;
            _deviceService = deviceService;
        }
        public async Task<DeviceTimeLineViewModel> GetDeviceTimeLineAsync()
        {
            var deviceTimeLine = new DeviceTimeLineViewModel
            {
                DeviceTimeLine = await _deviceService.GetDeviceTimeStatusListAsync(),
                Devices = await _deviceService.GetDevicesAsync()
            };
            var options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            options.Converters.Add(new JsonStringEnumConverter());
            deviceTimeLine.SerializedData = JsonSerializer.Serialize(deviceTimeLine.DeviceTimeLine, options);

            return deviceTimeLine;
        }
    }
}
