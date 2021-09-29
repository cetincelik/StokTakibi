using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using StokTakibiBusiness.Abstract;
using StokTakibiEntities.Concrete;

namespace StokTakibiMvcWebUl.Controllers
{
    //Install-Package Microsoft.AspNetCore.Authentication.Cookies Eklenmesi gereken Paket
    public class KullanicilarController : Controller
    {
        private IKullaniciService _kullaniciService;

        public KullanicilarController(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Kullanicilar k)
        {
            Kullanicilar kullanici = _kullaniciService.KullaniciGirisBilgileri(k);

            if (kullanici != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, k.KullaniciAdi)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);

                


                return RedirectToAction("Index", "Kategoriler");


                //FormsAuthentication.SetAuthCookie(k.KullaniciAdi, false);
                //return RedirectToAction("Index", "Kategoriler");
            }

            ViewBag.hata = "Kullanıcı adı veya şifresi yanlış";
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            //Response.Cookies.Delete();
            // FormsAuthentication.SignOut();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult ResetPassword(Kullanicilar k)
        {
            Kullanicilar kullanici = _kullaniciService.KullaniciResetPassword(k);
            if (kullanici != null)
            {
                Guid rasgele = Guid.NewGuid();
                kullanici.Sifre = rasgele.ToString().Substring(0, 8);
                _kullaniciService.UpdateKullanici(kullanici);
                SmtpClient client = new SmtpClient("smtp.yandex.ru", 587);
                client.EnableSsl = true;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("----------------------@yandex.com", "Şifre sıfırlama");
                mail.To.Add(kullanici.Email);
                mail.IsBodyHtml = true;
                mail.Subject = "Şifre Değiştirme İsteği";
                mail.Body += "Merhaba " + kullanici.AdiSoyadi + "<br/> Kullanıcı Adınız= " + kullanici.KullaniciAdi +
                             "<br/> Şifreniz= " + kullanici.Sifre;

             
                NetworkCredential net = new NetworkCredential("-------------@yandex.com", "--------------");
                client.Credentials = net;
                client.Send(mail);


                return RedirectToAction("Login");
            }
            ViewBag.hata = "E-mail adresi bulunamadı.";
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Kaydol()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Kaydol(Kullanicilar k)
        {
            if (!ModelState.IsValid) return View();
            k.Rol = "U";
                _kullaniciService.CreateKullanici(k);
            return RedirectToAction("Login");
        }


        [HttpGet]
        public IActionResult KayitGuncelle()
        {
            if (User.Identity.IsAuthenticated)
            {
                var kullaniciAdi = User.Identity.Name;
                var model = _kullaniciService.KullaniciAdiKontrolu(kullaniciAdi);
                if (model!=null)
                {
                    return View(model);
                }
                else
                {
                    return View(new Kullanicilar());
                }
            }

            return NotFound();
        }



        [HttpPost]
        public async Task<IActionResult> KayitGuncelle(Kullanicilar k)
        {
             k.Rol = "U";
            _kullaniciService.UpdateKullanici(k);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login","Kullanicilar");
        }
    }
}
