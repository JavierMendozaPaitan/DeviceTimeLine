using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeviceTimeLine.Models.ViewModels;

namespace DeviceTimeLine.Abstractions
{
    public interface ITimeLineService
    {
        Task<DeviceTimeLineViewModel> GetDeviceTimeLineAsync();
    }
}
