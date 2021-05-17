﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Notifications_DAL.Database;

namespace Notifications_DAL.Migrations
{
    [DbContext(typeof(NotificationsContext))]
    partial class NotificationsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Notifications_DAL.Models.Keys", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Auth")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("auth");

                    b.Property<string>("P256dh")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("p256dh");

                    b.HasKey("Id");

                    b.ToTable("keys");
                });

            modelBuilder.Entity("Notifications_DAL.Models.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Endpoint")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("endpoint");

                    b.Property<float?>("ExpirationTime")
                        .HasColumnType("real")
                        .HasColumnName("expirationTime");

                    b.Property<int>("KeysId")
                        .HasColumnType("int")
                        .HasColumnName("keys_id");

                    b.HasKey("Id");

                    b.HasIndex("KeysId");

                    b.HasIndex(new[] { "Endpoint" }, "UQ__subscrip__00C5A355188809D9")
                        .IsUnique();

                    b.ToTable("subscriptions");
                });

            modelBuilder.Entity("Notifications_DAL.Models.Subscription", b =>
                {
                    b.HasOne("Notifications_DAL.Models.Keys", "Keys")
                        .WithMany("Subscriptions")
                        .HasForeignKey("KeysId")
                        .HasConstraintName("FK_subscriptions_keys")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Keys");
                });

            modelBuilder.Entity("Notifications_DAL.Models.Keys", b =>
                {
                    b.Navigation("Subscriptions");
                });
#pragma warning restore 612, 618
        }
    }
}
