﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OdinCM.Models;

namespace OdinCM.Migrations
{
    [DbContext(typeof(OdinCMContext))]
    [Migration("20181105103657_AddArticleViewCount")]
    partial class AddArticleViewCount
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("OdinCM.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("PublishedDateTime")
                        .HasColumnName("Published");

                    b.Property<string>("Slug");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("ViewCount");

                    b.HasKey("Id");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("OdinCM.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ArticleId");

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("IdArticle");

                    b.Property<DateTime>("SubmittedDateTime")
                        .HasColumnName("Submitted");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("OdinCM.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAtDateTime")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdatedAtDateTime")
                        .HasColumnName("UpdatedAt");

                    b.HasKey("CustomerID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("OdinCM.Models.Comment", b =>
                {
                    b.HasOne("OdinCM.Models.Article", "Article")
                        .WithMany("Comments")
                        .HasForeignKey("ArticleId");
                });
#pragma warning restore 612, 618
        }
    }
}
