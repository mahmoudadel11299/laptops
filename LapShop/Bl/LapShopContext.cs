using Domains;
using LapShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class LapShopContext : IdentityDbContext<ApplicationUser>
    {
        public LapShopContext(DbContextOptions options) : base(options)
        {
        }

        protected LapShopContext()
        {
        }
        public virtual DbSet<Tbitem> TbItems { get; set; }
        public virtual DbSet<TbCategory> TbCategories { get; set; }
        public virtual DbSet<TbSalesInvoice> TbSalesInvoices { get; set; }
        public virtual DbSet<TbSalesInvoiceItem> TbSalesInvoiceItems { get; set; }
        public virtual DbSet<TbItemImage> TbItemImages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Tbitem>(entity => {
                entity.HasOne(a => a.category).WithMany(a => a.items).HasForeignKey(a=>a.Categoryid);
            });

            builder.Entity<TbSalesInvoiceItem>(entity => {
                entity.HasOne(a => a.salesinvoice).WithMany(a => a.salesinvoiceitems).HasForeignKey(a => a.InvoiceId);
                entity.HasOne(a => a.items).WithMany(a => a.salesinvoiceitems).HasForeignKey(a => a.ItemId);
            });
            builder.Entity<TbItemImage>(entity => {
                entity.HasOne(a => a.item).WithMany(a => a.images).HasForeignKey(a => a.ItemId);
            });
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {

            configurationBuilder.Properties<string>().HaveMaxLength(200);
            configurationBuilder.Properties<decimal>().HaveColumnType("decimal(8,2)");
            configurationBuilder.Properties<DateTime>().HaveColumnType("datetime2(7)");

        }
    }
}
