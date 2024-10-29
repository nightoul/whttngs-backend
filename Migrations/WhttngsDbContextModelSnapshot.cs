﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using whttngs_backend;

#nullable disable

namespace whttngsbackend.Migrations
{
    [DbContext(typeof(WhttngsDbContext))]
    partial class WhttngsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("whttngs_backend.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PostId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("whttngs_backend.Models.Video", b =>
                {
                    b.Property<int>("VideoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("VimeoUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("VideoId");

                    b.HasIndex("PostId");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("whttngs_backend.Models.VideoView", b =>
                {
                    b.Property<int>("VideoViewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("VideoId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("ViewEndPosition")
                        .HasColumnType("time(6)");

                    b.Property<TimeSpan>("ViewStartPosition")
                        .HasColumnType("time(6)");

                    b.Property<DateTime>("ViewedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("VisitorIP")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("VisitorLocation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("VideoViewId");

                    b.ToTable("VideoViews");
                });

            modelBuilder.Entity("whttngs_backend.Models.Visit", b =>
                {
                    b.Property<int>("VisitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("VisitEndedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("VisitStartedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("VisitorIP")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("VisitorLocation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("VisitId");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("whttngs_backend.Models.Video", b =>
                {
                    b.HasOne("whttngs_backend.Models.Post", null)
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
