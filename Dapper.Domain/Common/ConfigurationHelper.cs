using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Dapper.Domain.Common
{
    public class ConfigurationHelper
    {
        private readonly IConfiguration _config;
        public ConfigurationHelper(IConfiguration config) {
            _config = config;
        }
        internal IDbConnection DbConnection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DapperDbConnectingString"));
            }
        }
    }
}
