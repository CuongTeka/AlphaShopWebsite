using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ThietBiDienTu.Areas.Admin.Models;
using ThietBiDienTu.Api.Model;
using System.Data;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ThietBiDienTu.Api
{
    public class SanPhamController : ApiController
    {
        private ThietBiDienTuEntities1 db = new ThietBiDienTuEntities1();

        private string url = "https://913e-125-235-239-74.ngrok-free.app/api/image/getimage?imageName=";

        // GET: api/SanPham
        //[HttpGet]
        //[Route("api/sanpham")]
        ////[ResponseType(typeof(IQueryable<SanPham>))]
        //public IHttpActionResult GetSanPhams(int? page = 1)
        //{
        //    int pageSize = 12; // Số lượng sản phẩm muốn hiển thị trong 1 trang
        //    int pageNumber = page ?? 1;

        //    var sanpham = db.SanPhams
        //        .Include(s => s.BaoHanhs)
        //        .Include(s => s.DanhMuc)
        //        .Include(s => s.HinhAnh)
        //        .Include(s => s.HangSanXuat)
        //        .OrderBy(s => s.TenSP)
        //        .Skip((pageNumber - 1) * pageSize)
        //        .Take(pageSize);

        //    return Ok(sanpham);
        //}


        // GET: api/SanPham
        //[HttpGet]
        //[Route("api/SanPham")]
        //public IHttpActionResult GetSanPhams()
        //{
        //    //var sanPhams = db.SanPhams
        //    //                 .Select(s => new SanPhamDTO
        //    //                 {
        //    //                     MaSP = s.MaSP,
        //    //                     TenSP = s.TenSP,
        //    //                     GiaTien = s.GiaTien,
        //    //                     SoLuongTon = s.SoLuongTon,
        //    //                     UuDai = s.UuDai,
        //    //                     MaHinhAnh = s.MaHinhAnh
        //    //                 })
        //    //                 .ToList();

        //    var sanPhams = db.SanPhams.Include(s => s.HinhAnh);

        //    return Ok(sanPhams);
        //}

        // GET: api/sanphamimage
        [HttpGet]
        [Route("api/sanphamimage/{id:int}")]
        [ResponseType(typeof(IQueryable<HinhAnh>))]
        public IHttpActionResult GetSanPhamImages(int id)
        {
            var hinhanh = db.HinhAnhs.Find(id);
            if (hinhanh == null)
            {
                return NotFound();
            }
            string ha = hinhanh.LinkHinhAnhChinh;

            return Ok(ha);
        }//check this

        // GET: api/SanPham/All
        [HttpGet]
        [Route("api/sanpham/all")]
        [ResponseType(typeof(IQueryable<SanPham>))]
        public IHttpActionResult GetAllSanPhams()
        {
            var sanpham = db.SanPhams
                .Include(s => s.BaoHanhs)
                .Include(s => s.DanhMuc)
                .Include(s => s.HinhAnh)
                .Include(s => s.HangSanXuat).Select(s => new SanPhamDTO
                {
                    MaSP = s.MaSP,
                    TenSP = s.TenSP,
                    GiaTien = s.GiaTien,
                    SoLuongTon = s.SoLuongTon,
                    UuDai = s.UuDai,
                    MaDanhMuc = s.MaDanhMuc,
                    MaHang = s.MaHang,
                    SoLuongDaBanRa = s.SoLuongDaBanRa,
                    ImageUrl = s.HinhAnh.LinkHinhAnhChinh
                });

            return Ok(sanpham);
        }

        // GET: api/SanPham/Details/{id}
        [HttpGet]
        [Route("api/sanpham/details/{id:int}")]
        [ResponseType(typeof(SanPham))]
        public IHttpActionResult GetSanPhamDetails(int id)
        {
            SanPham sanpham = db.SanPhams.Find(id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return Ok(sanpham);
        }


        [HttpGet]
        [Route("api/sanpham/search/{timkiem}")]
        public IHttpActionResult TimKiemSanPham(string timkiem)
        {
            // Kiểm tra xem tìm kiếm có giá trị hay không
            if (string.IsNullOrEmpty(timkiem))
            {
                return BadRequest("Thiếu tên sản phẩm.");
            }

            // Lấy danh sách sản phẩm từ cơ sở dữ liệu dựa trên tên sản phẩm
            var listSP = db.SanPhams.Where(m => m.TenSP.Contains(timkiem)).ToList();

            // Kiểm tra xem danh sách sản phẩm có rỗng hay không
            if (!listSP.Any())
            {
                var responseMessage = new { Message = "Không tìm thấy sản phẩm.", SearchTerm = timkiem };
                return Content(HttpStatusCode.NotFound, responseMessage);
            }

            // Chuyển đổi danh sách sản phẩm thành danh sách SanPhamDTO
            var listSPDto = listSP.Select(s => new SanPhamDTO
            {
                MaSP = s.MaSP,
                TenSP = s.TenSP,
                GiaTien = s.GiaTien,
                SoLuongTon = s.SoLuongTon,
                UuDai = s.UuDai,
                MaDanhMuc = s.MaDanhMuc,
                MaHang = s.MaHang,
                SoLuongDaBanRa = s.SoLuongDaBanRa,
                ImageUrl = s.HinhAnh.LinkHinhAnhChinh
            }).ToList();

            // Trả về danh sách sản phẩm dưới dạng JSON
            return Ok(listSPDto);
        }

        // GET: api/hangsanxuat
        [HttpGet]
        [Route("api/hangsanxuat")]
        //[ResponseType(typeof(IQueryable<HangSanXuat>))]
        public IHttpActionResult GetHangSanXuats()
        {
            var hangSanXuats = db.HangSanXuats.Select(h => new HangSanXuatDTO
            {
                MaHang = h.MaHang,
                TenHang = h.TenHang,
                MoTa = h.MoTa,
                TTLienHe = h.TTLienHe
            }).ToList();
            return Ok(hangSanXuats);
        }

        // GET: api/danhmuc
        [HttpGet]
        [Route("api/danhmuc")]
        [ResponseType(typeof(IQueryable<DanhMuc>))]
        public IHttpActionResult GetDanhMuc()
        {
            var danhMucs = db.DanhMucs
                                     .Select(d => new DanhMucDTO
                                     {
                                         MaDanhMuc = d.MaDanhMuc,
                                         TenDanhMuc = d.TenDanhMuc
                                     })
                                     .ToList();

            return Ok(danhMucs);
        }


        [HttpGet]
        [Route("api/sanpham/nsx/{mahang:int}")]
        public IHttpActionResult GetSanPhamTheoNSX(int mahang)
        {
            // Kiểm tra xem mã hãng có giá trị hay không
            if (mahang <= 0)
            {
                return BadRequest("Sai mã nhà sản xuất.");
            }

            // Lấy danh sách sản phẩm từ cơ sở dữ liệu dựa trên mã hãng
            var lstSP = db.SanPhams
                .Where(n => n.MaHang == mahang && n.TrangThai == 1)
                .OrderBy(s => s.TenSP)
                .Select(s => new SanPhamDTO
                {
                    MaSP = s.MaSP,
                    TenSP = s.TenSP,
                    GiaTien = s.GiaTien,
                    SoLuongTon = s.SoLuongTon,
                    UuDai = s.UuDai,
                    MaDanhMuc = s.MaDanhMuc,
                    MaHang = s.MaHang,
                    SoLuongDaBanRa = s.SoLuongDaBanRa,
                    ImageUrl = s.HinhAnh.LinkHinhAnhChinh
                })
                .ToList();

            // Kiểm tra xem danh sách sản phẩm có rỗng hay không
            if (!lstSP.Any())
            {
                var responseMessage = new { Message = "Không tìm thấy sản phẩm.", ManufacturerID = mahang };
                return Content(HttpStatusCode.NotFound, responseMessage);
            }

            // Trả về danh sách sản phẩm dưới dạng JSON
            return Ok(lstSP);
        }

        [HttpGet]
        [Route("api/sanpham/danhmuc/{madanhmuc:int}")]
        public IHttpActionResult GetSanPhamTheoDanhMuc(int madanhmuc)
        {
            // Kiểm tra xem mã danh mục có giá trị hay không
            if (madanhmuc <= 0)
            {
                return BadRequest("Sai mã danh mục.");
            }

            // Lấy danh sách sản phẩm từ cơ sở dữ liệu dựa trên mã danh mục
            var lstSP = db.SanPhams
                .Where(n => n.MaDanhMuc == madanhmuc && n.TrangThai == 1)
                .OrderBy(s => s.TenSP)
                .Select(s => new SanPhamDTO
                {
                    MaSP = s.MaSP,
                    TenSP = s.TenSP,
                    GiaTien = s.GiaTien,
                    SoLuongTon = s.SoLuongTon,
                    UuDai = s.UuDai,
                    MaDanhMuc = s.MaDanhMuc,
                    MaHang = s.MaHang,
                    SoLuongDaBanRa = s.SoLuongDaBanRa,
                    ImageUrl = s.HinhAnh.LinkHinhAnhChinh
                })
                .ToList();

            // Kiểm tra xem danh sách sản phẩm có rỗng hay không
            if (!lstSP.Any())
            {
                var responseMessage = new { Message = "Không tìm thấy sản phẩm.", CategoryID = madanhmuc };
                return Content(HttpStatusCode.NotFound, responseMessage);
            }

            // Trả về danh sách sản phẩm dưới dạng JSON
            return Ok(lstSP);
        }
    }
}
