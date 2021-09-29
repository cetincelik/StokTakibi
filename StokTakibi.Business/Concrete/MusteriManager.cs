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
    public class MusteriManager: IMusteriService
    {
        private IMusteriDal _musteriDal;

        public MusteriManager(IMusteriDal musteriDal)
        {
            _musteriDal = musteriDal;
        }

        public List<Musteriler> GetAllMusteriler()
        {
           return _musteriDal.GetList();
        }

        public Musteriler GetMusteriById(int id)
        {
            return _musteriDal.Get(p => p.ID == id);
        }

        public void CreateMusteri(Musteriler musteri)
        {
            musteri.AktifMi = true;
            musteri.SilindiMi = false;
            _musteriDal.Add(musteri);
        }

        public void UpdateMusteri(Musteriler musteri)
        {
            musteri.AktifMi = true;
            musteri.SilindiMi = false;
            _musteriDal.Update(musteri);
        }

        public void DeleteMusteri(Musteriler musteri)
        {
            _musteriDal.Delete(musteri);
        }

        public void SilindiMusteri(Musteriler musteri)
        {
            var k = _musteriDal.Get(x => x.ID == musteri.ID);
            k.SilindiMi = true;
            _musteriDal.Update(k);

        }

        public void AktifMiMusteri(Musteriler musteri)
        {
            var k = _musteriDal.Get(x => x.ID == musteri.ID);
            if (k.AktifMi == true)
            {
                k.AktifMi = false;
            }
            else
            {
                k.AktifMi = true;
            }
            _musteriDal.Update(k);

        }
    }
}
