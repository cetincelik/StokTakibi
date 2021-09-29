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
    public class SepetManager: ISepetService
    {
        private ISepetDal _sepetDal;

        public SepetManager(ISepetDal sepetDal)
        {
            _sepetDal = sepetDal;
        }

        public List<Sepet> GetAllSepetler()
        {
            return _sepetDal.GetList();
        }

        public Sepet GetSepetById(int id)
        {
            
            return _sepetDal.Get(p => p.ID == id);
        }
        public List<Sepet> KullanıcıSepeti(int id)
        {

            return _sepetDal.GetList(p => p.KullaniciID == id);
        }
        public List<Sepet> KullaniciIDGoreSepetGetir(int kulaniciID)
        {
            List<Sepet> sepet = _sepetDal.GetList(p => p.KullaniciID == kulaniciID);

            return sepet;
        }

        public Sepet KullaniciIDGoreUrunuSepeteGetir(int kulaniciID, int urun_ID)
        {
            Sepet sepet = _sepetDal.Get(p => p.KullaniciID == kulaniciID && p.UrunID == urun_ID);

            return sepet;
        }

        public void CreateSepet(Sepet sepet)
        {
            sepet.AktifMi = true;
            sepet.SilindiMi = false;
            _sepetDal.Add(sepet);
        }

        public void UpdateSepet(Sepet sepet)
        {
           sepet.AktifMi = true; 
           sepet.SilindiMi = false;
            
            _sepetDal.Update(sepet);
        }

        public void MiktarSifirla(Sepet sepet)
        {
            sepet.AktifMi = sepet.AktifMi;
            sepet.SilindiMi = sepet.SilindiMi;
            sepet.Miktari = 0;
            _sepetDal.Update(sepet);
        }


        public void DeleteSepet(Sepet sepet)
        {
            _sepetDal.Delete(sepet);
        }

        public void SilindiMiSepet(Sepet sepet)
        {
            var k = _sepetDal.Get(x => x.ID == sepet.ID);
            k.SilindiMi = true;
            _sepetDal.Update(k);

        }

        public void AktifMiSepet(Sepet sepet)
        {
            var k = _sepetDal.Get(x => x.ID == sepet.ID);
            
                k.AktifMi = false;
                _sepetDal.Update(k);
        }
    }
}
