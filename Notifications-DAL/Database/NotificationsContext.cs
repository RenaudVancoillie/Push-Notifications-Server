using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Notifications_DAL.Models;

#nullable disable

namespace Notifications_DAL.Database
{
    public partial class NotificationsContext : DbContext
    {
        public NotificationsContext()
        {
        }

        public NotificationsContext(DbContextOptions<NotificationsContext> options,
                                    IConfiguration Configuration)
            : base(options)
        {
            this.Configuration = Configuration;
        }

        public virtual DbSet<Keys> Keys { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public IConfiguration Configuration { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Default"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Keys>(entity =>
            {
                entity.ToTable("keys");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Auth)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("auth");

                entity.Property(e => e.P256hd)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("p256hd");
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.ToTable("subscriptions");

                entity.HasIndex(e => e.Endpoint, "UQ__subscrip__00C5A355188809D9")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Endpoint)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("endpoint");

                entity.Property(e => e.ExpirationTime).HasColumnName("expirationTime");

                entity.Property(e => e.KeysId).HasColumnName("keys_id");

                entity.HasOne(d => d.Keys)
                    .WithMany(p => p.Subscriptions)
                    .HasForeignKey(d => d.KeysId)
                    .OnDelete(DeleteBehavior.ClientCascade)
                    .HasConstraintName("FK_subscriptions_keys");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
