﻿// <auto-generated />
using System;
using BlockchainExplorer.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlockchainExplorer.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231017060455_InitializeDB")]
    partial class InitializeDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlockchainExplorer.Domain.Enitites.AvailableBlockchain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CoinType")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("HashId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AvailableBlockchains");
                });

            modelBuilder.Entity("BlockchainExplorer.Domain.Enitites.AvailableBlockchain", b =>
                {
                    b.OwnsOne("BlockchainExplorer.Domain.Common.BlockCypherResponse", "Response", b1 =>
                        {
                            b1.Property<int>("AvailableBlockchainId")
                                .HasColumnType("int");

                            b1.Property<string>("hash")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("height")
                                .HasColumnType("int");

                            b1.Property<int>("high_fee_per_kb")
                                .HasColumnType("int");

                            b1.Property<string>("last_fork_hash")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("last_fork_height")
                                .HasColumnType("int");

                            b1.Property<string>("latest_url")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("low_fee_per_kb")
                                .HasColumnType("int");

                            b1.Property<int>("medium_fee_per_kb")
                                .HasColumnType("int");

                            b1.Property<string>("name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("peer_count")
                                .HasColumnType("int");

                            b1.Property<string>("previous_hash")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("previous_url")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime>("time")
                                .HasColumnType("datetime2");

                            b1.Property<int>("unconfirmed_count")
                                .HasColumnType("int");

                            b1.HasKey("AvailableBlockchainId");

                            b1.ToTable("AvailableBlockchains");

                            b1.ToJson("Response");

                            b1.WithOwner()
                                .HasForeignKey("AvailableBlockchainId");
                        });

                    b.Navigation("Response")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
