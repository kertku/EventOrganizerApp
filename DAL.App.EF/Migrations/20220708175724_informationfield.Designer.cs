﻿// <auto-generated />
using System;
using DAL.App.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.App.EF.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220708175724_informationfield")]
    partial class informationfield
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.App.BusinessUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegistryCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BusinessUsers");
                });

            modelBuilder.Entity("Domain.App.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Information")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Domain.App.IndividualUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("IdentificationCode")
                        .HasColumnType("bigint");

                    b.Property<string>("Information")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IndividualUsers");
                });

            modelBuilder.Entity("Domain.App.Participation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BusinessUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IndividualUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Information")
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumberOfParticipants")
                        .HasColumnType("int");

                    b.Property<Guid>("PaymentTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BusinessUserId");

                    b.HasIndex("EventId");

                    b.HasIndex("IndividualUserId");

                    b.HasIndex("PaymentTypeId");

                    b.ToTable("Participations");
                });

            modelBuilder.Entity("Domain.App.PaymentType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PaymentTypeName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");
                });

            modelBuilder.Entity("Domain.App.Participation", b =>
                {
                    b.HasOne("Domain.App.BusinessUser", "BusinessUser")
                        .WithMany("Participations")
                        .HasForeignKey("BusinessUserId");

                    b.HasOne("Domain.App.Event", "Event")
                        .WithMany("Participations")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.App.IndividualUser", "IndividualUser")
                        .WithMany("Participations")
                        .HasForeignKey("IndividualUserId");

                    b.HasOne("Domain.App.PaymentType", "PaymentType")
                        .WithMany("Participations")
                        .HasForeignKey("PaymentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusinessUser");

                    b.Navigation("Event");

                    b.Navigation("IndividualUser");

                    b.Navigation("PaymentType");
                });

            modelBuilder.Entity("Domain.App.BusinessUser", b =>
                {
                    b.Navigation("Participations");
                });

            modelBuilder.Entity("Domain.App.Event", b =>
                {
                    b.Navigation("Participations");
                });

            modelBuilder.Entity("Domain.App.IndividualUser", b =>
                {
                    b.Navigation("Participations");
                });

            modelBuilder.Entity("Domain.App.PaymentType", b =>
                {
                    b.Navigation("Participations");
                });
#pragma warning restore 612, 618
        }
    }
}
