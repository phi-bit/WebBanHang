using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PROJECT_DEMO.Models;

namespace PROJECT_DEMO.Controllers
{
    public class BackController : Controller
    {
        TintucContext DB = new TintucContext();
        // GET: Back
        public ActionResult Index()
        {
            var all_TinTuc = DB.TinTuc.ToList();
            return View(all_TinTuc);
        }

        //CREATE:

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost] 
        //Thẻ dùng để lấy dữ liệu tương tác của khách hàng
        public ActionResult Create(TheLoaiTin loaitin)
        {
            if (ModelState.IsValid)
            {
                DB.TheLoaiTin.Add(loaitin);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaitin);
        }

    }
}