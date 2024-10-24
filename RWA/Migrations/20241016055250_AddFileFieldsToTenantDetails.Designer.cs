﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RWA.Data;

#nullable disable

namespace RWA.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241016055250_AddFileFieldsToTenantDetails")]
    partial class AddFileFieldsToTenantDetails
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RWA.Models.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("RWA.Models.Tenant", b =>
                {
                    b.Property<int>("TenantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TenantId"));

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenFlatNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TenLSD")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenPhoneNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenWhatsappNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenantIdOriginal")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TenantId");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("RWA.Models.TenantDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AmtOfAnnFee")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AmtOfMemFee")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnnFav")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnnFeesNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnnYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CasteCert")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateOfAnnFee")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateOfMemFee")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DecisionDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DecisionMemberAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DecisionMemberAge")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DecisionMemberFather")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DecisionMemberName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DecisionMemberType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DecisionPlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeedCopy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemAge")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemFatherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemFav")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemFeesNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameOfTenFather")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProofDOBDoc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RMemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RMemNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RPlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResolutionNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenAdhar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenCaste")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenCorAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TenDOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenOcc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenPAN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenPOA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenPOI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenPerAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenPoliceVer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenantIdOriginal")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TenantIdOriginal");

                    b.ToTable("TenantDetails");
                });

            modelBuilder.Entity("RWA.Models.TenantDetails", b =>
                {
                    b.HasOne("RWA.Models.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantIdOriginal")
                        .HasPrincipalKey("TenantIdOriginal")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Tenant");
                });
#pragma warning restore 612, 618
        }
    }
}
