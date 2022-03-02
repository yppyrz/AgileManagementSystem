﻿using AgileManagementSystem.Domain.Models;
using AgileManagementSystem.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Persistence.EFCore.Contexts
{
    /// <summary>
    /// Katmanlı mimari ile çalışırken ilgili katmandan migration alma işlemlerinde UserDbContextFactory ile dbContext ayağa kaldırılır. 
    /// Microsoft.EntityFrameworkCore.Design katmanlı mimaride bu paketi indirelim ve aşağıdaki gibi DbContext class olduğu yere IDesignTimeDbContextFactory implemente olan bir FactoryContext yazalım 
    /// ilgili proje katmanını seçip migration uygularız.
    /// </summary>
    public class UserDbContextFactory : IDesignTimeDbContextFactory<UserDbContext>
    {
        public UserDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UserDbContext>();
            optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=AgileManagementDb;Trusted_Connection=true");

            return new UserDbContext(optionsBuilder.Options);
        }
    }

    public class UserDbContext:DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<ApplicationUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Migration işleminde kullanılacak konfigürasyon.
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
