﻿// <auto-generated />
using System;
using DoAnAsp.Areas.ADmin.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DoAnAsp.Migrations
{
    [DbContext(typeof(DPContext))]
    [Migration("20201227033125_create")]
    partial class create
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DoAnAsp.Areas.ADmin.Models.ChiTietHoaDonModel", b =>
                {
                    b.Property<int>("MaHD")
                        .HasColumnType("int");

                    b.Property<int>("MaSP")
                        .HasColumnType("int");

                    b.Property<int>("DonGia")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("MaHD", "MaSP");

                    b.HasIndex("MaSP");

                    b.ToTable("ChiTietHoaDons");
                });

            modelBuilder.Entity("DoAnAsp.Areas.ADmin.Models.DanhGiaModel", b =>
                {
                    b.Property<int>("MaSP")
                        .HasColumnType("int");

                    b.Property<int>("MaND")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoSao")
                        .HasColumnType("int");

                    b.HasKey("MaSP", "MaND");

                    b.HasIndex("MaND");

                    b.ToTable("DanhGias");
                });

            modelBuilder.Entity("DoAnAsp.Areas.ADmin.Models.HoaDonModel", b =>
                {
                    b.Property<int>("MaHD")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Andress")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<int?>("ChiTietHoaDonsMaHD")
                        .HasColumnType("int");

                    b.Property<int?>("ChiTietHoaDonsMaSP")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayLap")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NguoiDungModelMaND")
                        .HasColumnType("int");

                    b.Property<string>("NguoiNhan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhuongThucThanhToan")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("SDTNgNhan")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<decimal>("TongTien")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("MaHD");

                    b.HasIndex("NguoiDungModelMaND");

                    b.HasIndex("ChiTietHoaDonsMaHD", "ChiTietHoaDonsMaSP");

                    b.ToTable("HoaDons");
                });

            modelBuilder.Entity("DoAnAsp.Areas.ADmin.Models.KhuyenMaiModel", b =>
                {
                    b.Property<int>("MaKM")
                        .HasColumnType("int");

                    b.Property<int>("GiaTri")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayBD")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayKT")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenKM")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("MaKM");

                    b.ToTable("KhuyenMais");
                });

            modelBuilder.Entity("DoAnAsp.Areas.ADmin.Models.LoaiSPModelcs", b =>
                {
                    b.Property<int>("MaLoaiSP")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenLSP")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("MaLoaiSP");

                    b.ToTable("LoaiSPs");
                });

            modelBuilder.Entity("DoAnAsp.Areas.ADmin.Models.NguoiDungModel", b =>
                {
                    b.Property<int>("MaND")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Andress")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("GioiTinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HinhAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ho")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("MAQuyen")
                        .HasColumnType("int");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("TenLot")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("TenND")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaND");

                    b.HasIndex("MAQuyen");

                    b.ToTable("NguoiDungs");
                });

            modelBuilder.Entity("DoAnAsp.Areas.ADmin.Models.PhanQuyenModel", b =>
                {
                    b.Property<int>("MAQuyen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ChiTiet")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("TenQuyen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MAQuyen");

                    b.ToTable("PhanQuyens");
                });

            modelBuilder.Entity("DoAnAsp.Areas.ADmin.Models.SanPhamModel", b =>
                {
                    b.Property<int>("MaSP")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CameraSau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CameraTrc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Gia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("HDH")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaLoaiSP")
                        .HasColumnType("int");

                    b.Property<string>("ManHinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RAM")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ROM")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoSao")
                        .HasColumnType("int");

                    b.Property<int>("Soluong")
                        .HasColumnType("int");

                    b.Property<string>("TenSP")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("MaSP");

                    b.HasIndex("MaLoaiSP");

                    b.ToTable("SanPhams");
                });

            modelBuilder.Entity("DoAnAsp.Areas.ADmin.Models.ChiTietHoaDonModel", b =>
                {
                    b.HasOne("DoAnAsp.Areas.ADmin.Models.HoaDonModel", "hoaDon")
                        .WithMany("chiTietHoaDon")
                        .HasForeignKey("MaHD")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnAsp.Areas.ADmin.Models.SanPhamModel", "sanPham")
                        .WithMany("chiTietHoaDon")
                        .HasForeignKey("MaSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DoAnAsp.Areas.ADmin.Models.DanhGiaModel", b =>
                {
                    b.HasOne("DoAnAsp.Areas.ADmin.Models.NguoiDungModel", "nguoiDung")
                        .WithMany("danhGias")
                        .HasForeignKey("MaND")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnAsp.Areas.ADmin.Models.SanPhamModel", "SanPham")
                        .WithMany("danhGias")
                        .HasForeignKey("MaSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DoAnAsp.Areas.ADmin.Models.HoaDonModel", b =>
                {
                    b.HasOne("DoAnAsp.Areas.ADmin.Models.NguoiDungModel", null)
                        .WithMany("HoaDons")
                        .HasForeignKey("NguoiDungModelMaND");

                    b.HasOne("DoAnAsp.Areas.ADmin.Models.ChiTietHoaDonModel", "ChiTietHoaDons")
                        .WithMany()
                        .HasForeignKey("ChiTietHoaDonsMaHD", "ChiTietHoaDonsMaSP");
                });

            modelBuilder.Entity("DoAnAsp.Areas.ADmin.Models.KhuyenMaiModel", b =>
                {
                    b.HasOne("DoAnAsp.Areas.ADmin.Models.SanPhamModel", "SanPham")
                        .WithOne("KhuyenMai")
                        .HasForeignKey("DoAnAsp.Areas.ADmin.Models.KhuyenMaiModel", "MaKM")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DoAnAsp.Areas.ADmin.Models.NguoiDungModel", b =>
                {
                    b.HasOne("DoAnAsp.Areas.ADmin.Models.PhanQuyenModel", "PhanQuyens")
                        .WithMany("nguoiDungs")
                        .HasForeignKey("MAQuyen")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DoAnAsp.Areas.ADmin.Models.SanPhamModel", b =>
                {
                    b.HasOne("DoAnAsp.Areas.ADmin.Models.LoaiSPModelcs", "LoaiSPs")
                        .WithMany("SanPhams")
                        .HasForeignKey("MaLoaiSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
