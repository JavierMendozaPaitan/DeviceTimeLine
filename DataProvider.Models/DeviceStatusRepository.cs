using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider.Models
{
    public enum DeviceStatusRepository
    {
        Unknown,
        Initialized,
        OnTheSelf,
        InDelivery,
        Active,
        DueBack
    }
}
