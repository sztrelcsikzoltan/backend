﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI_MVC.Data;

namespace WebAPI_MVC.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("WebAPI_MVC.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(4)");

                    b.Property<int>("Aktiv")
                        .HasColumnType("int(1)");

                    b.Property<string>("BNev")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("FNev")
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Jelszo")
                        .HasColumnType("varchar(32)");

                    b.Property<int>("Jog")
                        .HasColumnType("int(1)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
