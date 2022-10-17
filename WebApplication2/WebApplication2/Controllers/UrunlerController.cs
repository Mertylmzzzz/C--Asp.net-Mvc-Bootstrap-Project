using System.Collections.Generic;
using System.Linq;
using System.Web.WebPages.Html;
using WebApplication2.Models.Entity;
using System.Web.Mvc;
using SelectListItem = System.Web.Mvc.SelectListItem;
using PagedList.Mvc;
using PagedList;

namespace WebApplication2.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler
        mvcstokEntities2 db = new mvcstokEntities2();
        public ActionResult Index(int sayfa=1)
        {
            var degerler = db.Urunler.ToList().ToPagedList(sayfa, 5);

            //var degerler = db.Urunler.ToList();
            return View(degerler);


        }
        [HttpGet]
        public ActionResult YeniUrunler(Urunler p1)
        {

            List<SelectListItem> deger = (from i in db.Kategoriler.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.Kategoriad,
                                              Value = i.Kategoriid.ToString()
                                          }).ToList();
            ViewBag.dgr = deger;


            return View();

        }
        [HttpPost]
        public ActionResult Yeniurunler(Urunler p1)
        {
            var ktg = db.Kategoriler.Where(m => m.Kategoriid == p1.Kategoriler.Kategoriid).FirstOrDefault();
            p1.Kategoriler = ktg;
            db.Urunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Sil(int id)
        {
            var urunler = db.Urunler.Find(id);
            db.Urunler.Remove(urunler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun=db.Urunler.Find(id);
            List<SelectListItem> deger = (from i in db.Kategoriler.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.Kategoriad,
                                              Value = i.Kategoriid.ToString()
                                          }
                                          ).ToList();
            ViewBag.dgr = deger;

            return View("UrunGetir",urun);  
        }
        public ActionResult Guncelle(Urunler p)
        {
            var urun = db.Urunler.Find(p.Urunid);
            urun.Urunad = p.Urunad;
            //urun.Urunkategori = p.Urunkategori;
            urun.Fiyat = p.Fiyat;
            urun.stok= p.stok;
            var ktg = db.Kategoriler.Where(m => m.Kategoriid == p.Kategoriler.Kategoriid).FirstOrDefault();
            urun.Urunkategori = ktg.Kategoriid;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}