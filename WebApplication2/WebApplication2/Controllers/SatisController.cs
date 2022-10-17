using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.Entity;

namespace WebApplication2.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        mvcstokEntities2 db = new mvcstokEntities2();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(Satislar p)
        {
            db.Satislar.Add(p);
            db.SaveChanges();
            return View("Index");
        }

    }
}