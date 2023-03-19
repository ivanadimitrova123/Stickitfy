using StickItFy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StickItFy.Controllers
{
    public class ClientController : Controller
  
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Client
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStickerToClient(int id)
        {
            var listStickers = new List<Sticker>();
            db.Stickers.Find(id);

            return View();
        }
    }
}