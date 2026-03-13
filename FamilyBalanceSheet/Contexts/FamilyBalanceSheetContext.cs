// SPDX-FileCopyrightText: 2026 Tayra Sakurai
// 
// SPDX-License-Identifier: AGPL-3.0-or-later

using FamilyBalanceSheet.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyBalanceSheet.Contexts
{
    public class FamilyBalanceSheetContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Request> Requests { get; set; }

        public FamilyBalanceSheetContext(DbContextOptions<FamilyBalanceSheetContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().ToTable("Items");
            modelBuilder.Entity<Manager>().ToTable("Managers");
            modelBuilder.Entity<Request>().ToTable("Requests");
        }
    }
}
