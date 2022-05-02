using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using InventoryManagmentAPI.Models;
using Microsoft.Extensions.Configuration;

namespace InventoryManagmentAPI.Models
{
    public class InvManageDBContext :DbContext
    {
        protected readonly IConfiguration Configuration;

        public InvManageDBContext(DbContextOptions<InvManageDBContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("inventorymanagmentservice");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Inventory> Inventory { get; set; } = null!;
        public DbSet<Sale> Sales { get; set; } = null!;
    }
}
