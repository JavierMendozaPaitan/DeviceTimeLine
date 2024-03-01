using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceTimeLine.Models
{
    public enum DeviceStatus
    {
        Unknown,
        Initialized,
        OnTheSelf,
        InDelivery,
        Active,
        DueBack
    }
}
