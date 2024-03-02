using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceTimeLine.Models.ViewModels
{
    public class DeviceTimeLineViewModel
    {
        public List<DeviceTimeStatus> DeviceTimeLine { get; set; } = new List<DeviceTimeStatus>();
        public string? SerializedData { get; set; }
        public List<DeviceViewModel> Devices { get; set; } = new List<DeviceViewModel>();
    }
}
