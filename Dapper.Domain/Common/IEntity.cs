using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Domain.Common
{
    public interface IEntity {
        object id { get; set;}
    }
    public interface IEntity<T> :IEntity
    {
        new T Id { get; set; }
    }

}
