using grpahQL_initial.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grpahQL_initial.Data
{
    public class ApiDbContext : DbContext
    {
        public virtual DbSet<ItemData> HolidayMasters { get; set; }
        //public virtual DbSet<ItemList> Lists { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ItemData>(entity =>
            {
                //entity.ToTable("HolidayMaster");
                

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.HolidayName)
                    .IsRequired()
                    .HasMaxLength(50);

            });
        }
    }
}
