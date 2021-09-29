using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using StokTakibiBusiness.Abstract;
using StokTakibiEntities.Concrete;

namespace StokTakibiMvcWebUl.Controllers
{
    public class SepetController : Controller
    {
        private ISepetService _sepetService;
        private IKullaniciService _kullaniciService;
        private IUrunService _urunService;
        private IKategoriService _kategoriService;
        private IMarkaService _markaService;

        public SepetController(ISepetService sepetService, IKullaniciService kullaniciService, IUrunService urunService, IKategoriService kategoriService, IMarkaService markaService)
        {
            _sepetService = sepetService;
            _kullaniciService = kullaniciService;
            _urunService = urunService;
            _kategoriService = kategoriService;
            _markaService = markaService;
        }

        public IActionResult Index(decimal Tutar)
        {
            if (User.Identity.IsAuthenticated)
            {
                var kullaniciadi = User.Identity.Name;
                Kullanicilar kullanici = _kullaniciService.KullaniciAdiKontrolu(kullaniciadi);

                List<Sepet> model = _sepetService.KullaniciIDGoreSepetGetir(kullanici.ID);

                foreach (var item in model)
                {

                    Urunler u = new Urunler();
                    u = _urunService.GetUrunById((int)item.UrunID);
                    item.Urunler = u;

                    Kategoriler k = new Kategoriler();
                    k = _kategoriService.GetKategoriById((int)item.Urunler.KategoriID);
                    item.Urunler.Kategoriler = k;

                    Markalar m = new Markalar();
                    m = _markaService.GetMarkaById((int)item.Urunler.MarkaID);
                    item.Urunler.Markalar = m;
                }

                if (model != null)
                {
                    if (model.Count == 0)
                    {
                        ViewBag.Tutar = "Sepetinizde ürün bulunmuyor";
                    }
                    else if (model.Count != 0)
                    {
                        foreach (var item in model)
                        {
                            if (item.SilindiMi == false && item.AktifMi == true)
                            {
                                Tutar = item.ToplamFiyati + Tutar;
                            }

                        }
                        if (Tutar == 0)
                        {
                            ViewBag.Tutar = "Sepetinizde ürün bulunmuyor";
                        }
                        else
                        {
                            ViewBag.Tutar = "Toplam Tutar= " + Tutar + " TL";
                        }
                    }
                    return View(model);
                }
            }
            return NotFound();
        }

        public IActionResult SepeteEkle(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var kullaniciadi = User.Identity.Name;
                Kullanicilar kullanici = _kullaniciService.KullaniciAdiKontrolu(kullaniciadi);
                Urunler u = _urunService.GetUrunById(id);

                Sepet sepet = _sepetService.KullaniciIDGoreUrunuSepeteGetir(kullanici.ID, id);
                if (kullanici != null)
                {
                    if (sepet != null)
                    {
                        sepet.Miktari++;
                        sepet.BirimFiyati = u.SatisFiyati;
                        sepet.ToplamFiyati = (u.SatisFiyati * sepet.Miktari);
                        _sepetService.UpdateSepet(sepet);
                        return RedirectToAction("Index","Urunler");
                    }
                    else
                    {
                        Sepet s = new Sepet
                        {
                            KullaniciID = kullanici.ID,
                            UrunID = u.ID,
                            Miktari = 1,
                            BirimFiyati = u.SatisFiyati,
                            ToplamFiyati = u.SatisFiyati,
                            Tarih = DateTime.Now,
                            Saat = DateTime.Now
                        };
                        _sepetService.CreateSepet(s);

                        return RedirectToAction("Index","Urunler");

                    }
                }
            }
            return NotFound();
        }

        public IActionResult TotalCount(int? count)
        {
            if (User.Identity.IsAuthenticated)
            {
                var kullaniciadi = User.Identity.Name;
                Kullanicilar kullanici = _kullaniciService.KullaniciAdiKontrolu(kullaniciadi);
                List<Sepet> model = _sepetService.KullaniciIDGoreSepetGetir(kullanici.ID);
                foreach (var item in model)
                {
                    count++;
                }

                ViewBag.Count = count;
                if (count == 0)
                {
                    ViewBag.Count = "";
                }

                return PartialView();
            }
            return NotFound();
        }

        public IActionResult Arttir(int id)
        {
            Sepet s = _sepetService.GetSepetById(id);
            s.Miktari++;
            s.ToplamFiyati = s.BirimFiyati * s.Miktari;
            _sepetService.UpdateSepet(s);

            return RedirectToAction("Index");
        }

        public IActionResult Azalt(int id)
        {
            Sepet s = _sepetService.GetSepetById(id);
            if (s.Miktari == 1)
            {
                s.Miktari--;
                _sepetService.UpdateSepet(s);
                _sepetService.SilindiMiSepet(s);
                return RedirectToAction("Index");

            }
            s.Miktari--;
            s.ToplamFiyati = s.BirimFiyati * s.Miktari;

            _sepetService.UpdateSepet(s);

            return RedirectToAction("Index");
        }

        public void Dinamikmiktar(int id, decimal miktari)
        {
            Sepet s = _sepetService.GetSepetById(id);
            s.Miktari = miktari;
            s.ToplamFiyati = s.BirimFiyati * s.Miktari;
            _sepetService.UpdateSepet(s);
        }

        public IActionResult Sil(int id)
        {
            Sepet s = _sepetService.GetSepetById(id);
            s.Miktari = 0;
            _sepetService.UpdateSepet(s);
            _sepetService.SilindiMiSepet(s);

            return RedirectToAction("Index");
        }

        





    }
}
