using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Domain.Common
{
    public interface ICreatedInfo
    {
        string CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
