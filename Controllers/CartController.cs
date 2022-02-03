using WebApplication5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models.Entity;
namespace WebApplication5.Controllers
{
    public class CartController : Controller
    {
        mvcEntities db = new mvcEntities();


        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }
        public ActionResult AddToCard(int id)
        {
            var urunler = db.tbl_urunler.FirstOrDefault(i => i.urunid == id);
            if (urunler != null)
            {
                GetCart().AddProduct(urunler, 1);
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");

        }

        public ActionResult RemoveFromCart(int id)
        {
            var urunler = db.tbl_urunler.FirstOrDefault(i => i.urunid == id);
            if (urunler != null)
            {
                GetCart().DeleteProduct(urunler);
            }
            return RedirectToAction("Index");

        }


        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart(); // create new list
                Session["Cart"] = cart;
            }
            return cart;
        }
        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }
    }
}