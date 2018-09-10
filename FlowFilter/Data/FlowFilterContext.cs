using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowFilter.Models;
using Microsoft.EntityFrameworkCore;

namespace FlowFilter.Data
{
    public class FlowFilterContext : DbContext
    {
        public FlowFilterContext(DbContextOptions<FlowFilterContext> options) : base(options)
        {
            
        }
        public DbSet<AppRule> AppRules { get; set; }
        public DbSet<AppOperation> AppOperations { get; set; }
        public DbSet<AppAction> AppActions { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<BusinessLog> BusinessLogs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>().ToTable("UserInfo");
            modelBuilder.Entity<UserInfo>().HasIndex(s => s.Name).IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}
