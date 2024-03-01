﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceTimeLine.Models.ViewModels
{
    public class DeviceViewModel
    {
        public string? SerialNumber { get; set; }
        public string? DeviceName { get; set; }
        public DeviceStatus CurrentStatus { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}