using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using Dapper.Domain.Entities;

namespace Dapper.Infrastructure
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions options) : base(options)
        {

        }

        protected EFDbContext()
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Address { get; set; }
    }
}
