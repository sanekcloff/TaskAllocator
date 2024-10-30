using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataContext
{
    public class SqlServerDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Objective> Objectives { get; set; }
        public DbSet<ObjectiveExecutor> ObjectiveExecutors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\MSSQLLocalDB; Database = TaskAllocatorDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Objective>()
                .HasOne(o => o.Creator)
                .WithMany(u => u.CreatedObjectives)
                .HasForeignKey(o => o.CreatorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ObjectiveExecutor>()
                .HasKey(oe => new { oe.ObjectiveId, oe.ExecutorId });

            modelBuilder.Entity<ObjectiveExecutor>()
                .HasOne(oe => oe.Objective)
                .WithMany(o => o.Executors)
                .HasForeignKey(oe=>oe.ObjectiveId);

            modelBuilder.Entity<ObjectiveExecutor>()
                .HasOne(oe => oe.Executor)
                .WithMany(e => e.ExecutingObjectives)
                .HasForeignKey(oe => oe.ExecutorId);
        }
    }
}
