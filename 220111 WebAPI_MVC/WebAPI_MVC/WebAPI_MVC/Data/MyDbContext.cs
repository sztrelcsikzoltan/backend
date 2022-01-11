using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_MVC.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {

        }
        // it dbContext az ős és annak adjuk át az options-t
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // az osztályból fog csinálni egy adattáblát
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Server=localhost;database=web_api;user=root;password=;SSL MODE=none;");
            }
        }

        // osztályban melyik mezőt milyen típussal hozza létre
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // hogyan nézzen ki a User osztály Id mezője az adatbázisban
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(e => e.Property(o => o.Id).HasColumnType("int(4)").HasConversion<int>());
            modelBuilder.Entity<User>(e => e.Property(o => o.BNev).HasColumnType("varchar(40)").HasConversion<string>());
            modelBuilder.Entity<User>(e => e.Property(o => o.Jelszo).HasColumnType("varchar(32)").HasConversion<string>());
            modelBuilder.Entity<User>(e => e.Property(o => o.FNev).HasColumnType("varchar(60)").HasConversion<string>());
            modelBuilder.Entity<User>(e => e.Property(o => o.FNev).HasColumnType("varchar(60)").HasConversion<string>());
            modelBuilder.Entity<User>(e => e.Property(o => o.Jog).HasColumnType("int(1)").HasConversion<int>());
            modelBuilder.Entity<User>(e => e.Property(o => o.Aktiv).HasColumnType("int(1)").HasConversion<int>());



        }


    }
}
