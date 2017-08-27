using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MVCDemo.DataAccess.Entities;
using MVCDemo.DataAccess.Models;

namespace MVCDemo.Migrations
{
    [DbContext(typeof(AwesomeCarDbContext))]
    partial class AwesomeCarDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MVCDemo.DataAccess.Models.AwesomeCar", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BrandName");

                    b.Property<string>("CarName");

                    b.Property<int>("MileAge");

                    b.Property<int>("producerCountry");

                    b.HasKey("CarId");

                    b.ToTable("AwesomeCars");
                });
        }
    }
}
