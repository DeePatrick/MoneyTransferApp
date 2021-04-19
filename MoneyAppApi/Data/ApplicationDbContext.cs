using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoneyApp.Models;

namespace MoneyApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
	    public DbSet<Customer> Customers { get; set; }

        public DbSet<PayCentre> Centres { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        public DbSet<Staff> Administrators { get; set; }
        public DbSet<Transaction> Transaction{ get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

	protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Transaction>().Property(x => x.Amount).HasColumnType("decimal(20, 2)");
            builder.Entity<Transaction>().Property(x => x.BankCharge).HasColumnType("decimal(20, 2)");
            builder.Entity<PayCentre>().Property(x => x.Capital).HasColumnType("decimal(20, 2)");
        }

    }
}
