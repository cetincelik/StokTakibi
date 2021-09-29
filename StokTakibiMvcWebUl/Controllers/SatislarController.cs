using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StokTakibiBusiness.Abstract;
using StokTakibiEntities.Concrete;

namespace StokTakibiMvcWebUl.Controllers
{
    public class SatislarController : Controller
    {
        private ISatisService _satisService;
        private ISepetService _sepetService;
        private IUrunService _urunService;
        private IKullaniciService _kullaniciService;
        private IKategoriService _kategoriService;
        private IMarkaService _markaService;
        private IBirimService _birimService;

        public SatislarController(ISatisService satisService, ISepetService sepetService, IUrunService urunService,
            IKullaniciService kullaniciService, IKategoriService kategoriService, IMarkaService markaService, IBirimService birimService)
        {
            _satisService = satisService;
            _sepetService = sepetService;
            _urunService = urunService;
            _kullaniciService = kullaniciService;
            _kategoriService = kategoriService;
            _markaService = markaService;
            _birimService = birimService;
        }

        public IActionResult Index()
        {

            if (User.Identity.IsAuthenticated)
            {
                var kullaniciadi = User.Identity.Name;
                Kullanicilar kullanici = _kullaniciService.KullaniciAdiKontrolu(kullaniciadi);
                
                if (kullanici.Rol == "A")
                {
                    List<Satislar> satislar = _satisService.GetAllSatislar();
                    foreach (var item in satislar)
                    {

                        Sepet s = new Sepet();
                        s = _sepetService.GetSepetById((int)item.SepetID);
                        item.Sepet = s;

                        Urunler u = new Urunler();
                        u = _urunService.GetUrunById((int)item.Sepet.UrunID);
                        item.Sepet.Urunler = u;

                        Kullanicilar k = new Kullanicilar();
                        k = _kullaniciService.GetKullaniciById((int)item.Sepet.KullaniciID);
                        item.Sepet.Kullanicilar = k;

                        Birimler b = new Birimler();
                        b = _birimService.GetBirimById((int)item.Sepet.Urunler.BirimID);
                        item.Sepet.Urunler.Birimler = b;

                    }
                    


                    return View(satislar);

                }
                else
                {

                    List<Satislar> sepetListesi = _satisService.KullaniciIDGoreSatisGetir(kullanici.ID);

                    foreach (var item in sepetListesi)
                    {


                        Sepet s = new Sepet();
                        s = _sepetService.GetSepetById((int) item.SepetID);
                        item.Sepet = s;

                        Urunler u = new Urunler();
                        u = _urunService.GetUrunById((int) item.Sepet.UrunID);
                        item.Sepet.Urunler = u;

                        Kullanicilar k = new Kullanicilar();
                        k = _kullaniciService.GetKullaniciById((int) item.Sepet.KullaniciID);
                        item.Sepet.Kullanicilar = k;

                        Birimler b = new Birimler();
                        b = _birimService.GetBirimById((int) item.Sepet.Urunler.BirimID);
                        item.Sepet.Urunler.Birimler = b;
                    }

                    return View(sepetListesi);
                }

            }

            return NotFound();
        }


        [HttpGet]
        public IActionResult SatinAl(decimal Tutar)
        {
            if (User.Identity.IsAuthenticated)
            {
                var kullaniciadi = User.Identity.Name;
                Kullanicilar kullanici = _kullaniciService.KullaniciAdiKontrolu(kullaniciadi);

                List<Sepet> sepetListesi = _sepetService.KullaniciIDGoreSepetGetir(kullanici.ID);

                foreach (var item in sepetListesi)
                {

                    Urunler u = new Urunler();
                    u = _urunService.GetUrunById((int)item.UrunID);
                    item.Urunler = u;

                    Birimler b = new Birimler();
                    b = _birimService.GetBirimById((int)item.Urunler.BirimID);
                    item.Urunler.Birimler = b;

                    Kategoriler k = new Kategoriler();
                    k = _kategoriService.GetKategoriById((int)item.Urunler.KategoriID);
                    item.Urunler.Kategoriler = k;

                    Markalar m = new Markalar();
                    m = _markaService.GetMarkaById((int)item.Urunler.MarkaID);
                    item.Urunler.Markalar = m;
                }

                if (sepetListesi != null)
                {
                    if (sepetListesi.Count == 0)
                    {
                        ViewBag.Tutar = "Sepetinizde ürün bulunmuyor";
                    }
                    else if (sepetListesi.Count != 0)
                    {
                        foreach (var item in sepetListesi)
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

                    return View(sepetListesi);
                }


            }
            return NotFound();

        }

        [HttpPost]
        public IActionResult SatinAl()
        {
            var kullaniciadi = User.Identity.Name;
            Kullanicilar kullanici = _kullaniciService.KullaniciAdiKontrolu(kullaniciadi);

            List<Sepet> sepetList = _sepetService.KullaniciIDGoreSepetGetir(kullanici.ID);

            foreach (var item in sepetList)
            {

                Urunler u = new Urunler();
                u = _urunService.GetUrunById((int)item.UrunID);
                item.Urunler = u;

                Birimler b = new Birimler();
                b = _birimService.GetBirimById((int)item.Urunler.BirimID);
                item.Urunler.Birimler = b;

                Kategoriler k = new Kategoriler();
                k = _kategoriService.GetKategoriById((int)item.Urunler.KategoriID);
                item.Urunler.Kategoriler = k;

                Markalar m = new Markalar();
                m = _markaService.GetMarkaById((int)item.Urunler.MarkaID);
                item.Urunler.Markalar = m;
            }


            int row = 0;
            foreach (var item in sepetList)
            {
                if (item.AktifMi == true && item.SilindiMi == false)
                {
                    _sepetService.AktifMiSepet(item);

                    Satislar satis = new Satislar
                    {
                        SepetID = sepetList[row].ID,
                        BankodNo = sepetList[row].Urunler.BankodNo,
                        BirimFiyati = sepetList[row].BirimFiyati,
                        Miktari = sepetList[row].Miktari,
                        ToplamFiyati = sepetList[row].ToplamFiyati,
                        KDV = (int)sepetList[row].Urunler.KDV,
                        Tarih = DateTime.Now,
                        Saat = DateTime.Now

                    };
                    _satisService.CreateSatis(satis);
                    
                }
                row++;
            }

            foreach (var item in sepetList)
            {
                Urunler urun = _urunService.GetUrunById(item.Urunler.ID);
                Sepet s = _sepetService.GetSepetById(item.ID);
                if (urun != null && urun.AktifMi == true && urun.SilindiMi == false)
                {
                    urun.Miktari = urun.Miktari - item.Miktari;
                    urun.AktifMi = false;
                    _sepetService.MiktarSifirla(s);
                    _urunService.UpdateUrun(urun);

                }

            }

            return RedirectToAction("Index", "Sepet");
        }
    }


}
