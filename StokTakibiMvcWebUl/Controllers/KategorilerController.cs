using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using StokTakibiBusiness.Abstract;
using StokTakibiEntities.Concrete;

namespace StokTakibiMvcWebUl.Controllers
{

    [Authorize]
    public class KategorilerController : Controller
    {
        private IKategoriService _kategoriService;

        public KategorilerController(IKategoriService kategoriService)
        {
            _kategoriService = kategoriService;
        }
        //[Authorize(Policy = "Rol")]
        public IActionResult Index()
        {
            return View(_kategoriService.GetAllKategoriler());
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategoriler p)
        {
            //model eğer doğrulanmazsa aynı sayfada kalması için.
            if (!ModelState.IsValid)
            {
                return View("KategoriEkle");
            }

            _kategoriService.CreateKategori(p);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult KategoriGuncelle(int id)
        {

            Kategoriler kategori = _kategoriService.GetKategoriById(id);
            //notfound olmayan bir sayfaya gidmeye çalışırsa hata döndürür
            if (kategori == null) return NotFound();

            return View(kategori);
        }

        [HttpPost]
        public ActionResult KategoriGuncelle(Kategoriler p)
        {
            if (!ModelState.IsValid)
            {
                return View("KategoriGuncelle");
            }

            _kategoriService.UpdateKategori(p);
            return RedirectToAction("Index");
        }


        public ActionResult KategoriSil(Kategoriler kategeri)
        {

            _kategoriService.SilindiMiKategori(kategeri);

            return RedirectToAction("Index");
        }
        public ActionResult KategoriAktifMi(Kategoriler kategeri)
        {

            _kategoriService.AktifMiKategori(kategeri);

            return RedirectToAction("Index");
        }
    }
}
