using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceTimeLine.Models
{
    public class DeviceTimeStatus
    {
        public string? Id { get; set; }
        public string? SerialNumber { get; set; }
        public DeviceStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? StartDateString { get; set; }
        public string? EndDateString { get; set; }
    }
}
