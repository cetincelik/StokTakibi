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
    public class KategoriManager: IKategoriService
    {
        private IKategoriDal _kategoriDal;

        public KategoriManager(IKategoriDal kategoriDal)
        {
            _kategoriDal = kategoriDal;
        }

        public List<Kategoriler> GetAllKategoriler()
        {
            return _kategoriDal.GetList();
        }

        public Kategoriler GetKategoriById(int id)
        {
            return _kategoriDal.Get(p => p.ID == id);
        }

        public void CreateKategori(Kategoriler kategori)
        {
           
            kategori.AktifMi = true;
            kategori.SilindiMi = false;

            _kategoriDal.Add(kategori);
        }

        public void UpdateKategori(Kategoriler kategori)
        {
            
             kategori.AktifMi = true;
             kategori.SilindiMi = false;
            _kategoriDal.Update(kategori);
        }

        public void DeleteKategori(Kategoriler kategori)
        {

            _kategoriDal.Delete(kategori);
        }

        public void SilindiMiKategori(Kategoriler kategori)
        {
            var k = _kategoriDal.Get(x => x.ID == kategori.ID);
            
            k.SilindiMi = true;
                _kategoriDal.Update(k);
        }

        public void AktifMiKategori(Kategoriler kategori)
        {
            var k = _kategoriDal.Get(x => x.ID == kategori.ID);
            if (k.AktifMi == true)
            {
                k.AktifMi = false;
            }
            else
            {
                k.AktifMi = true;
            }
            _kategoriDal.Update(k);
        }
    }
}
