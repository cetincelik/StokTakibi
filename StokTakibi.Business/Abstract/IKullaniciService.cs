using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StokTakibiEntities.Concrete;

namespace StokTakibiBusiness.Abstract
{
    public interface IKullaniciService
    {
        List<Kullanicilar> GetAllKullanicilar();

        Kullanicilar GetKullaniciById(int id);

        void CreateKullanici(Kullanicilar kullanici);

        void UpdateKullanici(Kullanicilar kullanici);

        void DeleteKullanici(Kullanicilar kullanici);

        void SilindiKullanici(Kullanicilar kullanici);

        void AktifMiKullanici(Kullanicilar kullanici);

        Kullanicilar KullaniciGirisBilgileri(Kullanicilar k);

        Kullanicilar KullaniciResetPassword(Kullanicilar k);

        Kullanicilar KullaniciAdiKontrolu(string k);
    }
}
