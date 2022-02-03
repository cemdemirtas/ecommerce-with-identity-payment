using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebApplication5.Models.Entity;
using System.Net;
using System.Data;
using System.IO;
using System.Web.Security;

namespace WebApplication5.Controllers
{
    [Authorize(Roles = "admin")]
    public class ProductController : Controller
    {
        mvcEntities db = new mvcEntities();

        // GET: Product
        public ActionResult Index()
        {

            var products = db.tbl_urunler.Include(p => p.tbl_marka).Include(p => p.tbl_kategori);
            return View(products.ToList());
            if (products == null) // An unhandled exception of type 'System.NullReferenceException' occurred in ...
            {
                return HttpNotFound(); // linq's code getting null data therefore we return HttpNotFound() method when sytem put null data.
            }
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //  tbl_urunler product = new tbl_urunler();
            var product = db.tbl_urunler.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.kategoriid = new SelectList(db.tbl_kategori, "id", "kategoriad");  // we called dropdownlist by viewbag method 
            ViewBag.markaid = new SelectList(db.tbl_marka, "id", "markaadi");      //first one "value" the other one corresponding "text" of value.
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tbl_urunler urunler, HttpPostedFileBase picfile)
        {
            string path = Path.Combine("/Content/images/" + picfile.FileName);
            picfile.SaveAs(Server.MapPath(path));
            urunler.urunresim = picfile.FileName.ToString();
            db.tbl_urunler.Add(urunler);
            db.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Delete(int? id)
        {
            tbl_urunler Product = db.tbl_urunler.Find(id);

            if (Product == null)
            {
                return HttpNotFound();
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            return View(Product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(int id, tbl_urunler urunler)
        {
            urunler = db.tbl_urunler.Find(id);
            db.tbl_urunler.Remove(urunler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            tbl_urunler urunler = new tbl_urunler();
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                urunler = db.tbl_urunler.Find(id);
                if (urunler == null)
                {
                    return HttpNotFound();
                }
                ViewBag.markaid = new SelectList(db.tbl_marka, "id", "markaadi", urunler.markaid); // Enumerable list + "value" + "textvalue" + SelectedObjectValue
                ViewBag.kategoriid = new SelectList(db.tbl_kategori, "id", "kategoriad", urunler.kategoriid);
                return View(urunler);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id,[Bind(Include ="urunid,urunad,urunaciklama,urunresim,urunfiyat,urunstok,kategoriid,markaid")] tbl_urunler urunler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(urunler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.markaid = new SelectList(db.tbl_marka, "id", "markaadi", urunler.markaid);
            ViewBag.kategoriid = new SelectList(db.tbl_kategori, "id", "kategoriad", urunler.kategoriid);
            return View(urunler);

        }
    }
}