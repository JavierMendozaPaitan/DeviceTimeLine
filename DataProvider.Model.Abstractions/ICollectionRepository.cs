using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider.Model.Abstractions
{
    public interface ICollectionRepository
    {
        string? Id { get; set; }
        string? SerialNumber { get; set; }
        DateTime CreateDate { get; set; }
        DateTime UpdateDate { get; set; }
    }
}
