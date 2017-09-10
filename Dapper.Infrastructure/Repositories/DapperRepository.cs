using Dapper;
using Dapper.Domain.Common;
using Dapper.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Dapper.Infrastructure.Repositories
{
    public class DapperRepository<TContext> : IDapperRepository
        where TContext : DbContext 
    {
        protected readonly TContext context;

        public DapperRepository(TContext context)
        {
            this.context = context;
        }
        internal IDbConnection Connection
        {
            get
            {
                return new SqlConnection(context.Database.GetDbConnection().ConnectionString);
            }
        }
        internal virtual dynamic Mapping<T>(T item)
        {
            return item;
        }

        private string GetTableNameAttribute<TEntity>()
        {
            var _tableName = typeof(TEntity).Name;

            IEnumerable<Attribute> attrs = typeof(TEntity).GetTypeInfo().GetCustomAttributes();  // Reflection.

            // Displaying output.
            foreach (System.Attribute attr in attrs)
            {
                if (attr is System.ComponentModel.DataAnnotations.Schema.TableAttribute)
                {
                    System.ComponentModel.DataAnnotations.Schema.TableAttribute _tableAttribute = (System.ComponentModel.DataAnnotations.Schema.TableAttribute)attr;
                    return _tableAttribute.Name;
                }
            }
            return _tableName;

        }

        public void Add<T>(T item) where T : class, IEntity
        {
            var _tableName = GetTableNameAttribute<T>();
            using (IDbConnection cn = Connection)
            {
                var parameters = (object)Mapping(item);
                cn.Open();
                item.id = cn.Query<object>(_tableName, parameters);
            }
        }

        public virtual void Update<T>(T item) where T : class, IEntity
        {
            var _tableName = GetTableNameAttribute<T>();
            using (IDbConnection cn = Connection)
            {
                var parameters = (object)Mapping(item);
                cn.Open();
                cn.Query(_tableName, parameters);
            }
        }

        public virtual void Remove<T>(T item) where T : class, IEntity
        {
            var _tableName = GetTableNameAttribute<T>();
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                cn.Execute("DELETE FROM " + _tableName + " WHERE ID=@ID", new { ID = item.ID });
            }
        }

        public virtual T FindByID<T>(Guid id) where T : class, IEntity
        {
            var _tableName = GetTableNameAttribute<T>();
            T item = default(T);

            using (IDbConnection cn = Connection)
            {
                cn.Open();
                item = cn.Query<T>("SELECT * FROM " + _tableName + " WHERE ID=@ID", new { ID = id }).SingleOrDefault();
            }

            return item;
        }


        public virtual IEnumerable<T> FindAll<T>() where T : class, IEntity
        {
            var _tableName = GetTableNameAttribute<T>();
            IEnumerable<T> items = null;

            using (IDbConnection cn = Connection)
            {
                cn.Open();
                items = cn.Query<T>("SELECT * FROM " + _tableName);
            }

            return items;
        }

    }

}
}
