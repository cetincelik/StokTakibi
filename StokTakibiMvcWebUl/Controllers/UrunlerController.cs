using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using StokTakibiBusiness.Abstract;
using StokTakibiEntities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace StokTakibiMvcWebUl.Controllers
{
    [Authorize]
    public class UrunlerController : Controller
    {
        private IUrunService _urunService;
        private IKategoriService _kategoriService;
        private IBirimService _birimService;
        private IMarkaService _markaService;

       
        public UrunlerController(IUrunService urunService, IKategoriService kategoriService, IBirimService birimService, IMarkaService markaService)
        {
            _urunService = urunService;
            _kategoriService = kategoriService;
            _birimService = birimService;
            _markaService = markaService;
        }
        [Authorize]
        public IActionResult Index(string ara)
        {
            List<Urunler> model = _urunService.GetAllUrunler();

            if (!string.IsNullOrEmpty(ara))
            {
                model = _urunService.UrunAra(ara);
            }

            foreach (var item in model)
            {
                Kategoriler k = new Kategoriler();
                k = _kategoriService.GetKategoriById((int)item.KategoriID);
                item.Kategoriler = k;

                Birimler b = new Birimler();
                b = _birimService.GetBirimById((int)item.BirimID);
                item.Birimler = b;

                Markalar m = new Markalar();
                m = _markaService.GetMarkaById((int)item.MarkaID);
                item.Markalar = m;
            }


            return View(model);
        }

        List<SelectListItem> kategoriDoldur()
        {
            //bir list oluştuyoruz selectlistitem tipi alacak
            List<SelectListItem> kategori = new List<SelectListItem>();
            //foreach ile db.Categories deki kategorileri listemize ekliyoruz
            foreach (var item in _kategoriService.GetAllKategoriler())
            {   //Text = Görünen kısımdır. Kategori ismini yazdıyoruz
                //Value = Değer kısmıdır. ID değerini atıyoruz
                kategori.Add(new SelectListItem
                {
                    Text = item.KategoriAdi,
                    Value = item.ID.ToString()
                });
            }

            return kategori;
        }
        List<SelectListItem> birimDoldur()
        {
            
            List<SelectListItem> birim = new List<SelectListItem>();
           
            foreach (var item in _birimService.GetAllBirimler())
            {   
                birim.Add(new SelectListItem
                {
                    Text = item.Birim,
                    Value = item.ID.ToString()
                });
            }

            return birim;
        }

        List<SelectListItem> markaDoldur()
        {
            
            List<SelectListItem> marka = new List<SelectListItem>();
           
            foreach (var item in _markaService.GetAllMarkalar())
            {  

                marka.Add(new SelectListItem
                {
                    Text = item.MarkaAdi,
                    Value = item.ID.ToString()
                });
            }

            return marka;
        }
        //[HttpPost]
        //public JsonResult GetMarka(int id)
        //{
        //    Urunler model = new Urunler();

        //    List<SelectListItem> marka = new List<SelectListItem>();

        //    Kategoriler kategori = _kategoriService.GetKategoriById(id);

        //    foreach (var item in _markaService.GetAllMarkalar())
        //    {
        //        if (item.KategoriID == kategori.ID)
        //        {

        //            marka.Add(new SelectListItem
        //            {
        //                Text = item.MarkaAdi,
        //                Value = item.ID.ToString()
        //            });

        //        }

        //    }

        //    marka.Insert(0, new SelectListItem { Text = "Seçiniz", Value = "" });
        //    return Json(marka);



        //    //model.Markalar = (from x in markaliste
        //    //                  select new SelectListItem
        //    //                  {
        //    //                      Text = x.MarkaAdi,
        //    //                      Value = x.ID.ToString()
        //    //                  }).ToList();
        //    //model.Markalar.Insert(0, new SelectListItem { Text = "Seçiniz", Value = "" });
        //    //return Json(model.Markalar, JsonRequestBehavior.AllowGet);
        //}
        [HttpGet]
        public IActionResult UrunEkle()
        {
           ViewBag.marka = markaDoldur();
            ViewBag.kategori = kategoriDoldur();
            ViewBag.birim = birimDoldur();
            return View();
        }

        [HttpPost]
        public IActionResult UrunEkle(Urunler p)
        {
            
            if (!ModelState.IsValid)
            {
                ViewBag.kategori = kategoriDoldur();
                ViewBag.birim = birimDoldur();
                ViewBag.marka = markaDoldur();
                return View("UrunEkle");

            }
            _urunService.CreateUrun(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult MiktarEkle(int id)
        {
            Urunler model = _urunService.GetUrunById(id);
            return View();
        }

        [HttpPost]
        public IActionResult MiktarEkle(Urunler p)
        {
            Urunler model = _urunService.GetUrunById(p.ID);
            model.Miktari = model.Miktari + p.Miktari;
            _urunService.UpdateUrun(model);
           
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UrunGuncelle(int id)
        {
           
            ViewBag.marka = markaDoldur();
            ViewBag.kategori = kategoriDoldur();
            ViewBag.birim = birimDoldur();
            Urunler model = _urunService.GetUrunById(id);
            //notfound olmayan bir sayfaya gidmeye çalışırsa hata döndürür
            if (model == null) return NotFound();
            return View(model);
        }
        
        [HttpPost]
        public IActionResult UrunGuncelle(Urunler p)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.kategori = kategoriDoldur();
                ViewBag.birim = birimDoldur();
                ViewBag.marka = markaDoldur();
                return View("UrunGuncelle");

            }
            _urunService.UpdateUrun(p);

            return RedirectToAction("Index");
        }

        public IActionResult UrunSil(Urunler p)
        {
            _urunService.SilindiUrun(p);
            return RedirectToAction("Index");
        }

        public IActionResult UrunAktifMi(Urunler p)
        {
            _urunService.AktifMiUrun(p);
            return RedirectToAction("Index");
        }

    }
}
