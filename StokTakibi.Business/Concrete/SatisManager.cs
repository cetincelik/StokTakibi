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
    public class SatisManager :ISatisService
    {
        private ISatisDal _satisDal;

        public SatisManager(ISatisDal satisDal)
        {
            _satisDal = satisDal;
        }

        public List<Satislar> KullaniciIDGoreSatisGetir(int kulaniciID)
        {
            List<Satislar> satis = _satisDal.GetList(p => p.Sepet.KullaniciID == kulaniciID);

            return satis;
        }

        public List<Satislar> GetAllSatislar()
        {
            return _satisDal.GetList();
        }

        public Satislar GetSatisById(int id)
        {
            return _satisDal.Get(p => p.ID == id);
        }

        public void CreateSatis(Satislar satis)
        {
            satis.AktifMi = true;
            satis.SilindiMi = false;
            _satisDal.Add(satis);
        }

        public void UpdateSatis(Satislar satis)
        {
            satis.AktifMi = true;
            satis.SilindiMi = false;
            _satisDal.Update(satis);
        }

        public void DeleteSatis(Satislar satis)
        {
            _satisDal.Delete(satis);
        }

        public void SilindiSatis(Satislar satis)
        {
            var k = _satisDal.Get(x => x.ID == satis.ID);
            k.SilindiMi = true;
            _satisDal.Update(k);
        }

        public void AktifMiSatis(Satislar satis)
        {
            var k = _satisDal.Get(x => x.ID == satis.ID);
            if (k.AktifMi == true)
            {
                k.AktifMi = false;
            }
            else
            {
                k.AktifMi = true;
            }
            _satisDal.Update(k);
        }
    }
}
