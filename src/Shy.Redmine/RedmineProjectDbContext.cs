using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shy.Redmine.Dto;
using Version = Shy.Redmine.Dto.Version;

namespace Shy.Redmine
{
    internal class RedmineProjectDbContext : DbContext
    {
        public DbSet<TicketCategory> Categories { get; set; }
        public DbSet<TicketType> Types { get; set; }
        public DbSet<TicketPriority> Priorities { get; set; }
        public DbSet<TicketStatus> Statuses { get; set; }
        public DbSet<Version> Versions { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<RedmineConfiguration> Configurations { get; set; }

        public class RedmineConfigurationMapping : IEntityTypeConfiguration<RedmineConfiguration>
        {
            public void Configure(EntityTypeBuilder<RedmineConfiguration> builder)
            {
                builder.Property(e => e.BaseUri)
                    .HasConversion(v => v.ToString(), v => new Uri(v));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TicketCategory>().HasKey(e => e.Id);
            modelBuilder.Entity<TicketType>().HasKey(e => e.Id);
            modelBuilder.Entity<TicketPriority>().HasKey(e => e.Id);
            modelBuilder.Entity<TicketStatus>().HasKey(e => e.Id);
            modelBuilder.Entity<Version>().HasKey(e => e.Id);
            modelBuilder.Entity<Membership>().HasKey(e => e.Id);
            modelBuilder.ApplyConfiguration(new RedmineConfigurationMapping());
        }
    }
}