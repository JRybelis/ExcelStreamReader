﻿// <auto-generated />
using System;
using ExcelStreamReader.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ExcelStreamReader.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CoreData.Entities.LtCustomers.LtCustomers", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("AdditionalPlateNumbers")
                        .HasMaxLength(724)
                        .HasColumnType("character varying(724)");

                    b.Property<string>("Comment")
                        .HasMaxLength(724)
                        .HasColumnType("character varying(724)");

                    b.Property<int?>("CompanyDetailsId")
                        .HasColumnType("integer");

                    b.Property<int?>("CompanySlots")
                        .HasColumnType("integer");

                    b.Property<long?>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<string>("CustomerName")
                        .HasColumnType("text");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("Enabled")
                        .HasColumnType("boolean");

                    b.Property<long?>("Grid")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsInLot")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsLtCustomerAdditionalPlate")
                        .HasColumnType("boolean");

                    b.Property<long?>("LotPlaceId")
                        .HasColumnType("bigint");

                    b.Property<string>("LotPlaceTitle")
                        .IsRequired()
                        .HasMaxLength(331)
                        .HasColumnType("character varying(331)");

                    b.Property<string>("LtCustomerName")
                        .IsRequired()
                        .HasMaxLength(331)
                        .HasColumnType("character varying(331)");

                    b.Property<long?>("LtcGroupId")
                        .HasColumnType("bigint");

                    b.Property<string>("LtcGroupName")
                        .HasMaxLength(331)
                        .HasColumnType("character varying(331)");

                    b.Property<int?>("PaymentOption")
                        .HasColumnType("integer");

                    b.Property<string>("PincodeHash")
                        .HasColumnType("text");

                    b.Property<string>("PlateNumber")
                        .IsRequired()
                        .HasMaxLength(51)
                        .HasColumnType("character varying(51)");

                    b.Property<int?>("PriceRateId")
                        .HasColumnType("integer");

                    b.Property<long?>("TotalCount")
                        .HasColumnType("bigint");

                    b.Property<int?>("UsersLogActionId")
                        .HasColumnType("integer");

                    b.Property<long?>("UsersLogId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ValidFrom")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("ValidTo")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("VehicleType")
                        .HasColumnType("integer");

                    b.Property<string>("VehicleTypeTitle")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("LtCustomers");
                });
#pragma warning restore 612, 618
        }
    }
}
