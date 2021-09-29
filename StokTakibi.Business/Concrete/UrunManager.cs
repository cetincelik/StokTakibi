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
    public class UrunManager: IUrunService
    {
        private IUrunDal _urunDal;

        public UrunManager(IUrunDal urunDal)
        {
            _urunDal = urunDal;
        }

        public List<Urunler> GetAllUrunler()
        {
            return _urunDal.GetList();
        }

        public Urunler GetUrunById(int id)
        {
            return _urunDal.Get(p => p.ID == id);
        }

        public void CreateUrun(Urunler urun)
        {
            urun.AktifMi = true;
            urun.SilindiMi = false;
            _urunDal.Add(urun);
        }

        public void UpdateUrun(Urunler urun)
        {
            urun.AktifMi = true;
            urun.SilindiMi = false;
            _urunDal.Update(urun);
        }

        public void DeleteUrun(Urunler urun)
        {
            _urunDal.Delete(urun);
        }

        public void SilindiUrun(Urunler urun)
        {
            var k = _urunDal.Get(x => x.ID == urun.ID);
            k.SilindiMi = true;
            _urunDal.Update(k);

        }

        public void AktifMiUrun(Urunler urun)
        {
            var k = _urunDal.Get(x => x.ID == urun.ID);
            if (k.AktifMi == true)
            {
                k.AktifMi = false;
            }
            else
            {
                k.AktifMi = true;
            }
            _urunDal.Update(k);

        }

        public List<Urunler> UrunAra(string ara)
        {
            List<Urunler> ArananUrun = _urunDal.GetList(x => x.UrunAdi.Contains(ara) || x.BankodNo.Contains(ara));

            return ArananUrun;
        }
    }
}
