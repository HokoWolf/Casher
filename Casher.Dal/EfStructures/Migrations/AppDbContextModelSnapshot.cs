﻿// <auto-generated />
using System;
using Casher.Dal.EfStructures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Casher.Dal.EfStructures.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Casher.Models.Entities.BankAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AccountBalance")
                        .HasColumnType("float")
                        .HasColumnName("account_balance");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)")
                        .HasColumnName("card_number");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("bit")
                        .HasColumnName("is_blocked");

                    b.Property<string>("PinCode")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)")
                        .HasColumnName("pin_code");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion")
                        .HasColumnName("time_stamp");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CardNumber" }, "IX_card_number")
                        .IsUnique();

                    b.ToTable("bank_accounts", null, t =>
                        {
                            t.HasCheckConstraint("CK_AccountBalance", "account_balance >= 0");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountBalance = 250.0,
                            CardNumber = "1111111111111111",
                            IsBlocked = false,
                            PinCode = "1111"
                        },
                        new
                        {
                            Id = 2,
                            AccountBalance = 0.0,
                            CardNumber = "2222222222222222",
                            IsBlocked = false,
                            PinCode = "2222"
                        },
                        new
                        {
                            Id = 3,
                            AccountBalance = 1000.0,
                            CardNumber = "3333333333333333",
                            IsBlocked = true,
                            PinCode = "3333"
                        });
                });

            modelBuilder.Entity("Casher.Models.Entities.Operation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BankAccountId")
                        .HasColumnType("int")
                        .HasColumnName("bank_account_id");

                    b.Property<double?>("MoneyAmount")
                        .HasColumnType("float")
                        .HasColumnName("money_amount");

                    b.Property<DateTime>("OperationDateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("operation_date_time");

                    b.Property<int>("OperationTypeId")
                        .HasColumnType("int")
                        .HasColumnName("operation_type_id");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion")
                        .HasColumnName("time_stamp");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "BankAccountId" }, "IX_operations_bank_account_id");

                    b.HasIndex(new[] { "OperationTypeId" }, "IX_operations_operation_type_id");

                    b.ToTable("operations", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BankAccountId = 1,
                            OperationDateTime = new DateTime(2024, 1, 30, 12, 30, 27, 0, DateTimeKind.Utc),
                            OperationTypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            BankAccountId = 2,
                            OperationDateTime = new DateTime(2024, 2, 5, 16, 15, 43, 0, DateTimeKind.Utc),
                            OperationTypeId = 1
                        },
                        new
                        {
                            Id = 3,
                            BankAccountId = 2,
                            MoneyAmount = 800.0,
                            OperationDateTime = new DateTime(2024, 2, 5, 16, 17, 58, 0, DateTimeKind.Utc),
                            OperationTypeId = 2
                        },
                        new
                        {
                            Id = 4,
                            BankAccountId = 3,
                            MoneyAmount = 2000.0,
                            OperationDateTime = new DateTime(2024, 1, 16, 4, 45, 31, 0, DateTimeKind.Utc),
                            OperationTypeId = 2
                        },
                        new
                        {
                            Id = 5,
                            BankAccountId = 3,
                            OperationDateTime = new DateTime(2024, 1, 16, 4, 49, 3, 0, DateTimeKind.Utc),
                            OperationTypeId = 1
                        });
                });

            modelBuilder.Entity("Casher.Models.Entities.OperationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion")
                        .HasColumnName("time_stamp");

                    b.HasKey("Id");

                    b.ToTable("operation_types", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Balance"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Withdraw Cash"
                        });
                });

            modelBuilder.Entity("Casher.Models.Entities.PinCodeAttempt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AttemptDateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("attempt_date_time");

                    b.Property<int>("BankAccountId")
                        .HasColumnType("int")
                        .HasColumnName("bank_account_id");

                    b.Property<bool>("IsSuccessful")
                        .HasColumnType("bit")
                        .HasColumnName("is_successful");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion")
                        .HasColumnName("time_stamp");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "BankAccountId" }, "IX_pin_code_attempts_bank_account_id");

                    b.ToTable("pin_code_attempts", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AttemptDateTime = new DateTime(2024, 1, 30, 12, 29, 9, 0, DateTimeKind.Utc),
                            BankAccountId = 1,
                            IsSuccessful = true
                        },
                        new
                        {
                            Id = 2,
                            AttemptDateTime = new DateTime(2024, 2, 5, 16, 13, 52, 0, DateTimeKind.Utc),
                            BankAccountId = 2,
                            IsSuccessful = false
                        },
                        new
                        {
                            Id = 3,
                            AttemptDateTime = new DateTime(2024, 2, 5, 16, 14, 59, 0, DateTimeKind.Utc),
                            BankAccountId = 2,
                            IsSuccessful = true
                        },
                        new
                        {
                            Id = 4,
                            AttemptDateTime = new DateTime(2024, 1, 16, 4, 43, 19, 0, DateTimeKind.Utc),
                            BankAccountId = 3,
                            IsSuccessful = true
                        },
                        new
                        {
                            Id = 5,
                            AttemptDateTime = new DateTime(2024, 2, 14, 18, 19, 23, 0, DateTimeKind.Utc),
                            BankAccountId = 3,
                            IsSuccessful = false
                        },
                        new
                        {
                            Id = 6,
                            AttemptDateTime = new DateTime(2024, 2, 14, 18, 20, 49, 0, DateTimeKind.Utc),
                            BankAccountId = 3,
                            IsSuccessful = false
                        },
                        new
                        {
                            Id = 7,
                            AttemptDateTime = new DateTime(2024, 2, 14, 18, 21, 13, 0, DateTimeKind.Utc),
                            BankAccountId = 3,
                            IsSuccessful = false
                        },
                        new
                        {
                            Id = 8,
                            AttemptDateTime = new DateTime(2024, 2, 14, 18, 22, 56, 0, DateTimeKind.Utc),
                            BankAccountId = 3,
                            IsSuccessful = false
                        });
                });

            modelBuilder.Entity("Casher.Models.Entities.Operation", b =>
                {
                    b.HasOne("Casher.Models.Entities.BankAccount", "BankAccountNavigation")
                        .WithMany("Operations")
                        .HasForeignKey("BankAccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_operations_bank_accounts");

                    b.HasOne("Casher.Models.Entities.OperationType", "OperationTypeNavigation")
                        .WithMany("Operations")
                        .HasForeignKey("OperationTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_operations_operation_types");

                    b.Navigation("BankAccountNavigation");

                    b.Navigation("OperationTypeNavigation");
                });

            modelBuilder.Entity("Casher.Models.Entities.PinCodeAttempt", b =>
                {
                    b.HasOne("Casher.Models.Entities.BankAccount", "BankAccountNavigation")
                        .WithMany("PinCodeAttempts")
                        .HasForeignKey("BankAccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_pin_code_attempts_bank_accounts");

                    b.Navigation("BankAccountNavigation");
                });

            modelBuilder.Entity("Casher.Models.Entities.BankAccount", b =>
                {
                    b.Navigation("Operations");

                    b.Navigation("PinCodeAttempts");
                });

            modelBuilder.Entity("Casher.Models.Entities.OperationType", b =>
                {
                    b.Navigation("Operations");
                });
#pragma warning restore 612, 618
        }
    }
}
