﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Watch_Precision.Data;

#nullable disable

namespace Watch_Precision.Migrations
{
    [DbContext(typeof(WatchPrecisionContext))]
    [Migration("20221007130011_Initialize")]
    partial class Initialize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("Watch_Precision.Models.Measurement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("Deviation")
                        .HasColumnType("TEXT");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("TEXT");

                    b.Property<int>("WatchId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WatchId");

                    b.ToTable("Measurements");
                });

            modelBuilder.Entity("Watch_Precision.Models.Watch", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AdditionalInformaction")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("Watches");
                });

            modelBuilder.Entity("Watch_Precision.Models.Measurement", b =>
                {
                    b.HasOne("Watch_Precision.Models.Watch", "Watch")
                        .WithMany("Measurements")
                        .HasForeignKey("WatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Watch");
                });

            modelBuilder.Entity("Watch_Precision.Models.Watch", b =>
                {
                    b.Navigation("Measurements");
                });
#pragma warning restore 612, 618
        }
    }
}
