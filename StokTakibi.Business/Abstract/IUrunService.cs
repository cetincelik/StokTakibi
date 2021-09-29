using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StokTakibiEntities.Concrete;

namespace StokTakibiBusiness.Abstract
{
    public interface IUrunService
    {
        List<Urunler> GetAllUrunler();

        Urunler GetUrunById(int id);

        void CreateUrun(Urunler urun);

        void UpdateUrun(Urunler urun);

        void DeleteUrun(Urunler urun);

        void SilindiUrun(Urunler urun);

        void AktifMiUrun(Urunler urun);

        List<Urunler> UrunAra(string ara);
    }
}
