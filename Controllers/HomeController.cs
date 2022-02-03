using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models.Entity;
namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        mvcEntities db = new mvcEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Product()
        {
            return View(db.tbl_urunler.ToList());
        }

        public ActionResult ProductDetails(int id)
        {
            return View(db.tbl_urunler.Where(i => i.urunid == id).FirstOrDefault());
        }

        public ActionResult ProductList(int id)
        {
            return View(db.tbl_urunler.Where(i => i.tbl_kategori.id == id).ToList()); // we define "id" which is have to primary key of relation tables(tbl_ktg)
        }          // filter the tbl urunler by category.. 
    }
}