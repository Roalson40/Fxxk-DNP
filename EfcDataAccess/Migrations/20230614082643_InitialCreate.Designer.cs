﻿// <auto-generated />
using System;
using EfcDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EfcDataAccess.Migrations
{
    [DbContext(typeof(KindContenxt))]
    [Migration("20230614082643_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Domain.HoleScore", b =>
                {
                    b.Property<int>("RounderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("HoleId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumOfStrikes")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("RounderId");

                    b.HasIndex("PlayerId");

                    b.ToTable("HoleScores");
                });

            modelBuilder.Entity("Domain.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<double>("MembershipFee")
                        .HasColumnType("REAL");

                    b.Property<string>("MembershipType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.HasKey("PlayerId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Domain.HoleScore", b =>
                {
                    b.HasOne("Domain.Player", null)
                        .WithMany("HoleScores")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("Domain.Player", b =>
                {
                    b.Navigation("HoleScores");
                });
#pragma warning restore 612, 618
        }
    }
}
