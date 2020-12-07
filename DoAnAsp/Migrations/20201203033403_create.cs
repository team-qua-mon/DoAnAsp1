using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAnAsp.Migrations
{
    public partial class create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoaiSPs",
                columns: table => new
                {
                    MaLoaiSP = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLSP = table.Column<string>(nullable: true),
                    Img = table.Column<string>(nullable: true),
                    Mota = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSPs", x => x.MaLoaiSP);
                });

            migrationBuilder.CreateTable(
                name: "PhanQuyens",
                columns: table => new
                {
                    MAQuyen = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuyen = table.Column<string>(nullable: true),
                    ChiTiet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanQuyens", x => x.MAQuyen);
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    MaSP = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSP = table.Column<string>(nullable: false),
                    Gia = table.Column<int>(nullable: false),
                    Soluong = table.Column<int>(nullable: false),
                    HinhAnh = table.Column<string>(nullable: true),
                    ManHinh = table.Column<string>(nullable: true),
                    HDH = table.Column<string>(nullable: true),
                    CameraTrc = table.Column<string>(nullable: true),
                    CameraSau = table.Column<string>(nullable: true),
                    CPU = table.Column<string>(nullable: true),
                    RAM = table.Column<string>(nullable: true),
                    ROM = table.Column<string>(nullable: true),
                    Pin = table.Column<string>(nullable: true),
                    SoSao = table.Column<int>(nullable: false),
                    MoTa = table.Column<string>(nullable: true),
                    TrangThai = table.Column<int>(nullable: false),
                    MaLoaiSP = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.MaSP);
                    table.ForeignKey(
                        name: "FK_SanPhams_LoaiSPs_MaLoaiSP",
                        column: x => x.MaLoaiSP,
                        principalTable: "LoaiSPs",
                        principalColumn: "MaLoaiSP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDungs",
                columns: table => new
                {
                    MaND = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ho = table.Column<string>(nullable: true),
                    TenLot = table.Column<string>(nullable: true),
                    TenND = table.Column<string>(nullable: true),
                    GioiTinh = table.Column<string>(nullable: true),
                    HinhAnh = table.Column<string>(nullable: true),
                    SDT = table.Column<string>(nullable: true),
                    Andress = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    PassWord = table.Column<string>(nullable: true),
                    TrangThai = table.Column<int>(nullable: false),
                    MAQuyen = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDungs", x => x.MaND);
                    table.ForeignKey(
                        name: "FK_NguoiDungs_PhanQuyens_MAQuyen",
                        column: x => x.MAQuyen,
                        principalTable: "PhanQuyens",
                        principalColumn: "MAQuyen",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KhuyenMais",
                columns: table => new
                {
                    MaKM = table.Column<int>(nullable: false),
                    TenKM = table.Column<string>(nullable: true),
                    LoaiKM = table.Column<string>(nullable: true),
                    GiaTri = table.Column<int>(nullable: false),
                    NgayBD = table.Column<string>(nullable: true),
                    NgayKT = table.Column<string>(nullable: true),
                    TrangThai = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMais", x => x.MaKM);
                    table.ForeignKey(
                        name: "FK_KhuyenMais_SanPhams_MaKM",
                        column: x => x.MaKM,
                        principalTable: "SanPhams",
                        principalColumn: "MaSP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DanhGias",
                columns: table => new
                {
                    MaND = table.Column<int>(nullable: false),
                    MaSP = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    SoSao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhGias", x => new { x.MaSP, x.MaND });
                    table.ForeignKey(
                        name: "FK_DanhGias_NguoiDungs_MaND",
                        column: x => x.MaND,
                        principalTable: "NguoiDungs",
                        principalColumn: "MaND",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhGias_SanPhams_MaSP",
                        column: x => x.MaSP,
                        principalTable: "SanPhams",
                        principalColumn: "MaSP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    MaHD = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayLap = table.Column<string>(nullable: true),
                    NguoiNhan = table.Column<string>(nullable: true),
                    SDTNgNhan = table.Column<string>(nullable: true),
                    Andress = table.Column<string>(nullable: true),
                    PhuongThucThanhToan = table.Column<string>(nullable: true),
                    TongTien = table.Column<int>(nullable: false),
                    TrangThai = table.Column<int>(nullable: false),
                    ChiTietHoaDonsMaHD = table.Column<int>(nullable: true),
                    ChiTietHoaDonsMaSP = table.Column<int>(nullable: true),
                    NguoiDungModelMaND = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.MaHD);
                    table.ForeignKey(
                        name: "FK_HoaDons_NguoiDungs_NguoiDungModelMaND",
                        column: x => x.NguoiDungModelMaND,
                        principalTable: "NguoiDungs",
                        principalColumn: "MaND",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDons",
                columns: table => new
                {
                    MaSP = table.Column<int>(nullable: false),
                    MaHD = table.Column<int>(nullable: false),
                    SoLuong = table.Column<int>(nullable: false),
                    DonGia = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDons", x => new { x.MaHD, x.MaSP });
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_HoaDons_MaHD",
                        column: x => x.MaHD,
                        principalTable: "HoaDons",
                        principalColumn: "MaHD",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_SanPhams_MaSP",
                        column: x => x.MaSP,
                        principalTable: "SanPhams",
                        principalColumn: "MaSP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_MaSP",
                table: "ChiTietHoaDons",
                column: "MaSP");

            migrationBuilder.CreateIndex(
                name: "IX_DanhGias_MaND",
                table: "DanhGias",
                column: "MaND");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_NguoiDungModelMaND",
                table: "HoaDons",
                column: "NguoiDungModelMaND");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_ChiTietHoaDonsMaHD_ChiTietHoaDonsMaSP",
                table: "HoaDons",
                columns: new[] { "ChiTietHoaDonsMaHD", "ChiTietHoaDonsMaSP" });

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDungs_MAQuyen",
                table: "NguoiDungs",
                column: "MAQuyen");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_MaLoaiSP",
                table: "SanPhams",
                column: "MaLoaiSP");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDons_ChiTietHoaDons_ChiTietHoaDonsMaHD_ChiTietHoaDonsMaSP",
                table: "HoaDons",
                columns: new[] { "ChiTietHoaDonsMaHD", "ChiTietHoaDonsMaSP" },
                principalTable: "ChiTietHoaDons",
                principalColumns: new[] { "MaHD", "MaSP" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDons_HoaDons_MaHD",
                table: "ChiTietHoaDons");

            migrationBuilder.DropTable(
                name: "DanhGias");

            migrationBuilder.DropTable(
                name: "KhuyenMais");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "NguoiDungs");

            migrationBuilder.DropTable(
                name: "ChiTietHoaDons");

            migrationBuilder.DropTable(
                name: "PhanQuyens");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "LoaiSPs");
        }
    }
}
