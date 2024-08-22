﻿// <auto-generated />
using System;
using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExpenseTracker.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ExpenseTracker.Models.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("ExpenseTracker.Models.Entities.Expense", b =>
                {
                    b.Property<int>("ExpenseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExpenseId"), 1L, 1);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double?>("ExpenseAmount")
                        .IsRequired()
                        .HasColumnType("float");

                    b.Property<DateTime>("ExpenseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExpenseDescription")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("ExpenseGroupId")
                        .HasColumnType("int");

                    b.Property<string>("ExpenseName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ExpenseId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("ExpenseGroupId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("ExpenseTracker.Models.Entities.ExpenseGroup", b =>
                {
                    b.Property<int>("ExpenseGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExpenseGroupId"), 1L, 1);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double?>("ExpenseGroupBudgetCap")
                        .HasColumnType("float");

                    b.Property<string>("ExpenseGroupDescription")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ExpenseGroupName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ExpenseGroupId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("ExpenseGroups");
                });

            modelBuilder.Entity("ExpenseTracker.Models.Entities.Income", b =>
                {
                    b.Property<int>("IncomeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IncomeId"), 1L, 1);

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double?>("IncomeAmount")
                        .IsRequired()
                        .HasColumnType("float");

                    b.Property<DateTime?>("IncomeDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("IncomeDescription")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("IncomeGroupId")
                        .HasColumnType("int");

                    b.Property<string>("IncomeName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IncomeId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("IncomeGroupId");

                    b.ToTable("Incomes");
                });

            modelBuilder.Entity("ExpenseTracker.Models.Entities.IncomeGroup", b =>
                {
                    b.Property<int>("IncomeGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IncomeGroupId"), 1L, 1);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IncomeGroupDescription")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("IncomeGroupName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IncomeGroupId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("IncomeGroups");
                });

            modelBuilder.Entity("ExpenseTracker.Models.Entities.Reminder", b =>
                {
                    b.Property<int>("ReminderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReminderId"), 1L, 1);

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DayOfMonth")
                        .HasColumnType("int");

                    b.Property<int?>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<int>("Hour")
                        .HasColumnType("int");

                    b.Property<int>("Minute")
                        .HasColumnType("int");

                    b.Property<int>("ReminderType")
                        .HasColumnType("int");

                    b.Property<DateTime>("ScheduledTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ReminderId");

                    b.ToTable("Reminders");
                });

            modelBuilder.Entity("ExpenseTracker.Models.Entities.ScheduledExpense", b =>
                {
                    b.Property<int>("ScheduledExpenseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduledExpenseId"), 1L, 1);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ExpenseGroupId")
                        .HasColumnType("int");

                    b.Property<bool>("IsRecurring")
                        .HasColumnType("bit");

                    b.Property<double?>("ScheduledExpenseAmount")
                        .IsRequired()
                        .HasColumnType("float");

                    b.Property<DateTime?>("ScheduledExpenseDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("ScheduledExpenseDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ScheduledExpenseName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ScheduledExpenseId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("ScheduledExpenses");
                });

            modelBuilder.Entity("ExpenseTracker.Models.Entities.ScheduledIncome", b =>
                {
                    b.Property<int>("ScheduledIncomeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduledIncomeId"), 1L, 1);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("IncomeGroupId")
                        .HasColumnType("int");

                    b.Property<bool>("IsRecurring")
                        .HasColumnType("bit");

                    b.Property<double?>("ScheduledIncomeAmount")
                        .IsRequired()
                        .HasColumnType("float");

                    b.Property<DateTime?>("ScheduledIncomeDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("ScheduledIncomeDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ScheduledIncomeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ScheduledIncomeId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("ScheduledIncomes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ExpenseTracker.Models.Entities.Expense", b =>
                {
                    b.HasOne("ExpenseTracker.Models.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("Expenses")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("ExpenseTracker.Models.Entities.ExpenseGroup", "ExpenseGroup")
                        .WithMany()
                        .HasForeignKey("ExpenseGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("ExpenseGroup");
                });

            modelBuilder.Entity("ExpenseTracker.Models.Entities.ExpenseGroup", b =>
                {
                    b.HasOne("ExpenseTracker.Models.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("ExpenseGroups")
                        .HasForeignKey("ApplicationUserId");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("ExpenseTracker.Models.Entities.Income", b =>
                {
                    b.HasOne("ExpenseTracker.Models.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("Incomes")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExpenseTracker.Models.Entities.IncomeGroup", "IncomeGroup")
                        .WithMany("Incomes")
                        .HasForeignKey("IncomeGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("IncomeGroup");
                });

            modelBuilder.Entity("ExpenseTracker.Models.Entities.IncomeGroup", b =>
                {
                    b.HasOne("ExpenseTracker.Models.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("IncomeGroups")
                        .HasForeignKey("ApplicationUserId");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("ExpenseTracker.Models.Entities.ScheduledExpense", b =>
                {
                    b.HasOne("ExpenseTracker.Models.Entities.ApplicationUser", null)
                        .WithMany("ScheduledExpenses")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("ExpenseTracker.Models.Entities.ScheduledIncome", b =>
                {
                    b.HasOne("ExpenseTracker.Models.Entities.ApplicationUser", null)
                        .WithMany("ScheduledIncomes")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ExpenseTracker.Models.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ExpenseTracker.Models.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExpenseTracker.Models.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ExpenseTracker.Models.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ExpenseTracker.Models.Entities.ApplicationUser", b =>
                {
                    b.Navigation("ExpenseGroups");

                    b.Navigation("Expenses");

                    b.Navigation("IncomeGroups");

                    b.Navigation("Incomes");

                    b.Navigation("ScheduledExpenses");

                    b.Navigation("ScheduledIncomes");
                });

            modelBuilder.Entity("ExpenseTracker.Models.Entities.IncomeGroup", b =>
                {
                    b.Navigation("Incomes");
                });
#pragma warning restore 612, 618
        }
    }
}
