using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication2.Models.Entity;
using PagedList.Mvc;
using PagedList;
namespace WebApplication2.Controllers
{
    public class MusterilerController : Controller
    {
        // GET: Musteriler
        mvcstokEntities2 db = new mvcstokEntities2();
        public ActionResult Index(int sayfa=1)
        {
            // var degerler = db.Musteriler.ToList();
            var degerler = db.Musteriler.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteriler()
        {
            return View();  
        }
        [HttpPost]
        public ActionResult YeniMusteriler(Musteriler m1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteriler");
            }
            else
            {
                db.Musteriler.Add(m1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Sil(int id)
        {
            var musteriler = db.Musteriler.Find(id);
            db.Musteriler.Remove(musteriler);
            db.SaveChanges();
            return   RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.Musteriler.Find(id);
            return View("MusteriGetir", mus);
        }
        public ActionResult Guncelle(Musteriler p1)
        {
            var must = db.Musteriler.Find(p1.Musteriid);
            must.Musteriad=p1.Musteriad;
            must.Musterisoyad=p1.Musterisoyad;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}