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
    [Migration("20241022110053_ConvertInterestsToListCorrection")]
    partial class ConvertInterestsToListCorrection
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

            modelBuilder.Entity("RWA.Models.ProfilePage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Interests")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePhoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenantIdOriginal")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Work")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TenantIdOriginal");

                    b.ToTable("ProfilePages");
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
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("AmtOfAnnFee")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AmtOfMemFee")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnnFav")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnnFeesNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnnYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CasteCert")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateOfAnnFee")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateOfMemFee")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DecisionDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DecisionMemberAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DecisionMemberAge")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DecisionMemberFather")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DecisionMemberName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DecisionMemberType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DecisionPlace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeedCopy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemAge")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemFatherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemFav")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemFeesNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameOfTenFather")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProofDOBDoc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RMemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RMemNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RPlace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResolutionNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenAdhar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenCaste")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenCorAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TenDOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenOcc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenPAN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenPOA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenPOI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenPerAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenPoliceVer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenantIdOriginal")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.ToTable("TenantDetails");
                });

            modelBuilder.Entity("RWA.Models.ProfilePage", b =>
                {
                    b.HasOne("RWA.Models.TenantDetails", "TenantDetails")
                        .WithMany()
                        .HasForeignKey("TenantIdOriginal")
                        .HasPrincipalKey("TenantIdOriginal")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("TenantDetails");
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
