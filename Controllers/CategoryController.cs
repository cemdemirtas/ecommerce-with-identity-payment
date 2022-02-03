using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using WebApplication5.Models.Entity;
using System.Net;
using System.Data.Entity;
namespace WebApplication5.Controllers
{
    public class CategoryController : Controller
    {
        mvcEntities db = new mvcEntities();
        // GET: Category
        public PartialViewResult Details()
        {

            return PartialView(db.tbl_kategori.ToList());
        }

        public ActionResult Index()
        {
            return View(db.tbl_kategori.ToList());


        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tbl_kategori kategori)
        {
            db.tbl_kategori.Add(kategori);
            db.SaveChanges();
            return View(kategori);
        }

        public ActionResult Delete(tbl_kategori Category, int? id)
        {
            if (Category == null)
            {
                return HttpNotFound();
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            return View(Category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id, tbl_kategori kategori)
        {
            kategori = db.tbl_kategori.Find(id);
            db.tbl_kategori.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int? id, tbl_kategori kategori)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            kategori = db.tbl_kategori.Find(id); 
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,kategoriad")] tbl_kategori kategori /*int? id*/)
        {

            //kategori = db.tbl_kategori.Find(id);
            if (ModelState.IsValid)
            {
                db.Entry(kategori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategori);
        }


    }
}