using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PROJECT_DEMO.Models;

namespace PROJECT_DEMO.Controllers
{
    public class TheLoaiTinController : Controller
    {
        TintucContext db = new TintucContext();
        public ActionResult Index()
        {
            var all_LoaiTinTuc = db.TheLoaiTin.ToList();
            return View(all_LoaiTinTuc);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        //Nhận dữ liệu từ người dùng
        [HttpGet]
        public ActionResult Take()
        {
            var list = db.TheLoaiTin.Take(10).Where(p => p.TenTheLoai == "Thế Giới").ToList();
            return View(list);
        }

        public ActionResult Details(int id)
        {
            var Details_tin = db.TheLoaiTin.Where(m => m.IDLoai == id).FirstOrDefault();
            return View(Details_tin);
        }

        //Nhận dữ liệu từ người dùng
        
        [HttpPost]
        public ActionResult Create(TheLoaiTin theloai)
        {
            if (ModelState.IsValid)
            {
                db.TheLoaiTin.Add(theloai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(theloai);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var EB_Tin = db.TheLoaiTin.First(m => m.IDLoai == id);
            return View(EB_Tin);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var Ltin = db.TheLoaiTin.First(m => m.IDLoai == id);
            var E_Loaitin = collection["Tentheloai"];
            //Vi ta su dung doi tuong Id cua bien Ltin = Id truyen vao
            Ltin.IDLoai = id;
            if (string.IsNullOrEmpty(E_Loaitin))
            {
                ViewData["Loi"] = "The loai tin khong duoc de trong";
            }
            else
            {
                Ltin.TenTheLoai = E_Loaitin;
                UpdateModel(Ltin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var D_Tin = db.TheLoaiTin.First(m => m.IDLoai == id);
            return View(D_Tin);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_tin = db.TheLoaiTin.Where(m => m.IDLoai == id).First();
            //Xoa
            db.TheLoaiTin.Remove(D_tin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}