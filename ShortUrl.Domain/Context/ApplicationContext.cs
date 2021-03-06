﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ShortUrl.Domain.Entities;

namespace ShortUrl.Domain.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Statistic> Statistics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(entity =>
            {
                // Base
                entity.Property(x => x.Id).ValueGeneratedNever();
                entity.Property(x => x.CreatedDate).HasColumnType("datetimeoffset").HasMaxLength(7);

                // Specific
                entity.Property(x => x.ExpiredDate).HasColumnType("datetimeoffset").HasMaxLength(7);
                entity.Property(x => x.OriginUrl).HasColumnType("varchar(max)").IsUnicode(false).IsRequired();
                entity.Property(x => x.IpAddress).HasMaxLength(50).IsUnicode(false).IsRequired();
                entity.Property(x => x.Segment).HasMaxLength(50).IsUnicode(false).IsRequired();
            });

            modelBuilder.Entity<Statistic>(entity =>
            {
                // Base
                entity.Property(x => x.Id).ValueGeneratedNever();
                entity.Property(x => x.CreatedDate).HasColumnType("datetimeoffset").HasMaxLength(7);

                // Specific
                entity.Property(x => x.ItemId).IsRequired();
                entity.Property(x => x.IpAddress).HasMaxLength(50).IsUnicode(false).IsRequired();
            });

            // unique constraint for Segment on "Item"
            modelBuilder.Entity<Item>().HasIndex(x => x.Segment).IsUnique();

            // This will singularize all table names
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.SetTableName(entityType.DisplayName());
            }
        }
    }
}