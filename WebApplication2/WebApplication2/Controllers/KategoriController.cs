using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.Entity;


namespace WebApplication2.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        mvcstokEntities2 db = new mvcstokEntities2();
        public ActionResult Index(string p)
        {
           var degerler=from d in db.Kategoriler select d;
            if(!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.Kategoriad.Contains(p));
            }
            return View(degerler.ToList());
            // var değerler = db.Kategoriler.ToList();
            //var degerler = db.Kategoriler.ToList().ToPagedList(sayfa, 4);
           // return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(Kategoriler k1)
        {
            if(!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            else
            {
                db.Kategoriler.Add(k1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
        }
        public ActionResult Sil(int id)
        {
            var kategori=db.Kategoriler.Find(id);
            db.Kategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");   
        }
        public ActionResult Kategorigetir(int id)
        {
            var ktgr = db.Kategoriler.Find(id);
            return View("KategoriGetir",ktgr);
        }
        public ActionResult Guncelle(Kategoriler p1)
        {
            var ktg = db.Kategoriler.Find(p1.Kategoriid);
            ktg.Kategoriad = p1.Kategoriad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}