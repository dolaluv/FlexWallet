﻿// <auto-generated />
using System;
using FlexWallet.Data.Service.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlexWallet.Data.Service.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221007150025_initial migration")]
    partial class initialmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FlexWallet.Abstractions.Models.WalletFundTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AccountmNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionAccount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionAccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TransactionAmount")
                        .HasColumnType("float");

                    b.Property<string>("TransactionBankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransactionStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WalletUserAccountId")
                        .HasColumnType("int");

                    b.Property<int>("WalletUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WalletUserAccountId");

                    b.HasIndex("WalletUserId");

                    b.ToTable("WalletFundTransactions");
                });

            modelBuilder.Entity("FlexWallet.Abstractions.Models.WalletUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WalletUsers");
                });

            modelBuilder.Entity("FlexWallet.Abstractions.Models.WalletUserAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("WalletAccountBalance")
                        .HasColumnType("float");

                    b.Property<string>("WalletAccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("WalletAccountOpeningBalance")
                        .HasColumnType("float");

                    b.Property<double>("WalletAccountTotalSavedFunds")
                        .HasColumnType("float");

                    b.Property<double>("WalletAccountTotalWithdrawFunds")
                        .HasColumnType("float");

                    b.Property<int>("WalletUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WalletUserId");

                    b.ToTable("WalletUserAccounts");
                });

            modelBuilder.Entity("FlexWallet.Abstractions.Models.WalletFundTransaction", b =>
                {
                    b.HasOne("FlexWallet.Abstractions.Models.WalletUserAccount", "wallet")
                        .WithMany()
                        .HasForeignKey("WalletUserAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlexWallet.Abstractions.Models.WalletUser", "walletUser")
                        .WithMany()
                        .HasForeignKey("WalletUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("wallet");

                    b.Navigation("walletUser");
                });

            modelBuilder.Entity("FlexWallet.Abstractions.Models.WalletUserAccount", b =>
                {
                    b.HasOne("FlexWallet.Abstractions.Models.WalletUser", "walletUser")
                        .WithMany()
                        .HasForeignKey("WalletUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("walletUser");
                });
#pragma warning restore 612, 618
        }
    }
}
