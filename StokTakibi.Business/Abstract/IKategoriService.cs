using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StokTakibiEntities.Concrete;

namespace StokTakibiBusiness.Abstract
{
    public interface IKategoriService
    {
        List<Kategoriler> GetAllKategoriler();

        Kategoriler GetKategoriById(int id);

        void CreateKategori(Kategoriler kategori);

        void UpdateKategori(Kategoriler kategori);

        void DeleteKategori(Kategoriler kategori);

        void SilindiMiKategori(Kategoriler kategori);

        void AktifMiKategori(Kategoriler kategori);
    }
}
