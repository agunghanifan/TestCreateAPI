﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestCreateAPI.Models.Context;

#nullable disable

namespace TestCreateAPI.Migrations
{
    [DbContext(typeof(UniversityContext))]
    partial class UniversityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TestCreateAPI.Models.Models.Kuliah", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CodeMatakuliah")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdMahasiswa")
                        .HasColumnType("int");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasMaxLength(2)
                        .HasColumnType("int");

                    b.Property<string>("UserCreated")
                        .HasColumnType("longtext");

                    b.Property<string>("UserModified")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CodeMatakuliah");

                    b.HasIndex("IdMahasiswa");

                    b.ToTable("Kuliah");
                });

            modelBuilder.Entity("TestCreateAPI.Models.Models.Mahasiswa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .HasMaxLength(2)
                        .HasColumnType("int");

                    b.Property<string>("UserCreated")
                        .HasColumnType("longtext");

                    b.Property<string>("UserModified")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Mahasiswa");
                });

            modelBuilder.Entity("TestCreateAPI.Models.Models.MataKuliah", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .HasMaxLength(2)
                        .HasColumnType("int");

                    b.Property<string>("UserCreated")
                        .HasColumnType("longtext");

                    b.Property<string>("UserModified")
                        .HasColumnType("longtext");

                    b.HasKey("Code");

                    b.ToTable("MataKuliah");
                });

            modelBuilder.Entity("TestCreateAPI.Models.Models.Kuliah", b =>
                {
                    b.HasOne("TestCreateAPI.Models.Models.MataKuliah", "MataKuliah")
                        .WithMany()
                        .HasForeignKey("CodeMatakuliah");

                    b.HasOne("TestCreateAPI.Models.Models.Mahasiswa", "Mahasiswa")
                        .WithMany()
                        .HasForeignKey("IdMahasiswa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mahasiswa");

                    b.Navigation("MataKuliah");
                });
#pragma warning restore 612, 618
        }
    }
}
