﻿// <auto-generated />
using System;
using DatabaseProject.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DatabaseProject.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DatabaseProject.Entity.Concrete.CarDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarModel")
                        .HasColumnType("int");

                    b.Property<string>("CarType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CarDetails");
                });

            modelBuilder.Entity("DatabaseProject.Entity.Concrete.City", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CountryID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CountryID");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("DatabaseProject.Entity.Concrete.Country", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("DatabaseProject.Entity.Concrete.DeliveryDetail", b =>
                {
                    b.Property<int>("DeliveryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CarDetailID")
                        .HasColumnType("int");

                    b.Property<int?>("CityDepartureId")
                        .HasColumnType("int");

                    b.Property<int?>("CityDestinationId")
                        .HasColumnType("int");

                    b.Property<int?>("CountryDepartureId")
                        .HasColumnType("int");

                    b.Property<int?>("CountryDestinationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeliveryEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeliveryStartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DeliveryID");

                    b.HasIndex("CarDetailID")
                        .IsUnique()
                        .HasFilter("[CarDetailID] IS NOT NULL");

                    b.HasIndex("CityDepartureId");

                    b.HasIndex("CityDestinationId");

                    b.HasIndex("CountryDepartureId");

                    b.HasIndex("CountryDestinationId");

                    b.ToTable("DeliveryDetails");
                });

            modelBuilder.Entity("DatabaseProject.Entity.Concrete.Driver", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DeliveryDetailID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DriverBirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DriverLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DriverName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DeliveryDetailID");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("DatabaseProject.Entity.Concrete.LoadDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DeliveryDetailID")
                        .HasColumnType("int");

                    b.Property<decimal>("LoadDepth")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("LoadHeight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("LoadType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("LoadWidth")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("DeliveryDetailID");

                    b.ToTable("LoadDetails");
                });

            modelBuilder.Entity("DatabaseProject.Entity.Concrete.TyreDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TyreType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CarID");

                    b.ToTable("TyreDetails");
                });

            modelBuilder.Entity("DatabaseProject.Entity.Concrete.City", b =>
                {
                    b.HasOne("DatabaseProject.Entity.Concrete.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Country");
                });

            modelBuilder.Entity("DatabaseProject.Entity.Concrete.DeliveryDetail", b =>
                {
                    b.HasOne("DatabaseProject.Entity.Concrete.CarDetail", "CarDetail")
                        .WithOne("DeliveryDetail")
                        .HasForeignKey("DatabaseProject.Entity.Concrete.DeliveryDetail", "CarDetailID");

                    b.HasOne("DatabaseProject.Entity.Concrete.City", "CityDeparture")
                        .WithMany("DeliveryDepartureCities")
                        .HasForeignKey("CityDepartureId");

                    b.HasOne("DatabaseProject.Entity.Concrete.City", "CityDestination")
                        .WithMany("DeliveryDestinationCities")
                        .HasForeignKey("CityDestinationId");

                    b.HasOne("DatabaseProject.Entity.Concrete.Country", "CountryDeparture")
                        .WithMany("DeliveryDepartureCountries")
                        .HasForeignKey("CountryDepartureId");

                    b.HasOne("DatabaseProject.Entity.Concrete.Country", "CountryDestination")
                        .WithMany("DeliveryDestinationCountries")
                        .HasForeignKey("CountryDestinationId");

                    b.Navigation("CarDetail");

                    b.Navigation("CityDeparture");

                    b.Navigation("CityDestination");

                    b.Navigation("CountryDeparture");

                    b.Navigation("CountryDestination");
                });

            modelBuilder.Entity("DatabaseProject.Entity.Concrete.Driver", b =>
                {
                    b.HasOne("DatabaseProject.Entity.Concrete.DeliveryDetail", "DeliveryDetail")
                        .WithMany("Drivers")
                        .HasForeignKey("DeliveryDetailID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("DeliveryDetail");
                });

            modelBuilder.Entity("DatabaseProject.Entity.Concrete.LoadDetail", b =>
                {
                    b.HasOne("DatabaseProject.Entity.Concrete.DeliveryDetail", "DeliveryDetail")
                        .WithMany("LoadDetails")
                        .HasForeignKey("DeliveryDetailID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("DeliveryDetail");
                });

            modelBuilder.Entity("DatabaseProject.Entity.Concrete.TyreDetail", b =>
                {
                    b.HasOne("DatabaseProject.Entity.Concrete.CarDetail", "CarDetail")
                        .WithMany("TyreDetails")
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("CarDetail");
                });

            modelBuilder.Entity("DatabaseProject.Entity.Concrete.CarDetail", b =>
                {
                    b.Navigation("DeliveryDetail");

                    b.Navigation("TyreDetails");
                });

            modelBuilder.Entity("DatabaseProject.Entity.Concrete.City", b =>
                {
                    b.Navigation("DeliveryDepartureCities");

                    b.Navigation("DeliveryDestinationCities");
                });

            modelBuilder.Entity("DatabaseProject.Entity.Concrete.Country", b =>
                {
                    b.Navigation("Cities");

                    b.Navigation("DeliveryDepartureCountries");

                    b.Navigation("DeliveryDestinationCountries");
                });

            modelBuilder.Entity("DatabaseProject.Entity.Concrete.DeliveryDetail", b =>
                {
                    b.Navigation("Drivers");

                    b.Navigation("LoadDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
