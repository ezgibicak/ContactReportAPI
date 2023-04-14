﻿// <auto-generated />
using System;
using ContactAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ContactReportAPI.Migrations
{
    [DbContext(typeof(AplicationContext))]
    partial class AplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ContactAPI.Entity.Iletisim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("KisiId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("TelefonNumarasi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KisiId");

                    b.ToTable("Iletisim");
                });

            modelBuilder.Entity("ContactAPI.Entity.Kisi", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyad")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kisi");
                });

            modelBuilder.Entity("ContactAPI.Entity.KisiIletisim", b =>
                {
                    b.Property<Guid>("KisiId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("İletisimId")
                        .HasColumnType("int");

                    b.ToTable("KisiIletisim");
                });

            modelBuilder.Entity("ContactAPI.Entity.Iletisim", b =>
                {
                    b.HasOne("ContactAPI.Entity.Kisi", null)
                        .WithMany("Iletisim")
                        .HasForeignKey("KisiId");
                });

            modelBuilder.Entity("ContactAPI.Entity.Kisi", b =>
                {
                    b.Navigation("Iletisim");
                });
#pragma warning restore 612, 618
        }
    }
}
