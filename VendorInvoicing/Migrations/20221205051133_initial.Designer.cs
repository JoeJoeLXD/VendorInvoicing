﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VendorInvoicing.DataAccess;

#nullable disable

namespace VendorInvoicing.Migrations
{
    [DbContext(typeof(VendorDbContext))]
    [Migration("20221205051133_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Vendors.Entities.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceId"));

                    b.Property<DateTime?>("InvoiceDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentTermsId")
                        .HasColumnType("int");

                    b.Property<double?>("PaymentTotal")
                        .HasColumnType("float");

                    b.Property<int>("VendorId")
                        .HasColumnType("int");

                    b.HasKey("InvoiceId");

                    b.HasIndex("PaymentTermsId");

                    b.HasIndex("VendorId");

                    b.ToTable("Invoices");

                    b.HasData(
                        new
                        {
                            InvoiceId = 1,
                            InvoiceDate = new DateTime(2022, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentTermsId = 3,
                            PaymentTotal = 0.0,
                            VendorId = 1
                        },
                        new
                        {
                            InvoiceId = 2,
                            InvoiceDate = new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentTermsId = 3,
                            PaymentTotal = 0.0,
                            VendorId = 1
                        },
                        new
                        {
                            InvoiceId = 3,
                            InvoiceDate = new DateTime(2022, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentTermsId = 3,
                            PaymentTotal = 0.0,
                            VendorId = 2
                        },
                        new
                        {
                            InvoiceId = 4,
                            InvoiceDate = new DateTime(2022, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentTermsId = 4,
                            PaymentTotal = 0.0,
                            VendorId = 2
                        },
                        new
                        {
                            InvoiceId = 5,
                            InvoiceDate = new DateTime(2022, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentTermsId = 3,
                            PaymentTotal = 0.0,
                            VendorId = 3
                        },
                        new
                        {
                            InvoiceId = 6,
                            InvoiceDate = new DateTime(2022, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentTermsId = 4,
                            PaymentTotal = 0.0,
                            VendorId = 3
                        },
                        new
                        {
                            InvoiceId = 7,
                            InvoiceDate = new DateTime(2022, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentTermsId = 3,
                            PaymentTotal = 0.0,
                            VendorId = 4
                        },
                        new
                        {
                            InvoiceId = 8,
                            InvoiceDate = new DateTime(2022, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentTermsId = 5,
                            PaymentTotal = 0.0,
                            VendorId = 4
                        },
                        new
                        {
                            InvoiceId = 9,
                            InvoiceDate = new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentTermsId = 3,
                            PaymentTotal = 0.0,
                            VendorId = 5
                        },
                        new
                        {
                            InvoiceId = 10,
                            InvoiceDate = new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentTermsId = 3,
                            PaymentTotal = 0.0,
                            VendorId = 6
                        },
                        new
                        {
                            InvoiceId = 11,
                            InvoiceDate = new DateTime(2022, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentTermsId = 2,
                            PaymentTotal = 0.0,
                            VendorId = 7
                        },
                        new
                        {
                            InvoiceId = 12,
                            InvoiceDate = new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentTermsId = 3,
                            PaymentTotal = 0.0,
                            VendorId = 8
                        });
                });

            modelBuilder.Entity("Vendors.Entities.InvoiceLineItem", b =>
                {
                    b.Property<int>("InvoiceLineItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceLineItemId"));

                    b.Property<double?>("Amount")
                        .IsRequired()
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InvoiceId")
                        .HasColumnType("int");

                    b.HasKey("InvoiceLineItemId");

                    b.HasIndex("InvoiceId");

                    b.ToTable("InvoiceLineItems");

                    b.HasData(
                        new
                        {
                            InvoiceLineItemId = 1,
                            Amount = 1089.99,
                            Description = "Part 123",
                            InvoiceId = 1
                        },
                        new
                        {
                            InvoiceLineItemId = 2,
                            Amount = 173499.5,
                            Description = "Service XYZ",
                            InvoiceId = 1
                        },
                        new
                        {
                            InvoiceLineItemId = 3,
                            Amount = 4654499.5,
                            Description = "Part 110",
                            InvoiceId = 2
                        },
                        new
                        {
                            InvoiceLineItemId = 4,
                            Amount = 78799.5,
                            Description = "Part A",
                            InvoiceId = 2
                        },
                        new
                        {
                            InvoiceLineItemId = 5,
                            Amount = 679.5,
                            Description = "Part AA",
                            InvoiceId = 3
                        },
                        new
                        {
                            InvoiceLineItemId = 6,
                            Amount = 786.89999999999998,
                            Description = "Part Z",
                            InvoiceId = 3
                        },
                        new
                        {
                            InvoiceLineItemId = 7,
                            Amount = 998.5,
                            Description = "Trip 1",
                            InvoiceId = 4
                        },
                        new
                        {
                            InvoiceLineItemId = 8,
                            Amount = 1011.5,
                            Description = "Service XYZ",
                            InvoiceId = 4
                        },
                        new
                        {
                            InvoiceLineItemId = 9,
                            Amount = 565735.5,
                            Description = "Rental DEF",
                            InvoiceId = 5
                        },
                        new
                        {
                            InvoiceLineItemId = 10,
                            Amount = 5753.5,
                            Description = "Rental ZZZ",
                            InvoiceId = 5
                        },
                        new
                        {
                            InvoiceLineItemId = 11,
                            Amount = 58453.900000000001,
                            Description = "Service ABC",
                            InvoiceId = 6
                        },
                        new
                        {
                            InvoiceLineItemId = 12,
                            Amount = 111232.5,
                            Description = "Service ABC",
                            InvoiceId = 6
                        },
                        new
                        {
                            InvoiceLineItemId = 13,
                            Amount = 109.5,
                            Description = "Rental ABC",
                            InvoiceId = 7
                        },
                        new
                        {
                            InvoiceLineItemId = 14,
                            Amount = 57846.5,
                            Description = "Rental ABC",
                            InvoiceId = 8
                        },
                        new
                        {
                            InvoiceLineItemId = 15,
                            Amount = 132.5,
                            Description = "Trip 2",
                            InvoiceId = 9
                        },
                        new
                        {
                            InvoiceLineItemId = 16,
                            Amount = 6877.8999999999996,
                            Description = "Service XYZ",
                            InvoiceId = 9
                        },
                        new
                        {
                            InvoiceLineItemId = 17,
                            Amount = 8999.5,
                            Description = "Trip 3",
                            InvoiceId = 10
                        },
                        new
                        {
                            InvoiceLineItemId = 18,
                            Amount = 1033.5,
                            Description = "Blah blah",
                            InvoiceId = 10
                        },
                        new
                        {
                            InvoiceLineItemId = 19,
                            Amount = 56455.5,
                            Description = "Ho hum",
                            InvoiceId = 11
                        },
                        new
                        {
                            InvoiceLineItemId = 20,
                            Amount = 1454589.5,
                            Description = "Fiddle dee",
                            InvoiceId = 11
                        },
                        new
                        {
                            InvoiceLineItemId = 21,
                            Amount = 583453.5,
                            Description = "Service ABC",
                            InvoiceId = 12
                        },
                        new
                        {
                            InvoiceLineItemId = 22,
                            Amount = 567.5,
                            Description = "Fiddle dum",
                            InvoiceId = 12
                        });
                });

            modelBuilder.Entity("Vendors.Entities.PaymentTerms", b =>
                {
                    b.Property<int>("PaymentTermsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentTermsId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DueDays")
                        .HasColumnType("int");

                    b.HasKey("PaymentTermsId");

                    b.ToTable("PaymentTerms");

                    b.HasData(
                        new
                        {
                            PaymentTermsId = 1,
                            Description = "Net due 10 days",
                            DueDays = 10
                        },
                        new
                        {
                            PaymentTermsId = 2,
                            Description = "Net due 20 days",
                            DueDays = 20
                        },
                        new
                        {
                            PaymentTermsId = 3,
                            Description = "Net due 30 days",
                            DueDays = 30
                        },
                        new
                        {
                            PaymentTermsId = 4,
                            Description = "Net due 60 days",
                            DueDays = 60
                        },
                        new
                        {
                            PaymentTermsId = 5,
                            Description = "Net due 90 days",
                            DueDays = 90
                        });
                });

            modelBuilder.Entity("Vendors.Entities.Vendor", b =>
                {
                    b.Property<int>("VendorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VendorId"));

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProvinceOrState")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("VendorContactEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VendorContactFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VendorContactLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VendorPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipOrPostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VendorId");

                    b.ToTable("Vendors");

                    b.HasData(
                        new
                        {
                            VendorId = 1,
                            Address1 = "27371 Valderas",
                            City = "Mission Viejo",
                            IsDeleted = false,
                            Name = "Blanchard & Johnson Associates",
                            ProvinceOrState = "CA",
                            VendorContactEmail = "kgonz@bja.com",
                            VendorContactFirstName = "Keeton",
                            VendorContactLastName = "Gonzalo",
                            VendorPhone = "214-555-3647",
                            ZipOrPostalCode = "92691"
                        },
                        new
                        {
                            VendorId = 2,
                            Address1 = "3255 Ramos Cir",
                            City = "Sacramento",
                            IsDeleted = false,
                            Name = "California Chamber Of Commerce",
                            ProvinceOrState = "CA",
                            VendorContactEmail = "manton@gmail.com",
                            VendorContactFirstName = "Mauro",
                            VendorContactLastName = "Anton",
                            VendorPhone = "916-555-6670",
                            ZipOrPostalCode = "95827"
                        },
                        new
                        {
                            VendorId = 3,
                            Address1 = "PO Box 85826",
                            City = "San Diego",
                            IsDeleted = false,
                            Name = "Golden Eagle Insurance Co",
                            ProvinceOrState = "CA",
                            VendorContactFirstName = "Jane",
                            VendorContactLastName = "Smith",
                            VendorPhone = "917-544-7090",
                            ZipOrPostalCode = "92186"
                        },
                        new
                        {
                            VendorId = 4,
                            Address1 = "1952 H Street",
                            Address2 = "P.O. Box 1952",
                            City = "Fresno",
                            IsDeleted = false,
                            Name = "Fresno Photoengraving Company",
                            ProvinceOrState = "CA",
                            VendorContactFirstName = "Chad",
                            VendorContactLastName = "Jones",
                            VendorPhone = "559-555-3005",
                            ZipOrPostalCode = "93718"
                        },
                        new
                        {
                            VendorId = 5,
                            Address1 = "Ohio Valley Litho Division",
                            City = "Cincinnate",
                            IsDeleted = false,
                            Name = "Nielson",
                            ProvinceOrState = "OH",
                            VendorContactFirstName = "Paul",
                            VendorContactLastName = "Morgan",
                            VendorPhone = "519-824-3477",
                            ZipOrPostalCode = "45264"
                        },
                        new
                        {
                            VendorId = 6,
                            Address1 = "PO Box 40513",
                            City = "Jacksonville",
                            IsDeleted = false,
                            Name = "Naylor Publications Inc",
                            ProvinceOrState = "FL",
                            VendorContactEmail = "gerald.kristoff@outlook.com",
                            VendorContactFirstName = "Gerald",
                            VendorContactLastName = "Kristoff",
                            VendorPhone = "800-555-6041",
                            ZipOrPostalCode = "32231"
                        },
                        new
                        {
                            VendorId = 7,
                            Address1 = "60 Madison Ave",
                            City = "New York",
                            IsDeleted = false,
                            Name = "Venture Communications",
                            ProvinceOrState = "NY",
                            VendorContactEmail = "tneftaly@venture.com",
                            VendorContactFirstName = "Thalia",
                            VendorContactLastName = "Neftaly",
                            VendorPhone = "212-533-4800",
                            ZipOrPostalCode = "10010"
                        },
                        new
                        {
                            VendorId = 8,
                            Address1 = "Attn:  Supt. Window Services",
                            Address2 = "PO Box 7005",
                            City = "Madison",
                            IsDeleted = false,
                            Name = "US Postal Service",
                            ProvinceOrState = "WI",
                            VendorContactFirstName = "Alberto",
                            VendorContactLastName = "Francesco",
                            VendorPhone = "800-555-1205",
                            ZipOrPostalCode = "53707"
                        });
                });

            modelBuilder.Entity("Vendors.Entities.Invoice", b =>
                {
                    b.HasOne("Vendors.Entities.PaymentTerms", "PaymentTerms")
                        .WithMany("Invoices")
                        .HasForeignKey("PaymentTermsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vendors.Entities.Vendor", "Vendor")
                        .WithMany("Invoices")
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentTerms");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("Vendors.Entities.InvoiceLineItem", b =>
                {
                    b.HasOne("Vendors.Entities.Invoice", "Invoice")
                        .WithMany("InvoiceLineItems")
                        .HasForeignKey("InvoiceId");

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("Vendors.Entities.Invoice", b =>
                {
                    b.Navigation("InvoiceLineItems");
                });

            modelBuilder.Entity("Vendors.Entities.PaymentTerms", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("Vendors.Entities.Vendor", b =>
                {
                    b.Navigation("Invoices");
                });
#pragma warning restore 612, 618
        }
    }
}
