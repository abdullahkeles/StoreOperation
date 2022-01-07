﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreOperation.WebApi.Data.Contexts;

namespace StoreOperation.WebApi.Migrations
{
    [DbContext(typeof(StoreOperationDbContext))]
    [Migration("20210919183743_upp-v01")]
    partial class uppv01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AppRoleAppUser", b =>
                {
                    b.Property<Guid>("RolesRoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RolesRoleId", "UsersUserId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("AppRoleAppUser");
                });

            modelBuilder.Entity("StoreOperation.WebApi.Data.Entities.AppLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Level")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StackTrace")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppLogs");
                });

            modelBuilder.Entity("StoreOperation.WebApi.Data.Entities.AppRole", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("AppRoles");
                });

            modelBuilder.Entity("StoreOperation.WebApi.Data.Entities.AppStore", b =>
                {
                    b.Property<Guid>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IlId")
                        .HasColumnType("int");

                    b.Property<int>("IlceId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OfficeFax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OfficePhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StoreState")
                        .HasColumnType("bit");

                    b.Property<string>("VergiKimlikNo")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("StoreId");

                    b.ToTable("AppStores");
                });

            modelBuilder.Entity("StoreOperation.WebApi.Data.Entities.AppUser", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("MobilePhone")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("OfficePhone")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SecurityKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("SecurityKeyExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SurName")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TokenExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool?>("UserNameConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("UserState")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("StoreOperation.WebApi.Data.Entities.AppUserAppStore", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StarDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.HasIndex("UserId");

                    b.ToTable("AppUsersAppStores");
                });

            modelBuilder.Entity("StoreOperation.WebApi.Data.Entities.CheckList", b =>
                {
                    b.Property<Guid>("CheckListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AppUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CheckListDayId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<DateTime>("TimeSpan")
                        .HasColumnType("datetime2");

                    b.HasKey("CheckListId");

                    b.HasIndex("AppUserId");

                    b.HasIndex("CheckListDayId");

                    b.ToTable("CheckLists");
                });

            modelBuilder.Entity("StoreOperation.WebApi.Data.Entities.CheckListDay", b =>
                {
                    b.Property<Guid>("CheckListDayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Day")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CheckListDayId");

                    b.HasIndex("StoreId");

                    b.ToTable("CheckListDays");
                });

            modelBuilder.Entity("StoreOperation.WebApi.Data.Entities.CheckListQuestion", b =>
                {
                    b.Property<Guid>("CheckListQuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Answer")
                        .HasColumnType("bit");

                    b.Property<byte>("AnswerState")
                        .HasColumnType("tinyint");

                    b.Property<Guid>("CheckListQuestionGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Question")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Skor")
                        .HasColumnType("tinyint");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.HasKey("CheckListQuestionId");

                    b.HasIndex("CheckListQuestionGroupId");

                    b.ToTable("CheckListQuestions");
                });

            modelBuilder.Entity("StoreOperation.WebApi.Data.Entities.CheckListQuestionGroup", b =>
                {
                    b.Property<Guid>("CheckListQuestionGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CheckListId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CheckListQuestionGroupId");

                    b.HasIndex("CheckListId");

                    b.ToTable("CheckListQuestionGroups");
                });

            modelBuilder.Entity("AppRoleAppUser", b =>
                {
                    b.HasOne("StoreOperation.WebApi.Data.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RolesRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreOperation.WebApi.Data.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StoreOperation.WebApi.Data.Entities.AppUserAppStore", b =>
                {
                    b.HasOne("StoreOperation.WebApi.Data.Entities.AppStore", "Store")
                        .WithMany("RelationShopeStoreUser")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreOperation.WebApi.Data.Entities.AppUser", "User")
                        .WithMany("RelationStoreUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StoreOperation.WebApi.Data.Entities.CheckList", b =>
                {
                    b.HasOne("StoreOperation.WebApi.Data.Entities.AppUser", "Certifying")
                        .WithMany()
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreOperation.WebApi.Data.Entities.CheckListDay", "CheckListDay")
                        .WithMany("CheckLists")
                        .HasForeignKey("CheckListDayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Certifying");

                    b.Navigation("CheckListDay");
                });

            modelBuilder.Entity("StoreOperation.WebApi.Data.Entities.CheckListDay", b =>
                {
                    b.HasOne("StoreOperation.WebApi.Data.Entities.AppStore", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("StoreOperation.WebApi.Data.Entities.CheckListQuestion", b =>
                {
                    b.HasOne("StoreOperation.WebApi.Data.Entities.CheckListQuestionGroup", "Group")
                        .WithMany("CheckListQuestions")
                        .HasForeignKey("CheckListQuestionGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("StoreOperation.WebApi.Data.Entities.CheckListQuestionGroup", b =>
                {
                    b.HasOne("StoreOperation.WebApi.Data.Entities.CheckList", null)
                        .WithMany("QuestionGroups")
                        .HasForeignKey("CheckListId");
                });

            modelBuilder.Entity("StoreOperation.WebApi.Data.Entities.AppStore", b =>
                {
                    b.Navigation("RelationShopeStoreUser");
                });

            modelBuilder.Entity("StoreOperation.WebApi.Data.Entities.AppUser", b =>
                {
                    b.Navigation("RelationStoreUsers");
                });

            modelBuilder.Entity("StoreOperation.WebApi.Data.Entities.CheckList", b =>
                {
                    b.Navigation("QuestionGroups");
                });

            modelBuilder.Entity("StoreOperation.WebApi.Data.Entities.CheckListDay", b =>
                {
                    b.Navigation("CheckLists");
                });

            modelBuilder.Entity("StoreOperation.WebApi.Data.Entities.CheckListQuestionGroup", b =>
                {
                    b.Navigation("CheckListQuestions");
                });
#pragma warning restore 612, 618
        }
    }
}
