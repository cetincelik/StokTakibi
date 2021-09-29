using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using StokTakibiBusiness.Abstract;
using StokTakibiEntities.Concrete;

namespace StokTakibiMvcWebUl.Controllers
{
   // [Authorize(Roles = "A")]
    public class MarkalarController : Controller
    {
        private IMarkaService _markaService;
        private IKategoriService _kategoriService;
        private IUrunService _urunService;

        public MarkalarController(IMarkaService markaService, IKategoriService kategoriService)
        {
            _markaService = markaService;
            _kategoriService = kategoriService;
        }




        public IActionResult Index()
        {
            List<Markalar> model = (_markaService.GetAllMarkalar());
            //foreach (var item in model)
            //{
            //    Urunler u= new Urunler();
            //    u = _urunService.GetUrunById((int)item.UrunID);
            //    item.Urunler = u;

            //    Kategoriler k = new Kategoriler();
            //    k = _kategoriService.GetKategoriById((int)item.Urunler.KategoriID);
            //    item.Urunler.Kategoriler = k;
            //}
            return View(model);
        }

        

        //List<SelectListItem> kategoriDoldur()
        //{
        //    //bir list oluştuyoruz selectlistitem tipi alacak
        //    List<SelectListItem> kategori = new List<SelectListItem>();
        //    //foreach ile db.Categories deki kategorileri listemize ekliyoruz
        //    foreach (var item in _kategoriService.GetAllKategoriler())
        //    {   //Text = Görünen kısımdır. Kategori ismini yazdıyoruz
        //        //Value = Değer kısmıdır. ID değerini atıyoruz
        //        kategori.Add(new SelectListItem
        //        {
        //            Text = item.KategoriAdi,
        //            Value = item.ID.ToString()
        //        });
        //    }

        //    return kategori;
        //}


        [HttpGet]
        public IActionResult MarkaEkle()
        {
            
            //Dinamik bir yapı oluşturup kategoriler list mizi view mize göndereceğiz
            //bunun için viewbag kullanıyorum
         //   ViewBag.kategori = kategoriDoldur();
            return View();
        }

        [HttpPost]
        public IActionResult MarkaEkle(Markalar p)
        {
            if (!ModelState.IsValid)
            {
              //  ViewBag.kategori = kategoriDoldur();
                return View();

            }
            _markaService.CreateMarka(p);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult MarkaGuncelle(int id)
        {
          //  ViewBag.kategori = kategoriDoldur();
            Markalar marka = _markaService.GetMarkaById(id);
            return View(marka);
        }

        [HttpPost]
        public IActionResult MarkaGuncelle(Markalar p)
        {
            if (!ModelState.IsValid)
            {
              //  ViewBag.kategori = kategoriDoldur();
                return View("MarkaGuncelle");
            }

            _markaService.UpdateMarka(p);
            return RedirectToAction("Index");
        }

        public IActionResult MarkaSil(Markalar p)
        {
            _markaService.SilindiMarka(p);
            return RedirectToAction("Index");
        }

        public IActionResult MarkaAktifMi(Markalar p)
        {
            _markaService.AktifMiMarka(p);
            return RedirectToAction("Index");
        }
    }
}
