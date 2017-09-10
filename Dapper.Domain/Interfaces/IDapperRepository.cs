using Dapper.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Domain.Interfaces
{
    public interface IDapperRepository
    {
        void Add<T>(T item) where T:class, IEntity;
        void Remove<T>(T item) where T : class, IEntity;
        void Update<T>(T item) where T : class, IEntity;
        T FindByID<T>(Guid id) where T : class, IEntity;
        IEnumerable<T> FindAll<T>() where T : class, IEntity;

    }
}
