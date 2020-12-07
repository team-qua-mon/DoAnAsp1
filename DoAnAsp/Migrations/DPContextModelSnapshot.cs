﻿// <auto-generated />
using System;
using DoAnAsp.Areas.ADmin.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DoAnAsp.Migrations
{
    [DbContext(typeof(DPContext))]
    partial class DPContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ChiTietHoaDonsMaHD")
                        .HasColumnType("int");

                    b.Property<int?>("ChiTietHoaDonsMaSP")
                        .HasColumnType("int");

                    b.Property<string>("NgayLap")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NguoiDungModelMaND")
                        .HasColumnType("int");

                    b.Property<string>("NguoiNhan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhuongThucThanhToan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDTNgNhan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TongTien")
                        .HasColumnType("int");

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

                    b.Property<string>("LoaiKM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NgayBD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NgayKT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenKM")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenLSP")
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GioiTinh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ho")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MAQuyen")
                        .HasColumnType("int");

                    b.Property<string>("PassWord")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenLot")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenND")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenQuyen")
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CameraSau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CameraTrc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gia")
                        .HasColumnType("int");

                    b.Property<string>("HDH")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaLoaiSP")
                        .HasColumnType("int");

                    b.Property<string>("ManHinh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RAM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ROM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoSao")
                        .HasColumnType("int");

                    b.Property<int>("Soluong")
                        .HasColumnType("int");

                    b.Property<string>("TenSP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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