using Microsoft.AspNet.Identity;
using StickItFy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StickItFy.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStickerToCart(int id)
        {

            var currentUserId = HttpContext.User.Identity.GetUserId();
            var sticker = db.Stickers.Find(id);
            var cart = db.Carts.Where( c => c.ClientId == currentUserId).FirstOrDefault();
            cart.Stickers.Add(sticker);
            db.SaveChanges();
            return RedirectToAction("ShowListItemsInCart", "Cart");
        }

        public ActionResult ShowListItemsInCart()
        {
            var currentUserId = HttpContext.User.Identity.GetUserId();
            var cart = db.Carts.Where(c => c.ClientId == currentUserId).FirstOrDefault();

            return View(cart);
        }
     
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var currentUserId = HttpContext.User.Identity.GetUserId();
            var sticker = db.Stickers.Find(id);
            var cart = db.Carts.Where(c => c.ClientId == currentUserId).FirstOrDefault();
            cart.Stickers.Remove(sticker);
            db.SaveChanges();
            return RedirectToAction("ShowListItemsInCart", "Cart");
        }

    }
}