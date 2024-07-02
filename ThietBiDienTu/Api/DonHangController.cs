using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ThietBiDienTu.Api.Model;
using ThietBiDienTu.Areas.Admin.Models;

namespace ThietBiDienTu.Api
{
    public class DonHangController : ApiController
    {
        private ThietBiDienTuEntities1 db = new ThietBiDienTuEntities1();

        //GET
        //----------------------------------------------------------------
        // GET: api/donhang/dangxuly
        [HttpGet]
        [Route("api/donhang/dangxuly")]
        [ResponseType(typeof(IQueryable<DDH>))]
        public IHttpActionResult QuanLyDonHang()
        {
            var ddh = db.GetOrderInfoByStatus1(1);
            return Ok(ddh);
        }

        // GET: api/donhang/danggiao
        [HttpGet]
        [Route("api/donhang/danggiao")]
        [ResponseType(typeof(IQueryable<DDH>))]
        public IHttpActionResult DangGiao()
        {
            var ddh = db.GetOrderInfoByStatus1(2);
            return Ok(ddh.ToList());
        }

        // GET: api/donhang/dagiao
        [HttpGet]
        [Route("api/donhang/dagiao")]
        [ResponseType(typeof(IQueryable<DDH>))]
        public IHttpActionResult DaGiao()
        {
            var ddh = db.GetOrderInfoByStatus1(3);
            return Ok(ddh.ToList());
        }

        // GET: api/donhang/dahuy
        [HttpGet]
        [Route("api/donhang/dahuy")]
        [ResponseType(typeof(IQueryable<DDH>))]
        public IHttpActionResult DaHuy()
        {
            var ddh = db.GetOrderInfoByStatus1(4);
            return Ok(ddh.ToList());
        }

        // GET: api/donhang/search/theoma/1
        [HttpGet]
        [Route("api/donhang/search/theoma/{timkiem}")]
        public IHttpActionResult TimKiemDonHang(int timkiem)
        {
            if (timkiem <= 0)
            {
                return BadRequest("Mã đơn hàng không hợp lệ.");
            }

            var listDH = db.DDHs.Where(m => m.MaDDH == timkiem).ToList();

            if (!listDH.Any())
            {
                var responseMessage = new { Message = "Không tìm thấy đơn hàng.", SearchTerm = timkiem };
                return Content(HttpStatusCode.NotFound, responseMessage);
            }

            return Ok(listDH);
        }

        // GET: api/donhang/search/theotenkh/tennguoi
        [HttpGet]
        [Route("api/donhang/search/theotenkh/{timkiem}")]
        public IHttpActionResult TimKiemDonHangTheoTen(string timkiem)
        {
            if (string.IsNullOrEmpty(timkiem))
            {
                return BadRequest("Tên khách hàng không hợp lệ.");
            }

            var listDH = db.DDHs.Where(m => m.TenNguoiNhan.Contains(timkiem)).ToList();

            if (!listDH.Any())
            {
                var responseMessage = new { Message = "Không tìm thấy đơn hàng.", SearchTerm = timkiem };
                return Content(HttpStatusCode.NotFound, responseMessage);
            }

            return Ok(listDH);
        }


        //PUT
        //----------------------------------------------------------------
        // PUT: api/donhang/xacnhandagiao/5
        [HttpPut]
        [Route("api/donhang/xacnhandagiao/{id:int}")]
        public IHttpActionResult XacNhanDaGiao(int id)
        {
            var dh = db.DDHs.Find(id);
            if (dh == null)
            {
                return NotFound();
            }

            dh.TrangThai = 3;
            db.SaveChanges();
            return Ok();
        }

        // PUT: api/donhang/xacnhandh/5
        [HttpPut]
        [Route("api/donhang/xacnhandh/{id:int}")]
        public IHttpActionResult XacNhanDH(int id)
        {
            var dh = db.DDHs.Find(id);
            if (dh == null)
            {
                return NotFound();
            }

            dh.TrangThai = 2;
            db.SaveChanges();
            return Ok();
        }

        ////GET: api/donhang/huydh/5
        //[HttpGet]
        //[Route("api/donhang/huydh/{MaDDH:int}")]
        //[ResponseType(typeof(void))]
        //public IHttpActionResult HuyDH(int MaDDH)
        //{
        //    ViewBag.MaDDH = MaDDH;
        //    return Ok();
        //}

        // POST: api/donhang/huydh
        [HttpPost]
        [Route("api/donhang/huydh")]
        public IHttpActionResult HuyDH([FromBody] HuyDHRequest request)
        {
            db.CapNhatHuyDonHangByMaDDH(request.MaDDH, request.LyDo);
            return Ok();
        }

        // GET: api/donhang/dahuy
        //[HttpGet]
        //[Route("api/donhang/dahuy")]
        //[ResponseType(typeof(IQueryable<HuyHang>))]
        //public IHttpActionResult DaHuy()
        //{
        //    var DaHuy = db.HuyHangs.Where(x => x.MaKH == 3);
        //    return Ok(DaHuy.ToList());
        //}

        // GET: api/donhang/xemchitietdh/5
        [HttpGet]
        [Route("api/donhang/xemchitietdh/{idDDH:int}")]
        [ResponseType(typeof(IQueryable<CTDDH>))]
        public IHttpActionResult XemChiTietDH(int idDDH)
        {
            var XemCT = db.GetOrderInfoByMaDDH(idDDH);
            return Ok(XemCT.ToList());
        }
    }

    public class HuyDHRequest
    {
        public int MaDDH { get; set; }
        public string LyDo { get; set; }
    }
}

