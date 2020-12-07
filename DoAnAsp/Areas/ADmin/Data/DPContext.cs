using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DoAnAsp.Areas.ADmin.Models;
namespace DoAnAsp.Areas.ADmin.Data
{
    public class DPContext:DbContext
    {
        public DPContext(DbContextOptions<DPContext> options) : base(options)
        {

        }
        public DbSet<ChiTietHoaDonModel> ChiTietHoaDons { get; set; }
        public DbSet<DanhGiaModel> DanhGias { get; set; }   
        public DbSet<HoaDonModel> HoaDons { get; set; }
        public DbSet<KhuyenMaiModel> KhuyenMais { get; set; }
        public DbSet<LoaiSPModelcs> LoaiSPs { get; set; }
        public DbSet<NguoiDungModel> NguoiDungs { get; set; }
        public DbSet<PhanQuyenModel> PhanQuyens { get; set; }
        public DbSet<SanPhamModel> SanPhams { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietHoaDonModel>()
                .HasKey(bc => new { bc.MaHD, bc.MaSP });
            modelBuilder.Entity<ChiTietHoaDonModel>()
                .HasOne(bc => bc.hoaDon)
                .WithMany(bc => bc.chiTietHoaDon)
                .HasForeignKey(bc => bc.MaHD);
            modelBuilder.Entity<ChiTietHoaDonModel>()
                .HasOne(bc => bc.sanPham)
                .WithMany(bc => bc.chiTietHoaDon)
                .HasForeignKey(bc => bc.MaSP);


            modelBuilder.Entity<DanhGiaModel>()
              .HasKey(bc => new { bc.MaSP, bc.MaND });
            modelBuilder.Entity<DanhGiaModel>()
                .HasOne(bc => bc.SanPham)
                .WithMany(bc => bc.danhGias)
                .HasForeignKey(bc => bc.MaSP);
            modelBuilder.Entity<DanhGiaModel>()
                .HasOne(bc => bc.nguoiDung)
                .WithMany(bc => bc.danhGias)
                .HasForeignKey(bc => bc.MaND);
        }

    }
}
