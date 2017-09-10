using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Dapper.Infrastructure;

namespace Dapper.Infrastructure.Migrations
{
    [DbContext(typeof(EFDbContext))]
    [Migration("20170910144508_Initial_3")]
    partial class Initial_3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dapper.Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompleteAddress");

                    b.Property<int>("ContactId");

                    b.Property<string>("StreetAddress");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Dapper.Domain.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Dapper.Domain.Entities.Address", b =>
                {
                    b.HasOne("Dapper.Domain.Entities.Contact", "Contact")
                        .WithMany("Addresses")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
