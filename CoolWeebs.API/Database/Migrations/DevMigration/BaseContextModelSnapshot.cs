﻿// <auto-generated />
using System;
using CoolWeebs.API.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoolWeebs.API.Database.Migrations.DevMigration
{
    [DbContext(typeof(BaseContext))]
    partial class BaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CoolWeebs.API.Modules.TitleList.Entities.ItemEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<bool>("IsCompleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false)
                        .HasColumnName("is_completed");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false)
                        .HasColumnName("is_deleted");

                    b.Property<long>("ListId")
                        .HasColumnType("bigint")
                        .HasColumnName("list_id");

                    b.Property<long?>("TitleId")
                        .IsRequired()
                        .HasColumnType("bigint")
                        .HasColumnName("title_id");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("TitleId");

                    b.HasIndex("ListId", "TitleId")
                        .IsUnique();

                    b.HasIndex("Id", "TitleId", "ListId");

                    b.HasIndex("IsDeleted", "CreatedAt", "UpdatedAt");

                    b.ToTable("tb_tl_item", (string)null);
                });

            modelBuilder.Entity("CoolWeebs.API.Modules.TitleList.Entities.ListEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false)
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.Property<string>("UrlThumbnail")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("url_thumbnail");

                    b.HasKey("Id");

                    b.HasIndex("Id", "Name");

                    b.HasIndex("IsDeleted", "CreatedAt", "UpdatedAt");

                    b.ToTable("tb_tl_list", (string)null);
                });

            modelBuilder.Entity("CoolWeebs.API.Modules.TitleList.Entities.TitleEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false)
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.Property<string>("UrlThumbnail")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("url_thumbnail");

                    b.HasKey("Id");

                    b.HasIndex("Id", "Name");

                    b.HasIndex("IsDeleted", "CreatedAt", "UpdatedAt");

                    b.ToTable("tb_tl_title", (string)null);
                });

            modelBuilder.Entity("CoolWeebs.API.Modules.TitleList.Entities.ItemEntity", b =>
                {
                    b.HasOne("CoolWeebs.API.Modules.TitleList.Entities.ListEntity", "List")
                        .WithMany("Items")
                        .HasForeignKey("ListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoolWeebs.API.Modules.TitleList.Entities.TitleEntity", "Title")
                        .WithMany()
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("List");

                    b.Navigation("Title");
                });

            modelBuilder.Entity("CoolWeebs.API.Modules.TitleList.Entities.ListEntity", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
