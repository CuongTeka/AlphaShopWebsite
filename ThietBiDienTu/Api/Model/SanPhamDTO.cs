using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThietBiDienTu.Api.Model
{
    public class SanPhamDTO
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public decimal? GiaTien { get; set; }
        public int? SoLuongTon { get; set; }
        public int? UuDai { get; set; }
        public string ImageUrl { get; set; }
        public int? MaDanhMuc { get; set; }
        public int? MaHang { get; set; }
        public int? SoLuongDaBanRa { get; set; }
    }

    public class ChiTietSanPhamDTO
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public decimal? GiaTien { get; set; }
        public int? SoLuongTon { get; set; }
        public int? UuDai { get; set; }
        public string ImageUrl { get; set; }
        public string MoTa { get; set; }
        public string ThongSoKiThuat { get; set; }
        public string ChinhSachBaoHanh { get; set; }
        public int ThoiGianBaoHanh { get; set; }
        public int? MaDanhMuc { get; set; }
        public int? MaHang { get; set; }
        public int? SoLuongDaBanRa { get; set; }

    }
}
