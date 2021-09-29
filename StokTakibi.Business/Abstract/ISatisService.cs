using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StokTakibiEntities.Concrete;

namespace StokTakibiBusiness.Abstract
{
    public interface ISatisService
    {
        List<Satislar> GetAllSatislar();

        Satislar GetSatisById(int id);

        void CreateSatis(Satislar satis);

        void UpdateSatis(Satislar satis);

        void DeleteSatis(Satislar satis);

        void SilindiSatis(Satislar satis);

        void AktifMiSatis(Satislar satis);

        List<Satislar> KullaniciIDGoreSatisGetir(int kulaniciID);




    }
}
