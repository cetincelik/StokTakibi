using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StokTakibiBusiness.Abstract;
using StokTakibiDataAccess.Abstract;
using StokTakibiEntities.Concrete;

namespace StokTakibiBusiness.Concrete
{
   public class KullaniciManager: IKullaniciService
   {
       private IKullaniciDal _kullaniciDal;

       public KullaniciManager(IKullaniciDal kullaniciDal)
       {
           _kullaniciDal = kullaniciDal;
       }


       public List<Kullanicilar> GetAllKullanicilar()
       {
            return _kullaniciDal.GetList();
       }

        public Kullanicilar GetKullaniciById(int id)
        {
            return _kullaniciDal.Get(x =>x.ID == id);
        }

        public void CreateKullanici(Kullanicilar kullanici)
        {
            _kullaniciDal.Add(kullanici);
        }

        public void UpdateKullanici(Kullanicilar kullanici)
        {
            _kullaniciDal.Update(kullanici);
        }

        public Kullanicilar KullaniciGirisBilgileri(Kullanicilar k)
        {
           Kullanicilar kulanici =  _kullaniciDal.Get(x => x.KullaniciAdi == k.KullaniciAdi && x.Sifre == k.Sifre);
           return kulanici;
        }

        public Kullanicilar KullaniciResetPassword(Kullanicilar k)
        {
            Kullanicilar kulanici = _kullaniciDal.Get(x => x.Email == k.Email);
            return kulanici;
        }

        public Kullanicilar KullaniciAdiKontrolu(string k)
        {
            Kullanicilar kulanici = _kullaniciDal.Get(x => x.KullaniciAdi == k);
            return kulanici;
        }


        public void DeleteKullanici(Kullanicilar kullanici)
        {
            _kullaniciDal.Delete(kullanici);
        }

        public void SilindiKullanici(Kullanicilar kullanici)
        {
            throw new NotImplementedException();
        }

        public void AktifMiKullanici(Kullanicilar kullanicis)
        {
            throw new NotImplementedException();
        }
    }
}
