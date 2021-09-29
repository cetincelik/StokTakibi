using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Query;
using StokTakibiBusiness.Abstract;
using StokTakibiEntities.Concrete;

namespace StokTakibiMvcWebUl.Controllers
{
    //[Authorize]
    public class BirimlerController : Controller
    {
        private IBirimService _birimService;

        public BirimlerController(IBirimService birimService)
        {
            _birimService = birimService;
        }


        public IActionResult Index()
        {
            return View(_birimService.GetAllBirimler());
        }

        [HttpGet]
        public ActionResult BirimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BirimEkle(Birimler p)
        {
            //model eğer doğrulanmazsa aynı sayfada kalması için.
            if (!ModelState.IsValid)
            {
                return View("BirimEkle");
            }
            _birimService.CreateBirim(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult BirimGuncelle(int id)
        {
            if (!ModelState.IsValid) return View();
            Birimler birim = _birimService.GetBirimById(id);
            //notfound olmayan bir sayfaya gidmeye çalışırsa hata döndürür
            if (birim == null) return NotFound();
            return View(birim);
        }

        [HttpPost]
        public ActionResult BirimGuncelle(Birimler p)
        {
            _birimService.UpdateBirim(p);
            return RedirectToAction("Index");
        }


        public ActionResult BirimSil(Birimler p)
        {

            _birimService.SilindiMiBirim(p);

            return RedirectToAction("Index");
        }
        public ActionResult BirimAktifMi(Birimler p)
        {

            _birimService.AktifMiBirim(p);

            return RedirectToAction("Index");
        }


    }
}
