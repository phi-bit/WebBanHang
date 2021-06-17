using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PROJECT_DEMO.Models;

namespace PROJECT_DEMO.Controllers
{
    public class TinTucController : Controller
    {
        TintucContext db = new TintucContext();
        //Get: Data
        public ActionResult Index()
        {
            var all_LoaiTinTuc = db.TinTuc.ToList();
            return View(all_LoaiTinTuc);
        }

        public ActionResult Details(int id)
        {
            var D_tin = db.TinTuc.First(m => m.IdTin == id);
            return View(D_tin);
        }
        // GET: Hàm Create(get)
        public ActionResult Create()
        {
            var L_tin = from lt in db.TheLoaiTin select lt;
            ViewData["LoaiTin"] = new SelectList(db.TheLoaiTin, "IdLoai", "TenTheLoai");
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, TinTuc TTin)
        {
            // Gán các giá tị người dùng nhập liệu cho các biến 
            var N_tin = collection["TieuDeTin"];
            var L_tin = int.Parse(collection["LoaiTin"]);
            var C_tin = collection["NoiDungTin"];
            if (String.IsNullOrEmpty(N_tin))
            {
                ViewData["Loi"] = "Tiêu đề tin không được để trống";
            }
            else if (String.IsNullOrEmpty(C_tin))
            {
                ViewData["Loi1"] = "Bạn hãy nhập nội dung cho tin";
            }
            else
            {
                //Gán giá trị cho đối tượng được tạo mới (TTin)
                TTin.IDLoai = L_tin;
                TTin.TieuDeTin = N_tin;
                TTin.NoiDungTin = C_tin;
                //Thực hiện tạo mới 
                db.TinTuc.Add(TTin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return Create();
        }
        //EDIT
        public ActionResult Edit(int id)
        {
            var E_tin = db.TinTuc.First(m => m.IdTin == id);
            var L_tin = from lt in db.TheLoaiTin select lt;
            ViewData["Loaitin"] = new SelectList(db.TheLoaiTin, "IDLoai","Tentheloai");
            return View(E_tin);
        }
        // POST: Hàm Edit(post) nhận dữ liệu mà người dùng 
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var N_tin = collection["Tieudetin"];
            var L_tin = int.Parse(collection["Loaitin"]);
            var C_tin = collection["Noidungtin"];
            var Etin = db.TinTuc.First(m => m.IdTin == id);
            if (String.IsNullOrEmpty(N_tin))
            {
                ViewData["Loi"] = "Tiêu đề tin không được để trống";
            }
            else if (String.IsNullOrEmpty(C_tin))
            {
                ViewData["Loi1"] = "Bạn hãy nhập nội dung cho tin";
            }
            else
            {
                Etin.IDLoai = L_tin;
                Etin.TieuDeTin = N_tin;
                Etin.NoiDungTin = C_tin;
                UpdateModel(Etin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }
        //DELETE
        public ActionResult Delete(int id)
        {
            var D_Tin = db.TinTuc.First(m => m.IdTin == id);
            return View(D_Tin);
        }
        // POST: Hàm Delete(get) thực hiện lệnh xóa 
        // với tham số truyền vào là id mục cần xóa 
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_tin = db.TinTuc.Where(m => m.IdTin == id).First();
            db.TinTuc.Remove(D_tin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
