using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StickItFy.Models;

namespace StickItFy.Controllers
{
    public class StickersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Stickers
        public ActionResult Index()
        {
            return View(db.Stickers.ToList());
        }

        // GET: Stickers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sticker sticker = db.Stickers.Find(id);
            if (sticker == null)
            {
                return HttpNotFound();
            }
            return View(sticker);
        }

        // GET: Stickers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stickers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ImageUrl,Category,NameOfProduct,Price")] Sticker sticker)
        {
            if (ModelState.IsValid)
            {
                db.Stickers.Add(sticker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sticker);
        }

        // GET: Stickers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sticker sticker = db.Stickers.Find(id);
            if (sticker == null)
            {
                return HttpNotFound();
            }
            return View(sticker);
        }

        // POST: Stickers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ImageUrl,Category,NameOfProduct,Price")] Sticker sticker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sticker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sticker);
        }

        // GET: Stickers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sticker sticker = db.Stickers.Find(id);
            if (sticker == null)
            {
                return HttpNotFound();
            }
            return View(sticker);
        }

        // POST: Stickers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sticker sticker = db.Stickers.Find(id);
            db.Stickers.Remove(sticker);
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
