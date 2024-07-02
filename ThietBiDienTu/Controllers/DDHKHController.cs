using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThietBiDienTu.Areas.Admin.Models;

namespace ThietBiDienTu.Controllers
{
    public class DDHKHController : Controller
    {
        private ThietBiDienTuEntities1 db = new ThietBiDienTuEntities1();

        // GET: /DDHKH/
        public ActionResult Index()
        {
            if (Session["TaiKhoan"] != null)
            {
                var User = (KhachHang)Session["TaiKhoan"];
                int idUser = User.MaKH;
                var ddh = db.DDHs.Include(d => d.KhachHang).Include(d => d.MaGiamGia1).Include(d => d.NhaVanChuyen).ToList();
                return View(ddh.ToList());
            }
            else
            {
                return RedirectToAction("DangNhap", "TrangChu");
            }
        }

        public ActionResult ChoXacNhan()
        {
            if (Session["TaiKhoan"] != null)
            {
                var User = (KhachHang)Session["TaiKhoan"];
                int idUser = User.MaKH;
                var choxacnhan = db.DDHs.Where(x => x.MaKH == idUser && x.TrangThai == 1);
                return View(choxacnhan.ToList());
            }
            else
            {
                return RedirectToAction("DangNhap", "TrangChu");
            }
        }

        public ActionResult CTChoXacNhan(int idDDH)
        {
            if (Session["TaiKhoan"] != null)
            {
                var User = (KhachHang)Session["TaiKhoan"];
                int idUser = User.MaKH;
                var CTchoxacnhan = db.GetOrderInfoByCustomerIdAndOrderIDAndStatus(idUser, idDDH, 1);
                return View(CTchoxacnhan.ToList());
            }
            else
            {
                return RedirectToAction("DangNhap", "TrangChu");
            }
        }

        public ActionResult DangGiaoHang()
        {
            if (Session["TaiKhoan"] != null)
            {
                var User = (KhachHang)Session["TaiKhoan"];
                int idUser = User.MaKH;
                var dangGH = db.DDHs.Where(x => x.MaKH == idUser && x.TrangThai == 2);
                return View(dangGH.ToList());
            }
            else
            {
                return RedirectToAction("DangNhap", "TrangChu");
            }
        }

        public ActionResult CTDangGiaoHang(int idDDH)
        {
            if (Session["TaiKhoan"] != null)
            {
                var User = (KhachHang)Session["TaiKhoan"];
                int idUser = User.MaKH;
                var CTdangGH = db.GetOrderInfoByCustomerIdAndOrderIDAndStatus(idUser, idDDH, 2);
                return View(CTdangGH.ToList());
            }
            else
            {
                return RedirectToAction("DangNhap", "TrangChu");
            }
        }

        public ActionResult DaHoanThanh()
        {
            if (Session["TaiKhoan"] != null)
            {
                var User = (KhachHang)Session["TaiKhoan"];
                int idUser = User.MaKH;
                var DaHoanThanh = db.GetOrderInfoByCustomerIdAndStatus(idUser, 3);
                return View(DaHoanThanh.ToList());
            }
            else
            {
                return RedirectToAction("DangNhap", "TrangChu");
            }
        }

        public ActionResult CTDaHoanThanh(int idDDH)
        {
            if (Session["TaiKhoan"] != null)
            {
                var User = (KhachHang)Session["TaiKhoan"];
                int idUser = User.MaKH;
                var CTDaHoanThanh = db.GetOrderInfoByCustomerIdAndOrderIDAndStatus(idUser, idDDH, 3);
                return View(CTDaHoanThanh.ToList());
            }
            else
            {
                return RedirectToAction("DangNhap", "TrangChu");
            }
        }

        public ActionResult HuyDon(int MaDDH)
        {
            ViewBag.LyDoHuyDon = new SelectList(new List<string>
            {
                "Thời gian giao hàng quá lâu",
                "Muốn thêm/xóa sản phẩm trong đơn hàng",
                "Muốn thay đổi/gặp vấn đề với hình thức thanh toán",
                "Thay đổi ý",
                "Tìm thấy nơi khác giá tốt hơn",
                "Thay đổi địa chỉ giao hàng"
            });

            return View(new HuyHang { MaDDH = MaDDH });
        }

        [HttpPost]
        public ActionResult HuyDon(int MaDDH, String LyDo)
        {
            if (Session["TaiKhoan"] != null)
            {
                var User = (KhachHang)Session["TaiKhoan"];
                int idUser = User.MaKH;

                db.CapNhatHuyDonHang(idUser, MaDDH, LyDo);
                return RedirectToAction("Index", "DDHKH");
            }
            else
            {
                return RedirectToAction("DangNhap", "TrangChu");
            }
        }

        public ActionResult DaHuy()
        {
            if (Session["TaiKhoan"] != null)
            {
                var User = (KhachHang)Session["TaiKhoan"];
                int idUser = User.MaKH;

                var dsHuy = db.sp_HienThiHuyDH(idUser);
                return View(dsHuy.ToList());
            }
            else
            {
                return RedirectToAction("DangNhap", "TrangChu");
            }
        }

        public ActionResult CTDaHuy(int idDDH)
        {
            if (Session["TaiKhoan"] != null)
            {
                var User = (KhachHang)Session["TaiKhoan"];
                int idUser = User.MaKH;
                var CTDaHuy = db.GetOrderInfoByCustomerIdAndOrderIDAndStatus(idUser, idDDH, 4);
                return View(CTDaHuy.ToList());
            }
            else
            {
                return RedirectToAction("DangNhap", "TrangChu");
            }
        }

        // GET: /DDHKH/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DDH ddh = db.DDHs.Find(id);
            if (ddh == null)
            {
                return HttpNotFound();
            }
            return View(ddh);
        }

        // GET: /DDHKH/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH");
            ViewBag.MaGiamGia = new SelectList(db.MaGiamGias, "MaGiamGia1", "TenMGG");
            ViewBag.MaNVC = new SelectList(db.NhaVanChuyens, "MaNVC", "TenNVC");
            return View();
        }

        // POST: /DDHKH/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDDH,NgayDat,TrangThai,MaGiamGia,ThanhTien,SDTNguoiNhan,MaNVC,MaKH,TenNguoiNhan,SoNha,TenDuong,PhuongXa,QuanHuyen,TinhThanh,GhiChu")] DDH ddh)
        {
            if (ModelState.IsValid)
            {
                db.DDHs.Add(ddh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH", ddh.MaKH);
            ViewBag.MaGiamGia = new SelectList(db.MaGiamGias, "MaGiamGia1", "TenMGG", ddh.MaGiamGia);
            ViewBag.MaNVC = new SelectList(db.NhaVanChuyens, "MaNVC", "TenNVC", ddh.MaNVC);
            return View(ddh);
        }

        // GET: /DDHKH/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DDH ddh = db.DDHs.Find(id);
            if (ddh == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH", ddh.MaKH);
            ViewBag.MaGiamGia = new SelectList(db.MaGiamGias, "MaGiamGia1", "TenMGG", ddh.MaGiamGia);
            ViewBag.MaNVC = new SelectList(db.NhaVanChuyens, "MaNVC", "TenNVC", ddh.MaNVC);
            return View(ddh);
        }

        // POST: /DDHKH/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDDH,NgayDat,TrangThai,MaGiamGia,ThanhTien,SDTNguoiNhan,MaNVC,MaKH,TenNguoiNhan,SoNha,TenDuong,PhuongXa,QuanHuyen,TinhThanh,GhiChu")] DDH ddh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ddh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH", ddh.MaKH);
            ViewBag.MaGiamGia = new SelectList(db.MaGiamGias, "MaGiamGia1", "TenMGG", ddh.MaGiamGia);
            ViewBag.MaNVC = new SelectList(db.NhaVanChuyens, "MaNVC", "TenNVC", ddh.MaNVC);
            return View(ddh);
        }

        // GET: /DDHKH/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DDH ddh = db.DDHs.Find(id);
            if (ddh == null)
            {
                return HttpNotFound();
            }
            return View(ddh);
        }

        // POST: /DDHKH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DDH ddh = db.DDHs.Find(id);
            db.DDHs.Remove(ddh);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
